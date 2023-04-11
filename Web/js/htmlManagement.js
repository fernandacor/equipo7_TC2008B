fetch('navigation.html')
    .then(response => response.text())
    .then(data => {
        document.querySelector('nav').innerHTML = data;
    });