const btnAdministrar = document.getElementById("AdministrarCuenta");
const menuCuenta = document.getElementById("MenuCuenta");
const informacion = document.getElementById("InformacionFormulario");
const formulario = document.getElementById("formulario");

const ACambiarNombre = document.getElementById("A-CambiarNombre");
const ACambiarPhone = document.getElementById("A-CambiarPhone");
const AcambiarEmail = document.getElementById("A-CambiarEmail");
const AcambiarUsername = document.getElementById("A-CambiarUsername");



const formularioNombre = document.getElementById("FormularioNombre");
const formularioEmail = document.getElementById("FormularioEmail");
const formularioPhone = document.getElementById("FormularioPhone");
const formularioUsername = document.getElementById("FormularioUsername");

localStorage.setItem("menuCuenta", menuCuenta);
menuCategoria = localStorage.getItem("menuCategoria");

btnAdministrar.addEventListener("click", ()=>{ 
    containerGrafico.style.display = "none";
    menuCategoria.style.display = "none";
    menuCuenta.style.display = "flex";
});

informacion.addEventListener("click", ()=>{
    const UsuarioActual = JSON.parse(localStorage.getItem("usuario"));
    console.log(UsuarioActual);
    const name = document.getElementById("name");
    const username = document.getElementById("username");
    const email = document.getElementById("emailRegistro");
    const phone = document.getElementById("phone");

    formulario.style.display = "flex"; 
    formularioEmail.style.display = "none";
    formularioNombre.style.display = "none";
    formularioPhone.style.display  = "none";
    formularioUsername.style.display = "none"; 

    
    name.value = UsuarioActual.name;
    username.value = UsuarioActual.username;
    email.value = UsuarioActual.email;
    phone.value = UsuarioActual.phone;   
});

ACambiarNombre.addEventListener("click", ()=>{
    formularioNombre.style.display = "flex";
    formulario.style.display = "none";
    formularioEmail.style.display = "none";
    formularioPhone.style.display  = "none";
    formularioUsername.style.display = "none";   
});

AcambiarEmail.addEventListener("click", ()=>{
    formularioNombre.style.display = "none";
    formulario.style.display = "none";
    formularioEmail.style.display = "flex";
    formularioPhone.style.display  = "none";
    formularioUsername.style.display = "none";
});

AcambiarUsername.addEventListener("click", ()=>{
    formularioNombre.style.display = "none";
    formulario.style.display = "none";
    formularioEmail.style.display = "none";
    formularioPhone.style.display  = "none";
    formularioUsername.style.display = "flex";
});

ACambiarPhone.addEventListener("click", ()=>{
    formularioNombre.style.display = "none";
    formulario.style.display = "none";
    formularioEmail.style.display = "none";
    formularioPhone.style.display  = "flex";
    formularioUsername.style.display = "none";
});




