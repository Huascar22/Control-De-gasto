const btnLogin = document.getElementById("Btn-login");
const urlLogin = "https://localhost:7002/Usuarios/LoginUsuario";
const cuardoCargando = document.getElementById("cajacargando");
const formulario = document.getElementById("formularioLogin");
const UrlUsuarioEstado = "https://localhost:7002/Usuarios/Login";



btnLogin.addEventListener("click", ()=>{
    const usernameLogin = document.getElementById("usernameLogin").value;
    const password = document.getElementById("password").value;
    if(usernameLogin.trim() === "" || password.trim() === ""){event.preventDefault();}
    else{
        event.preventDefault();
        LoginApi(usernameLogin, password);
    }   
});

function LoginApi(usernameLogin, password){
    fetch(urlLogin)
    .then(data => data.json())
    .then(data => {
       var encontrado = data.find(function(objeto) {
        return objeto.username == usernameLogin && objeto.password == password;
        });
        if(encontrado){
            BuscarUsuario(usernameLogin, password);            
        }else{alert("Clave o U Incorrecto")}
    })
}

function BuscarUsuario(usernameLogin, password){
    fetch(UrlUsuarioEstado+"/"+usernameLogin+"/"+password)
    .then(U => U.json())
    .then(U => {        
        let UsuarioEstado = new Usuario(U.id, U.name, U.username, U.email, U.password, U.phone);
        localStorage.setItem("usuario", JSON.stringify(UsuarioEstado)); 
        console.log(UsuarioEstado);
        window.location = "dashboard.html";
    })
}

class Usuario{
    constructor(id, name, username, email, password, phone){
        this.id = id,
        this.name = name,
        this.username = username,
        this.email = email,
        this.password = password,
        this.phone = phone
    }
}

class UsuarioRegistro{
    constructor(name, username, email, password, phone){
        this.name = name,
        this.username = username,
        this.email = email,
        this.password = password,
        this.phone = phone
    }
}





