/**
 * @param {number} alpha Indicated the transparency of the color
 * @returns {string} A string of the form 'rgba(240, 50, 123, 1.0)' that represents a color
 */
 function random_color(alpha = 1.0) {
    const r_c = () => Math.round(Math.random() * 127) + 128;
    return `rgba(${r_c()}, 0, ${r_c()}, ${alpha})`;
}

async function main()
{
    /*
    document.getElementById('formSelectUser').onsubmit = async (e) =>
    {
        e.preventDefault()

        const data = new FormData(formSelectUser)
        const dataObj = Object.fromEntries(data.entries())

        let response = await fetch(`http://127.0.0.1:5235/api/usuario/${dataObj['username']}`,{
            method: 'GET'
        })
        
        if(response.ok)
        {
            let results = await response.json()
        
            if(results.length > 0)
            {
                const headers = Object.keys(results[0])
                const values = Object.values(results)
    
                let table = document.createElement("table")
    
                let tr = table.insertRow(-1)                  
    
                for(const header of headers)
                {
                    let th = document.createElement("th")     
                    th.innerHTML = header
                    tr.appendChild(th)
                }
    
                for(const row of values)
                {
                    let tr = table.insertRow(-1)
    
                    for(const key of Object.keys(row))
                    {
                        let tabCell = tr.insertCell(-1)
                        tabCell.innerHTML = row[key]
                    }
                }
    
                const container = document.getElementById('getResultsID')
                container.innerHTML = ''
                container.appendChild(table)
            }
            else
            {
                const container = document.getElementById('getResultsID')
                container.innerHTML = 'No results to show.'
            }
        }
        else{
            getResults.innerHTML = response.status
        }
    }
    */

    document.getElementById('formInsert').onsubmit = async(e)=>
    {
        e.preventDefault()

        const data = new FormData(formInsert)
        const dataObj = Object.fromEntries(data.entries())

        let response = await fetch('http://127.0.0.1:5235/api/usuario',{
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify(dataObj)
        })
        
        if(response.ok)
        {
            let results = await response.json()
        
            console.log(results)
            postResults.innerHTML = results.message
        }
        else{
            postResults.innerHTML = response.status
        }
    }

}

main()

try
{
    const levels_response = await fetch('http://127.0.0.1:5235/api/partidas',{
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
            type: 'bar',
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
                        fontFamily: "'OCR A Extended', monospace"
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
                    fontFamily: "'OCR A Extended', monospace"
                  }
                }
            }
        })
    }

}
catch(error)
{
    console.log(error)
}