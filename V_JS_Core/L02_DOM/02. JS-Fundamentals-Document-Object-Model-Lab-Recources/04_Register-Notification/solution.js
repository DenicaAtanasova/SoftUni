
function register() {
  let username = document.getElementById('username').value;
  let email = document.getElementById('email').value;
  let password = document.getElementById('password').value;

  let pattern = /(.+)@(.+).(com|bg)/gm;

  if(username && pattern.test(email) && password) {
    let resultElement = document.getElementById('result');

    let headerElemment = document.createElement('h1');
    headerElemment.textContent = 'Successful Registration!';
    resultElement.appendChild(headerElemment);

    resultElement.innerHTML += `Username: ${username}<br>`;
    resultElement.innerHTML += `Email: ${email}<br>`;
    resultElement.innerHTML += `Password: ${"*".repeat(password.length)}`;

    setTimeout(function () {
      resultElement.innerHTML = '';
    }, 5000);
  }
}