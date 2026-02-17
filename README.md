# 🏀 Projeto de Computação Gráfica -- Quadra de Basquete em VR (Unity)

Projeto desenvolvido para a disciplina de **Computação Gráfica**,
utilizando **Unity (URP)** e voltado para execução em **Meta Quest 3 (VR
Standalone)**.

O objetivo do trabalho é simular um ambiente interativo de treino de
basquete em realidade virtual, explorando conceitos práticos de
renderização, iluminação, física e otimização gráfica.

------------------------------------------------------------------------

## 📌 Descrição do Projeto

O projeto consiste em uma **quadra de basquete 3D interativa em VR**,
contendo:

-   Quadra modelada em ambiente 3D
-   Bola com física realista
-   Sistema de arremesso
-   Colisões e detecção de pontuação
-   Ambiente externo com terreno e vegetação
-   Renderização utilizando **URP (Universal Render Pipeline)**

O foco principal do trabalho foi aplicar conceitos de Computação Gráfica
aliados à otimização para dispositivos VR standalone.

------------------------------------------------------------------------

## 🎯 Objetivos Acadêmicos

O projeto aborda os seguintes conceitos da disciplina:

-   Pipeline de renderização
-   Rasterização
-   Iluminação (baked e realtime)
-   Shadow Mapping
-   Overdraw
-   Batching e Instancing
-   LOD (Level of Detail)
-   Otimização gráfica para hardware móvel
-   Frame budget em aplicações VR

------------------------------------------------------------------------

## 🧠 Desafios Técnicos

Durante o desenvolvimento, o principal desafio foi otimizar o desempenho
para rodar de forma estável no Meta Quest 3, considerando:

-   Renderização dupla (um frame por olho)
-   Limitações de GPU mobile
-   Alto custo de sombras dinâmicas
-   Overdraw causado por transparências (vegetação)
-   Impacto de post-processing em VR

Foram aplicadas estratégias como:

-   Redução de Shadow Distance
-   Uso de iluminação baked/mixed
-   Ajuste de Render Scale
-   Redução de draw calls
-   Compressão de texturas
-   Uso de LODs
-   Desativação de efeitos pesados (SSAO, Motion Blur, etc.)

------------------------------------------------------------------------

## 📦 Arquivos do Repositório

Este repositório contém:

-   `cg.apk` → Build Android pronto para instalação no Meta Quest 3
-   `cg.unitypackage` → Pacote do projeto exportado pela Unity

------------------------------------------------------------------------

## ▶️ Como Executar o APK no Meta Quest 3

1.  Ativar Modo Desenvolvedor no Meta Quest
2.  Conectar o dispositivo via USB
3.  Utilizar ADB para instalar:

``` bash
adb install cg.apk
```

Ou instalar via SideQuest.

------------------------------------------------------------------------

## 🛠 Tecnologias Utilizadas

-   Unity (versão LTS recomendada)
-   Universal Render Pipeline (URP)
-   XR Interaction Toolkit
-   Android Build (IL2CPP / ARM64)

------------------------------------------------------------------------

## ⚙️ Configurações Relevantes de Build

-   Plataforma: Android
-   Arquitetura: ARM64
-   Backend: IL2CPP
-   Render Pipeline: URP
-   XR Plugin: OpenXR

------------------------------------------------------------------------

## 📊 Considerações sobre Performance

Aplicações em VR standalone possuem orçamento de aproximadamente:

-   \~13ms por frame em 72Hz

Como a renderização é feita duas vezes (um olho para cada lente),
qualquer efeito gráfico pesado impacta diretamente na performance.

O projeto foi otimizado para manter estabilidade e responsividade da
física da bola.

------------------------------------------------------------------------

## 👨‍🎓 Autor

Francisco Del'Gaudio

Disciplina: Computação Gráfica\
Instituição: \[Adicionar nome da universidade\]

------------------------------------------------------------------------

## 📄 Observação

Este projeto tem fins acadêmicos e foi desenvolvido exclusivamente como
trabalho da disciplina de Computação Gráfica.
