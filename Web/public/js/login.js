/*document.addEventListener('DOMContentLoaded', async () => {
    const form = document.getElementById('formInput');
    if (form) {
        form.onsubmit = async (e) => {
        e.preventDefault();

        const data = new FormData(e.target);
        const dataObj = Object.fromEntries(data.entries());

        let response = await fetch('/api/login', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(dataObj)
        });

        if (response.ok) {
            let results = await response.json();
            console.log(results);
            window.location.href = results.redirect;
        } else {
            console.log(response.status);
        }
        };
    }
});

window.addEventListener('load', async () => {
    // Verificar si el usuario ha iniciado sesión en el backend
    let response = await fetch('/api/session');
    const process = document.getElementById('process');
    if (response.ok) {
        let user = await response.json();
        // Si el usuario ha iniciado sesión, mostrar el enlace de "Hola" en lugar del enlace de inicio de sesión
        const userLink = document.getElementById('user-link');
        const userName = document.getElementById('user-name');
        userName.textContent = user.username;
        //userLink.href = '/profile';
        //document.getElementById('loginLink').style.display = "none";
        //document.getElementById("user-info").style.display = "block";
  } else {
        // Si el usuario no ha iniciado sesión, mostrar el enlace de inicio de sesión en lugar del enlace de "Hola"
        process.textContent = "Log In";
        process.style.display = "block";
        //document.getElementById('user-info').style.display = "none";
        //document.getElementById('loginLink').style.display = "block";
  }
  });*/
/*
  document.addEventListener('DOMContentLoaded', async () => {
    const form = document.getElementById('formInput');
    if (form) {
        form.onsubmit = async (e) => {
            e.preventDefault();

            const data = new FormData(e.target);
            const dataObj = Object.fromEntries(data.entries());

            let response = await fetch('/api/login', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(dataObj)
            });

            if (response.ok) {
                let results = await response.json();
                console.log(results);
                window.location.href = results.redirect;
            } else {
                console.log(response.status);
            }
        };
    }

    // Verificar si el usuario ha iniciado sesión en el backend
    let response = await fetch('/api/session');
    if (response.ok) {
        let user = await response.json();
        // Si el usuario ha iniciado sesión, mostrar el enlace de "Hola" en lugar del enlace de inicio de sesión
        const userLink = document.getElementById('user-link');
        const userName = document.getElementById('user-name');
        userName.textContent = user.username;
        userLink.href = '/profile';
        document.getElementById('loginLink').style.display = "none";
        document.getElementById("user-info").style.display = "block";
  } else if (!response.ok){
        // Si el usuario no ha iniciado sesión, mostrar el enlace de inicio de sesión en lugar del enlace de "Hola"
        document.getElementById('user-info').style.display = "none";
        document.getElementById('loginLink').style.display = "block";
  }
});
*/

document.addEventListener('DOMContentLoaded', async () => {
    const form = document.getElementById('formInput');
    if (form) {
      form.onsubmit = async (e) => {
        e.preventDefault();
  
        const data = new FormData(e.target);
        const dataObj = Object.fromEntries(data.entries());
  
        let response = await fetch('/api/login', {
          method: 'POST',
          headers: { 'Content-Type': 'application/json' },
          body: JSON.stringify(dataObj)
        });
  
        if (response.ok) {
          let results = await response.json();
          console.log(results);
          window.location.href = results.redirect;
        } else {
          console.log(response.status);
        }
      };
    }
  });
  
window.addEventListener('load', async () => {
    // Verificar si el usuario ha iniciado sesión en el backend
    const response = await fetch('/api/session');
    const loginLink = document.querySelector('[data-login] a');
    const userGreeting = document.getElementById('user-greeting');
  
    if (response.ok) {
      // Si hay sesión activa, mostrar el mensaje de bienvenida
      const user = await response.json();
      if (user.username !== undefined) {
        userGreeting.textContent = `Hola! ${user.username}`;
        loginLink.style.display = 'none';
        userGreeting.style.display = 'block';
      }
    } else {
      // Si no hay sesión activa, mostrar el enlace de inicio de sesión
      userGreeting.textContent = '';
      if (loginLink.textContent !== 'Log In') {
        loginLink.textContent = `Log In`;
        loginLink.href = './login.html';
      }
      loginLink.style.display = 'block';
      userGreeting.style.display = 'none';
    }
});