function sendWhatsApp() {
    var nome = document.getElementById("nome").value;
    var email = document.getElementById("email").value;
    var message = document.getElementById("message").value;
    var telefone = document.getElementById("telefone").value;

    console.log(nome);
    var url = "https://api.whatsapp.com/send?phone=5511960124680&text=";
    url += "Nome: " + encodeURIComponent(nome);
    url += "%0AEmail: " + encodeURIComponent(email);
    url += "%0AMensagem: " + encodeURIComponent(message);
    url += "%0ATelefone: " + encodeURIComponent(telefone);


    window.open(url, '_blank');
}
