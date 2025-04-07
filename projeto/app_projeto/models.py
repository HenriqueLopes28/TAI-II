from django.contrib.auth.models import AbstractBaseUser
from django.db import models
# Create your models here.

class Usuario(AbstractBaseUser):
    numero_cadastro = models.CharField(max_length=6, unique=True)
    importancia = models.IntegerField(choices=[(1, "Aluno"), (2, "Professor"), (3, "Diretor")])

    USERNAME_FIELD = "numero_cadastro"
    REQUIRED_FIELDS = ["importancia"]
    password = models.CharField(max_length=128, default='defaultpassword')