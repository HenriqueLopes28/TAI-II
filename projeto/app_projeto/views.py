from django.shortcuts import render, redirect, get_object_or_404
from django.contrib.auth.mixins import LoginRequiredMixin
from django.contrib.auth.decorators import login_required
from django.contrib.auth import authenticate, login
from django.http import JsonResponse
from functools import wraps
from .models import Usuario
import json

def tipo_importancia(tipo_permitido):
    def decorator(view_func):
        @wraps(view_func)
        def _wrapped_view(request, *args, **kwargs):
            if not request.user.is_authenticated:
                return redirect("cadastro")  # Redireciona para login
            
            if request.user.importancia != tipo_permitido:
                return redirect("cadastro")  # Redireciona para outra página
            
            return view_func(request, *args, **kwargs)
        return _wrapped_view
    return decorator

def home(request):
    return render(request, 'usuarios/home.html')

def cadastro(request):

    if request.method != "POST":
        return render(request, 'usuarios/cadastro.html')
    
    if request.method == "POST":
        numero = request.POST.get("numero_cadastro")

        try:
            usuario = Usuario.objects.get(numero_cadastro=numero)  # Busca no banco de dados
            
            login(request, usuario)
            
            # Redirecionamento com base na importância
            if usuario.importancia == 1:
                return redirect("pesquisa")  # Nome da URL correspondente
            
            elif usuario.importancia == 2:
                return redirect("pesquisa_professores")
            
            elif usuario.importancia == 3:
                return redirect("resultados")
            
        except Usuario.DoesNotExist:
            return render(request, "usuarios/cadastro.html", {"mensagem": "Usuário não encontrado!"})


@login_required
@tipo_importancia(1)
def pesquisa(request):
    return render(request, 'usuarios/pesquisa.html')

@login_required
@tipo_importancia(2)
def pesquisa_professores(request):
    return render(request, 'usuarios/pesquisa_professores.html')

@login_required
@tipo_importancia(3)
def resultados(request):
    return render(request, 'usuarios/resultados.html')

@login_required
@tipo_importancia(1)
def concluido(request):
    return render(request, 'usuarios/concluido.html')

@login_required
@tipo_importancia(1)
def salvar_respostas(request):
    if request.method == "POST":
        data = json.loads(request.body)  # Converte JSON para dicionário Python
        print("Respostas recebidas:", data["respostas"])  # Apenas para debug
        #return JsonResponse({"status": "sucesso", "mensagem": "Respostas salvas!"})
        return JsonResponse({"redirect": "/concluido/"})  
    
    return JsonResponse({"status": "erro", "mensagem": "Método inválido"}, status=400)