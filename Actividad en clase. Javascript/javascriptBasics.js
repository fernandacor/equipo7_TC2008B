//ACTIVIDAD EN CLASE: JAVASCRIPT

// EJERCICIO 1
function primerNumeroQueNoSeRepite(str)
{
  const freq = {};
  for(let i = 0; i < str.length; i++)
  {
      const char = str[i];
      // Al utlizar un tipo de "diccionario" utilizamos el operador condicional terciario 
      // para determinar si el caracter está en este, si es así este le suma 1 a ese caracter,
      // si no es así este le asigna el valor 1.
      freq[char] = freq[char] ? freq[char] + 1 : 1;
  }

  for(let i = 0; i < str.length; i++) 
  {
      const char = str[i];
      // Busca el caracter que tenga asignado el valor 1, si lo encuentra va a hacer el return
      if(freq[str[i]] === 1)
      {
          return char;
      }
  }
  //Si no encuentra ningun valor que tenga asignado el valor 1, va a regresar "null"
  return null;
}

console.log('EJERCICIO 1: Función que encuentre el primer carácter de una cadena de texto que no se repite.');
console.log('String: (abacddbec)');
console.log(primerNumeroQueNoSeRepite('abacddbec'));


// EJERCICIO 2
let numList = [3, 7, 9, 10, 0, 2, 5, 1, 8, 4];

function bubbleSorter(notSorted)
{
  const len = notSorted.length;
  for (let i = 0; i < len; i++)
  {
    for (let j = 0; j < len - 1 - i; j++) 
    {
      if (notSorted[j] > notSorted[j + 1]) 
      {
        [notSorted[j], notSorted[j+1]] = [notSorted[j+1], notSorted[j]];
      }
    }   
  }
  return notSorted;
}

console.log('EJERCICIO 2: Función que implementa el algoritmo bubblesort para ordenar una lista de números.');
console.log('Original list: [3, 7, 9, 10, 0, 2, 5, 1, 8, 4]');
numListOrdenada = bubbleSorter(numList);
console.log('New list: [' + numListOrdenada + ']');

// EJERCICIO 3
function newReversedArray(array) 
{
  let newNums = [];
  array.forEach(n => newNums.unshift(n));
  return newNums;
}

function reverseArray(array) 
{
  for (let i = 0; i < array.length; i++) 
  {
    array.splice(array.length - i, 0, array[0]);
    array.shift();
  }
}

console.log('EJERCICIO 3: Función que invierta un arreglo de números y regrese un nuevo arreglo con el resultado, otra función que modifique el mismo arreglo que se pasa como argumento.');
let nums = [15, 34, 8, 24, 1];
console.log("Array original: " + nums);
let newNums = newReversedArray(nums);
console.log("Nuevo array: " + newNums);
reverseArray(nums);
console.log("Mismo array invertido: " + nums);


// EJERCICIO 4
function capitalizarPalabra(str) 
{
  //llamar return para que regrese el resultado 
  return str
  //usar split para separar la frase en un arreglo de palabras
    .split(' ')
    //Usar map para iterar en las palabras
    //Cambiar la primera letra (0) a UpperCase 
    //Agregar las letras restantes desde posicion (1)
    .map((word) => word.charAt(0).toUpperCase() + word.slice(1))
    // juntar las palabras del arreglo
    .join(' ');
}

console.log('EJERCICIO 4: Función que recibe una cadena de texto y regresa una nueva con la primer letra de cada palabra en mayúscula.');
console.log("String original: 'hola mundo'");
console.log(capitalizarPalabra('hola mundo'));


// EJERCICIO 5
function MCD(x, y)
{
  //Crear variables para el mcd y el resto
  var mcd, rest;
  //Crear ciclo while para que se repita mientras x y y sean diferentes de 0
  while (x != 0 && y != 0)
  {
    rest = x%y;
    x = y;
    y = rest;
  } 
  //Si x es igual a 0, mcd es igual a y
  if(x==0) mcd =y;
  //Si y es igual a 0, mcd es igual a x
  if(y==0) mcd = x;
  return mcd;
  }

  console.log('EJERCICIO 5: Función que calcula el máximo común divisor de dos números.');
  console.log("Números: 10, 100");
  console.log(MCD(10,100));

