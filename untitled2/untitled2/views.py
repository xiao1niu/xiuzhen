from django.http import HttpResponse
from django.shortcuts import render


def hello(request):
    context          = {}
    context['hello'] = 'Hello World!'
    return render(request, 'hello.html', context)

def home(request):
    context          = {}
    context['home'] = 'Hello World!'
    return render(request, 'home.html', context)
def login(request):
    context          = {}
    context['login'] = 'Hello World!'
    return render(request, 'login.html', context)