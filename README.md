# API TEAM

Uma para API para cadastrar times de pokemon consumindo o https://pokeapi.co/api/v2/pokemon para obter dados referentes a um pokemon de acordo com seu nome.

## Endpoints

### api/teams - GET

```json
    {
    "1": {
        "owner": "sleao",
        "pokemons": [
        {
            "id": 9,
            "name": "blastoise",
            "weight": 855,
            "height": 16
        },
        {
            "id": 25,
            "name": "pikachu",
            "weight": 60,
            "height": 4
        }
        ]
    },
    "2": {
        "owner": "sleao",
        "pokemons": [
        {
            "id": 9,
            "name": "blastoise",
            "weight": 855,
            "height": 16
        },
        {
            "id": 25,
            "name": "pikachu",
            "weight": 60,
            "height": 4
        },
        {
            "id": 3,
            "name": "venusaur",
            "weight": 1000,
            "height": 20
        },
        {
            "id": 6,
            "name": "charizard",
            "weight": 905,
            "height": 17
        },
        {
            "id": 131,
            "name": "lapras",
            "weight": 2200,
            "height": 25
        },
        {
            "id": 54,
            "name": "psyduck",
            "weight": 196,
            "height": 8
        }
        ]
    }
    }
```

Deverá listar todos os times registrados

###  api/teams/{id} - GET

Busca um time registrado por ID

```json
    {
    "owner": "sleao",
    "pokemons": [
        {
        "id": 9,
        "name": "blastoise",
        "weight": 855,
        "height": 16
        },
        {
        "id": 25,
        "name": "pikachu",
        "weight": 60,
        "height": 4
        }
    ]
    }
```

### api/teams - POST

Rota para criação de um time, que recebe um JSON nesse formato

```json

    {
        "user": "sleao",
        "team": [
            "blastoise",
            "pikachu",
            "charizard",
            "venusaur",
            "lapras",
            "dragonite"
        ]
    }

```