// EJERCICIO 6
let normalString = "JavaScript es divertido";

function hackerSpeak(normalString)
{
    let hS = {a:4, b:8, e:3, g:6, i:1, l:1, o:0, s:5, t:7, z:2};
    const l = normalString.length;
    let nuevoString = '';
    for (let i = 0; i < l; i++)
    {
      if (hS[normalString[i].toLowerCase()]) 
      {
        nuevoString += hS[normalString[i].toLowerCase()];
      } 
      else 
      {
        nuevoString += normalString[i];
      }
    }
    return nuevoString;
}

console.log('EJERCICIO 6: Función que cambia una cadena de texto a Hacker Speak.');
console.log('Cadena original: Javascript es divertido');
hackerString = hackerSpeak(normalString);
console.log('HackerSpeak --> ' + hackerString);

// EJERCICIO 7
function factoriza(num)
{
  let lista = [];
  for(let i = 1; i <= num; i++)
  {
      if(num % i === 0)
      {
          lista.push(i);
      }
  }
  return lista;
}
console.log('EJERCICIO 7: Función que recibe un número y regresa una lista con todos sus factores.');
console.log("Número: 12")
console.log('[' + factoriza(12) + ']');

// EJERCICIO 8
function quitaDuplicados(array)
{
  return array.filter((item, i) => array.indexOf(item) === i);
}

console.log('EJERCICIO 8: Función que quita los elementos duplicados de un arreglo y regresa una lista con los elementos que quedan.');
let numsRepetidos = [9, 3, 3, 3, 9, 1, 3, 1, 0, 1, 1, 0, 0];
let numsNoRepetidos = quitaDuplicados(numsRepetidos);
console.log("Array con números repetidos: " + numsRepetidos);
console.log("Array con números sin repetir: " + numsNoRepetidos);

// EJERCICIO 9
function longitudCadenaMasCorta(listaCadenas) 
{
  // Inicializar la longitud mínima como la longitud de la primera cadena
  let longitudMinima = listaCadenas[0].length;

  // Recorrer la lista de cadenas y actualizar la longitud mínima si se encuentra una cadena más corta
  for (let i = 1; i < listaCadenas.length; i++) 
  {
    if (listaCadenas[i].length < longitudMinima) 
    {
      longitudMinima = listaCadenas[i].length;
    }
  }

  // Devolver la longitud mínima
  return longitudMinima;
}

console.log('EJERCICIO 9: Función que recibe como parámetro una lista de cadenas de texto y regresa la longitud de la cadena más corta.');
const listaCadenas = ['Memoria', 'Mundo', 'JavaScript', 'Mexico', 'genial'];
console.log(longitudCadenaMasCorta(listaCadenas));

// EJERCICIO 10
function esPalindromo(cadena) 
{
  // Convertir la cadena a minúsculas y eliminar los espacios en blanco
  cadena = cadena.toLowerCase().replace(/\s/g, '');

  // Comparar la cadena original con su reverso
  for (let i = 0; i < cadena.length / 2; i++) 
  {
    if (cadena[i] !== cadena[cadena.length - 1 - i]) 
    {
      return false;
    }
  }

  return true;
}
//Regresa true si es un palindromo y Falso si no lo es
const cadena1 = 'radar';
const cadena2 = 'oso';
const cadena3 = 'Hola mundo';

console.log('EJERCICIO 10: Función que revisa si una cadena de texto es un palíndromo o no.');
console.log('radar = ' + esPalindromo(cadena1)); 
console.log('oso = ' + esPalindromo(cadena2));
console.log('Hola mundo = ' + esPalindromo(cadena3)); 


// EJERCICIO 11

let alphUnorderedList = ["Juan", "Pablo", "Pedro", "Angel", "Jose", "Octavio"];

function alphSortList(lst) 
{
  for (let i = 1; i < lst.length; i++) 
  {
    let selected = lst[i];
    let n = i - 1;
    while (n >= 0 && lst[n] > selected) 
    {
      lst[n + 1] = lst[n];
      n--;
    }
    lst[n + 1] = selected;
  }
  return lst;
}

