# Pokemon
An API which gathers Pokemon data from PokeAPI.

## Endpoints:

1. Obtain Pokemon data at /HTTP/GET /pokemon/<pokemon name>
2. Obtain translated Pokemon data at /HTTP/GET /pokemon/translated/<pokemon name>

## Instructions:
1. Download the Pokemon folder onto a Windows machine
2. Run Pokemon.exe, located in bin\Release\net5.0
3. On a browser, type https://localhost:5001 in the search bar and append the desired endpoint
4. Press Enter

## Production Notes:
Below is a list of things I would have done differently in a production application:
1. Add an authorization method to the translation method to ensure the hourly and daily translation caps are not reached.
2. Add pokemon name validation
3. Add PokeAPI and FunTranslation response validation
4. Add logging
5. Add unit tests for all methods
6. Add integration tests
