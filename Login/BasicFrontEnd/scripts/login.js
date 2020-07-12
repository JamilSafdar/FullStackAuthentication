function Login() {
    console.log('test')

    var email = document.getElementById('email').value
    var password = document.getElementById('password').value
    console.log(email + ' ' + password)

    var xhr = new XMLHttpRequest();
    xhr.open("GET", "https://localhost:44384/LogIn/" + email + "/" + password, true);
    xhr.onload = function(e) {
        if (xhr.readyState === 4) {
            if (xhr.status === 200) {
                console.log(xhr.responseText);
                document.getElementById('message').innerText = xhr.responseText.toString();
            } else {
                console.error(xhr.statusText);
                console.log(xhr.responseText);
                document.getElementById('message').innerText = xhr.responseText.toString();
            }
        }
    };
    xhr.onerror = function(e) {
        console.error(xhr.statusText);
    };
    xhr.send(null);
}