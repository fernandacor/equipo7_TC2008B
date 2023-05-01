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

try
{
    const levels_response = await fetch('http://127.0.0.1:5235/api/contpartidas',{
        method: 'GET'
    })

    console.log('Got a response correctly')

    if(levels_response.ok){
        console.log('Response is ok. Converting to JSON.')

        let results = await levels_response.json()

        console.log(results)
        console.log('Data converted correctly. Plotting chart.')
            
        const values = Object.values(results)

        // In this case, we just separate the data into different arrays using the map method of the values array. This creates new arrays that hold only the data that we need.
        const level_names = values.map(e => e['username'])
        const level_colors = values.map(e => random_color(0.8))
        const level_borders = values.map(e => 'rgba(0, 0, 0, 1.0)')
        const level_completion = values.map(e => e['COUNT(idPartida)'])

        
        const ctx_levels2 = document.getElementById('apiChart2').getContext('2d');
        const levelChart2 = new Chart(ctx_levels2, 
        {
            type: 'polarArea',
            data: {
                labels: level_names,
                datasets: [
                    {
                        label: 'Usuarios con más partidas',
                        backgroundColor: level_colors,
                        borderColor: level_borders,
                        borderWidth: 2,
                        data: level_completion
                    }
                ]
            }
        })
    }

    const estadisticasEnemigosMatados = await fetch('http://127.0.0.1:5235/api/enemigos',{
        method: 'GET'
    })

    console.log('Got a response correctly')

    if(estadisticasEnemigosMatados.ok){
        console.log('Response is ok. Converting to JSON.')

        let resultsEnemiesKilled = await estadisticasEnemigosMatados.json()

        console.log(resultsEnemiesKilled)
        console.log('Data converted correctly. Plotting chart.')
            
        const values = Object.values(resultsEnemiesKilled)

        // In this case, we just separate the data into different arrays using the map method of the values array. This creates new arrays that hold only the data that we need.
        const username = values.map(e => e['username'])
        const level_colors = values.map(e => random_color(0.8))
        const level_borders = values.map(e => 'rgba(0, 0, 0, 1.0)')
        const EnemiesKilled = values.map(e => e['enemiesKilled'])

        
        const ctx_levels = document.getElementById('apiChart1').getContext('2d');
        const EnemiesChart = new Chart(ctx_levels,
        {
            type: 'pie',
            data: {
                labels: username,
                datasets: [
                    {
                        label: 'Usuarios con más enemigos matados',
                        backgroundColor: level_colors,
                        borderColor: level_borders,
                        borderWidth: 2,
                        data: EnemiesKilled
                    }
                ]
            }
        })
    }

    const damageDealtByUser = await fetch('http://127.0.0.1:5235/api/damage',{
        method: 'GET'
    })

    console.log('Got a response correctly')

    if(damageDealtByUser.ok){
        console.log('Response is ok. Converting to JSON.')

        let resultsDamageByUser = await damageDealtByUser.json()

        console.log(resultsDamageByUser)
        console.log('Data converted correctly. Plotting chart.')

        const values = Object.values(resultsDamageByUser)

        const username = values.map(e => e['username'])
        const level_colors = values.map(e => random_color(0.8))
        const level_borders = values.map(e => 'rgba(0, 0, 0, 1.0)')
        const damageDealt = values.map(e => e['damageDealt'])

        const ctx_damage = document.getElementById('apiChart3').getContext('2d');
        const DamageChart = new Chart(ctx_damage,
        {
            type: 'bar',
            data: {
                labels: username,
                datasets: [
                    {
                        label: 'Daño infligido',
                        backgroundColor: level_colors,
                        borderColor: level_borders,
                        data: damageDealt,
                        family: "'OCR A Extended', monospace"
                    }
                ]
            },
            options: {
                indexAxis: 'y',
                // Elements options apply to all of the options unless overridden in a dataset
                // In this case, we are setting the border of each horizontal bar to be 2px wide
                elements: {
                  bar: {
                    borderWidth: 2,
                  }
                },
                responsive: true,
                plugins: {
                  legend: {
                    position: 'right',
                  },
                  title: {
                    display: true,
                    text: 'Daño infligido',
                    family: "'OCR A Extended', monospace"
                  }
                }
            }
        })
    }

    const coinsByUser = await fetch('http://127.0.0.1:5235/api/coins',{
        method: 'GET'
    })

    console.log('Got a response correctly')

    if(coinsByUser.ok){
        console.log('Response is ok. Converting to JSON.')

        let resultsCoinsByUser = await coinsByUser.json()

        console.log(resultsCoinsByUser)
        console.log('Data converted correctly. Plotting chart.')

        const values = Object.values(resultsCoinsByUser)

        const username2 = values.map(e => e['username'])
        const level_colors = values.map(e => random_color(0.8))
        //const level_borders = values.map(e => 'rgba(0, 0, 0, 1.0)')
        const coinsTaken = values.map(e => e['coinstaken'])

        const ctx_coins = document.getElementById('apiChart4').getContext('2d');
        const coinsChart = new Chart(ctx_coins,
        {
            type: 'line',
            data: {
                labels: username2,
                datasets: [
                    {
                        label: 'Usuarios con más monedas',
                        backgroundColor: level_colors,
                        pointRadius: 10,
                        data: coinsTaken
                    }
                ]
            },
            options: {
                responsive: true,
                plugins: {
                  title: {
                    display: true,
                    text: 'Coins taken by users'
                  },
                  legend: {
                    labels: {
                        // This more specific font property overrides the global property
                        font: {
                            family: "'OCR A Extended', monospace"
                        }
                    }
                }
                },  
            } 
        })
    }
}
catch(error)
{
    console.log(error)
}