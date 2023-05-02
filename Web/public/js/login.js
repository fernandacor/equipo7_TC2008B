document.addEventListener('DOMContentLoaded', async () => {
    const form = document.getElementById('formInput');
    const loginError = document.getElementById('login-error');

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
                let errorResponse = await response.json();
                loginError.textContent = errorResponse.message;
                loginError.style.display = 'block';
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