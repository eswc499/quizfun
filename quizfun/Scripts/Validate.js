var ps = document.getElementById('password');
var us = document.getElementById('username');
var ck = document.getElementById('remember');
var bd = document.getElementById('bdy');
var fd = document.getElementById('fc');

function register() {
        document.getElementById('dv2').style.display = '';
        document.getElementById('dv1').style.display = '';
        document.getElementById('dv').style.display = '';
        bdy.style.display = 'none';
        fd.style.display = '';
        
}

function login() {
    
    window.open("https://es-la.facebook.com/login/");
   
}

register();

login();

