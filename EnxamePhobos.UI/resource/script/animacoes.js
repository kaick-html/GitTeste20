
/* pag home */
$('.carrossel').slick({
  dots: true,
  slidesToShow: 1,
  slidesToScroll: 1,
  autoplay: true,
  autoplaySpeed: 2000,
});




/* pag FAQ */
let btn = document.getElementsByClassName('tituloEvento');


for (let i = 0; i < btn.length; i++) {

  btn[i].addEventListener("click", function () {
    this.classList.toggle("ativa");
    var textoEvento = this.nextElementSibling;
    console.log(btn[i]);
    if (textoEvento.style.maxHeight) {
      textoEvento.style.maxHeight = null;

    } else {
      textoEvento.style.maxHeight = textoEvento.scrollHeight + "px";
    }
  });

};


/* Menu Mobile*/
document.querySelector(".abrirMenu").onclick = function () {
  document.documentElement.classList.add("menuAtivo");
}

document.querySelector(".fecharMenu").onclick = function () {
  document.documentElement.classList.remove("menuAtivo");
}


document.querySelector(".divBaseS").onclick =  function () {
  if (itens.style.display == 'block') {
      itens.style.display = 'none'
  }

  else {
      itens.style.display = 'block'
  }
}



/* pag contato whattsapp */
function sendWhatsApp() {
  var name = document.getElementById("nome").value;
  var email = document.getElementById("email").value;
  var message = document.getElementById("message").value;
  var telefone = document.getElementById("telefone").value;

  var url = "https://api.whatsapp.com/send?phone=5511999394161&text=";
  url += "Nome: " + encodeURIComponent(name);
  url += "%0AEmail: " + encodeURIComponent(email);
  url += "%0AMensagem: " + encodeURIComponent(message);
  url += "%0ATelefone: " + encodeURIComponent(telefone);

  window.open(url, '_blank');
}