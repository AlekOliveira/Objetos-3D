# Objetos-3D

Implementação de algoritmos de computação gráfica. Este projeto foi totalmente desenvolvido sem o uso de bibliotecas auxiliares para computação gráfica, a primitiva responsável por desenhar os componentes em tela foi implementada seguindo o [algoritmo de bresenham](https://pt.qwe.wiki/wiki/Bresenham%27s_line_algorithm), assim como projeções, sombreamentos e ocultação de faces. O modelo de iluminação está fixo.

**Observação:** Este projeto utiliza apenas a primitiva de bresenham devido ao seu alto desempenho em traçar retas, caso tenha interesse em outras primitivas gráficas de retas e também para circunferências, é só dar uma olhada [neste meu outro repositório.](https://github.com/AlekOliveira/PrimitivasGraficas)

![img](https://user-images.githubusercontent.com/48293550/71787846-57874100-2ffb-11ea-87be-3facd89b761d.png)

### Comandos para manipulação do objeto
- Rotação nos eixos X e Y (Botão esquerdo do mouse)
- Rotação no eixo Z (Clique com o scroll do mouse)
- Escala (Scroll do mouse para cima ou baixo)
- Translaçao (Botão direito do mouse)
- O ponto de iluminação pode ser mudado arrastando o ícone de lâmpada

# Algoritimos utilizados
### Primitiva gráfica
- Bresenham

### Iluminação
- Flat Shading
- Gouraud Shading
- Phong Shading

### Ocultação de faces
- Z-Buffer
- BackFace Culling

### Projeção
- Cabinet
- Cavaleira
- Planar
- 1 Ponto de Fuga





