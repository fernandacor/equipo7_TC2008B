document.addEventListener('DOMContentLoaded', async () => {
    const response = await fetch('/api/session');
    const user = await response.json();
  
    if (user.username === undefined) {
        alert('Debes iniciar sesión para acceder a esta página.');
        window.location.href = './login.html';
    }
  });