console.log('EJERCICIO 11: Funcion para ordenar alfabeticamente las cadenas de texto en una lista');
console.log("\nLista desordenada: \n", alphUnorderedList);
const alphOrderedList = alphSortList(alphUnorderedList);
console.log("\nLista ordenada:\n",alphOrderedList);

//EJERCICIO 12
function medianaYModa(lista) 
{
  // Ordena la lista de números en orden ascendente
  lista.sort(function(a, b){return a - b});

  // Calcula la mediana
  let mediana = 0;
  let longitud = lista.length;
  if (longitud % 2 === 0) 
  {
    mediana = (lista[longitud/2 - 1] + lista[longitud/2]) / 2;
  } 
  else 
  {
    mediana = lista[(longitud - 1) / 2];
  }

  // Calcula la moda
  let contador = {};
  let maximo = 0;
  let moda = [];
  for (let i = 0; i < longitud; i++) 
  {
    let numero = lista[i];
    if (contador[numero] === undefined) 
    {
      contador[numero] = 0;
    }
    contador[numero]++;
    if (contador[numero] > maximo) 
    {
      maximo = contador[numero];
      moda = [numero];
    } 
    else if (contador[numero] === maximo) 
    {
      moda.push(numero);
    }
  }

  // Devuelve un objeto con la mediana y la moda
  return { mediana: mediana, moda: moda };
}

console.log('EJERCICIO 12: Función que tome una lista de números y devuelva la mediana y la moda.');
let lista = [1, 2, 3, 4, 5, 6, 6, 7, 7, 8, 9];
let resultado = medianaYModa(lista);
console.log('Lista = [1, 2, 3, 4, 5, 6, 6, 7, 7, 8, 9]');
console.log('Mediana: ' + resultado.mediana); 
console.log('Moda: ' + resultado.moda);

// EJERCICIO 13

function FrequentString(stringList) 
{
    let accumulator = {};
    let frequencyNum = 0;
    let mostFrequentString = '';
  
    stringList.forEach(string => 
    {
      if (accumulator[string]) 
      {
        accumulator[string]++;
      } 
      else 
      {
        accumulator[string] = 1;
      }
  
      if (accumulator[string] > frequencyNum) 
      {
        frequencyNum = accumulator[string];
        mostFrequentString = string;
      }
    }
    );
    return [mostFrequentString, frequencyNum, accumulator];
  }
 
console.log('EJERCICIO 13: Función que toma una lista de cadenas de texto y devuelve la más frecuente.');
const lst = ["perro", "gato", "jaguar", "perro", "elefante"];
const mostFrequentData=FrequentString(lst);
console.log("\nValores de salida: \n\n| Cadena mas frecuente | Numero de repeticiones | Acumulador de todos los elementos | \n", mostFrequentData);


// EJERCICIO 14
function PotenciaDeDos(num){
  if(num<1)
  {
      return false;
  }
  while(num > 1)
  {
      if(num % 2 !== 0)
      {
          return false;
      }
      num /= 2;
  }
  return true;
}

console.log('EJERCICIO 14: Escribe una función que tome un número y devuelva verdadero si es una potencia de dos, falso de lo contrario.');
console.log('Número = 4 --> ' + PotenciaDeDos(4));

// EJERCICIO 15
let list = [24, 36, 12, 5, 30, 99, 1];

function descendingArray(array) 
{
    let arraylength = array.length;
    for (let i = 0; i < arraylength - 1; i++) 
    {
      for (let n = i + 1; n < arraylength; n++) 
      {
        if (array[n] > array[i]) 
        {
          let temporal = array[i];
          array[i] = array[n];
          array[n] = temporal;
        }
      }
    }
    return array
  }

console.log('EJERCICIO 15: Escribe una función que tome una lista de números y devuelva una nueva lista con todos los números en orden descendente.');
console.log("Lista desordenada:\n", list);
const orderedList=descendingArray(list);
console.log("Lista ordenada: \n", orderedList); 
