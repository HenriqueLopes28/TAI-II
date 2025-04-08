from django.shortcuts import render, redirect, get_object_or_404
from django.contrib.auth.mixins import LoginRequiredMixin
from django.contrib.auth.decorators import login_required
from django.views.decorators.cache import never_cache
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

@never_cache
def cadastro(request):

    mensagem_erro = request.session.pop("mensagem_erro", None)

    if request.method == "GET":
        return render(request, 'usuarios/cadastro.html', {"mensagem_erro": mensagem_erro})
    
    if request.method == "POST":
        numero = request.POST.get("numero_cadastro")

        try:
            usuario = Usuario.objects.get(numero_cadastro=numero)  # Busca no banco de dados
            
            login(request, usuario)
            request.session["mensagem_sucesso"] = "Login realizado com sucesso!"
            # Redirecionamento com base na importância
            if usuario.importancia == 1:
                return redirect("pesquisa")  # Nome da URL correspondente
            
            elif usuario.importancia == 2:
                return redirect("pesquisa_professores")
            
            elif usuario.importancia == 3:
                return redirect("resultados")
            
        except Usuario.DoesNotExist:
            request.session["mensagem_erro"] = "Usuário não encontrado!"
            return redirect("cadastro")


@login_required
@tipo_importancia(1)
def pesquisa(request):
    mensagem_sucesso = request.session.pop("mensagem_sucesso", None)
    return render(request, 'usuarios/pesquisa.html', {"mensagem_sucesso": mensagem_sucesso})

@login_required
@tipo_importancia(2)
def pesquisa_professores(request):
    mensagem_sucesso = request.session.pop("mensagem_sucesso", None)
    return render(request, 'usuarios/pesquisa_professores.html', {"mensagem_sucesso": mensagem_sucesso})

@login_required
@tipo_importancia(3)
def resultados(request):
    mensagem_sucesso = request.session.pop("mensagem_sucesso", None)
    return render(request, 'usuarios/resultados.html', {"mensagem_sucesso": mensagem_sucesso})

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