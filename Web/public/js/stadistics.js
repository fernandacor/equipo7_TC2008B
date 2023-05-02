/**
 * @param {number} alpha Indicated the transparency of the color
 * @returns {string} A string of the form 'rgba(240, 50, 123, 1.0)' that represents a color
 */
function random_color(alpha = 1.0) {
    const r_c = () => Math.round(Math.random() * 255);
    let r, g, b;
    do {
        r = r_c();
        g = r_c();
        b = r_c();
    } while (g > r * 0.8 && g > b * 0.8);
    return `rgba(${r}, ${g}, ${b}, ${alpha})`;
}

const PORT = 5235

/*
async function main()
{
    document.getElementById('formInput').onsubmit = async (e) => {
        e.preventDefault();
    
        const data = new FormData(e.target);
        const dataObj = Object.fromEntries(data.entries());
    
        let response = await fetch('http://127.0.0.1:5235/api/login', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(dataObj)
        });
    
        if (response.ok) {
            let results = await response.json();
            console.log(results.message); // muestra el mensaje de inicio de sesión exitoso
            window.location.href = '/html/index.html'; // redirige a la página index.html
          } else {
            console.log(response.status);
          }
    };
}

main() */
/*
async function main() {
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
    
            // Actualizar el enlace de "Hola" con el nombre de usuario y mostrarlo
            const userLink = document.getElementById('user-link');
            const userName = document.getElementById('user-name');
            userName.textContent = results.username;
            userLink.href = results.redirect;
            document.getElementById('loginLink').style.display = 'none';
            document.getElementById('user-info').style.display = 'block';
    
            window.location.href = results.redirect;
        } else {
          console.log(response.status);
        }
      };
    }
  }
  
main();*/

try {
    const levels_response = await fetch(`http://127.0.0.1:${PORT}/api/contpartidas`, {
        method: 'GET'
    })

    console.log('Got a response correctly')
    Chart.defaults.color = '#fff';
    Chart.defaults.font.size = 16;
    Chart.defaults.font.family = "'Ubuntu', sans-serif";
    Chart.defaults.borderColor = 'rgba(255, 255, 255, 0.3)';

    if (levels_response.ok) {
        console.log('Response is ok. Converting to JSON.')

        let results = await levels_response.json()

        console.log(results)
        console.log('Data converted correctly. Plotting chart.')

        const values = Object.values(results)

        // In this case, we just separate the data into different arrays using the map method of the values array. This creates new arrays that hold only the data that we need.
        const username = values.map(e => e['username'])
        const bordersColor = values.map(e => random_color(1))
        const backgroundsColor = bordersColor.map(b => b.slice(0, -2) + '0.6)')
        const level_completion = values.map(e => e['COUNT(idPartida)'])


        const ctx_levels2 = document.getElementById('apiChart1').getContext('2d');
        const levelChart2 = new Chart(ctx_levels2,
            {
                type: 'bar',
                data: {
                    labels: username,
                    datasets: [
                        {
                            // label: 'Cantidad de partidas',
                            backgroundColor: backgroundsColor,
                            borderColor: bordersColor,
                            borderWidth: 2,
                            data: level_completion,
                        }
                    ]
                },
                options: {
                    responsive: true,
                    indexAxis: 'y',
                    plugins: {
                        legend: {
                            display: false,
                        },
                        title: {
                            display: false,
                        }
                    },
                },
            })
    }

    const estadisticasEnemigosMatados = await fetch(`http://127.0.0.1:${PORT}/api/enemigos`, {
        method: 'GET'
    })

    console.log('Got a response correctly')

    if (estadisticasEnemigosMatados.ok) {
        console.log('Response is ok. Converting to JSON.')

        let resultsEnemiesKilled = await estadisticasEnemigosMatados.json()

        console.log(resultsEnemiesKilled)
        console.log('Data converted correctly. Plotting chart.')

        const values = Object.values(resultsEnemiesKilled)

        // In this case, we just separate the data into different arrays using the map method of the values array. This creates new arrays that hold only the data that we need.
        const username = values.map(e => e['username'])
        const bordersColor = values.map(e => random_color(1))
        const backgroundsColor = bordersColor.map(b => b.slice(0, -2) + '0.6)')
        const enemiesKilled = values.map(e => e['enemiesKilled'])


        const ctx_levels = document.getElementById('apiChart2').getContext('2d');
        const EnemiesChart = new Chart(ctx_levels,
            {
                type: 'bar',
                data: {
                    labels: username,
                    datasets: [
                        {
                            // label: 'Enemigos matados',
                            backgroundColor: backgroundsColor,
                            borderColor: bordersColor,
                            borderWidth: 3,
                            data: enemiesKilled
                        }
                    ]
                },
                options: {
                    responsive: true,
                    indexAxis: 'y',
                    plugins: {
                        legend: {
                            display: false,
                        },
                        title: {
                            display: false,
                        }
                    },
                },
            })
    }

    const damageDealtByUser = await fetch(`http://127.0.0.1:${PORT}/api/damage`, {
        method: 'GET'
    })

    console.log('Got a response correctly')

    if (damageDealtByUser.ok) {
        console.log('Response is ok. Converting to JSON.')

        let resultsDamageByUser = await damageDealtByUser.json()

        console.log(resultsDamageByUser)
        console.log('Data converted correctly. Plotting chart.')

        const values = Object.values(resultsDamageByUser)

        const username = values.map(e => e['username'])
        const bordersColor = values.map(e => random_color(1))
        const backgroundsColor = bordersColor.map(b => b.slice(0, -2) + '0.6)')
        const damageDealt = values.map(e => e['damageDealt'])

        const ctx_damage = document.getElementById('apiChart3').getContext('2d');
        const DamageChart = new Chart(ctx_damage,
            {
                type: 'bar',
                data: {
                    labels: username,
                    datasets: [
                        {
                            // label: 'Daño infligido',
                            backgroundColor: backgroundsColor,
                            borderColor: bordersColor,
                            borderWidth: 2,
                            data: damageDealt,
                        }
                    ]
                },
                options: {
                    responsive: true,
                    indexAxis: 'y',
                    plugins: {
                        legend: {
                            display: false,
                        },
                        title: {
                            display: false,
                        }
                    },
                },
            })
    }

    const coinsByUser = await fetch(`http://127.0.0.1:${PORT}/api/coins`, {
        method: 'GET'
    })

    console.log('Got a response correctly')

    if (coinsByUser.ok) {
        console.log('Response is ok. Converting to JSON.')

        let resultsCoinsByUser = await coinsByUser.json()

        console.log(resultsCoinsByUser)
        console.log('Data converted correctly. Plotting chart.')

        const values = Object.values(resultsCoinsByUser)

        const username = values.map(e => e['username'])
        const bordersColor = values.map(e => random_color(1))
        const backgroundsColor = bordersColor.map(b => b.slice(0, -2) + '0.6)')
        const coinsTaken = values.map(e => e['coinstaken'])

        const ctx_coins = document.getElementById('apiChart4').getContext('2d');
        const coinsChart = new Chart(ctx_coins,
            {
                type: 'bar',
                data: {
                    labels: username,
                    datasets: [
                        {
                            // label: 'Usuarios con más monedas',
                            backgroundColor: backgroundsColor,
                            borderColor: bordersColor,
                            borderWidth: 2,
                            data: coinsTaken,
                        }
                    ]
                },
                options: {
                    responsive: true,
                    indexAxis: 'y',
                    plugins: {
                        legend: {
                            display: false,
                        },
                        title: {
                            display: false,
                        }
                    },
                },
            })

    }
}
catch (error) {
    console.log(error)
}