# Redes de Petri


## Pseudocódigo inicial:


### Classe Lugar
- atributos
    - marcas
    - marcasNovas

### Classe arco
- atributos 
    - nodo (Lugar) 
    - valor

### Classe Transicao
- atributos 
    - ListaArcosSaida 
    - ListaArcosEntrada
- fn exec
    - Verifica se todos arcos entrada sao válidos - se está enabled - Verificando arcosEntrada
    - Se está enabled, para cada arco de saida, adiciona valor ao "marcasNovas" do seu nodo
        - Isto resolve o problema de executar transições que deveriam ser executadas apenas no próximo ciclo
### Classe RedePetri
- attr 
    - ListaTransicoes
    - ListaLugares
- fn atualizaGrafo
    - Para cada obj na ListaTrancicoes, executar seu método exec()
    - Para todos os lugares, atualizar o "marcas" com o valor de "marcasNovas"
                        

