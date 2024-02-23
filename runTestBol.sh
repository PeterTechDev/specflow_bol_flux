#!/bin/bash

# Loop de 1 a 16 para executar os testes enumerados
for i in {1..16}
do
   echo "Executando teste com a tag @$i"
   dotnet test --filter Category=$i
done
