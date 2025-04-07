document.addEventListener("DOMContentLoaded", function () {
    let perguntas = [
        "Qual é a capital do Brasil?",
        "Quanto é 2 + 2?",
        "Quem pintou a Mona Lisa?"
    ];

    let respostas = new Array(perguntas.length).fill(null);
    let indiceAtual = 0;
    const perguntaEl = document.getElementById("pergunta");
    const opcoesEl = document.getElementById("opcoes");
    
    function getCSRFToken() {
        let cookies = document.cookie.split("; ");
        for (let cookie of cookies) {
            let [name, value] = cookie.split("=");
            if (name === "csrftoken") return value;
        }
        return "";
    }
    
    function carregarPergunta() {
        perguntaEl.innerText = perguntas[indiceAtual];
        opcoesEl.innerHTML = "";

        for (let i = 1; i <= 5; i++) {
            let checked = respostas[indiceAtual] == i ? "checked" : "";
            opcoesEl.innerHTML += `
                <div class="form-check">
                    <input class="form-check-input" type="radio" name="resposta" id="opcao${i}" value="${i}" ${checked}>
                    <label class="form-check-label" for="opcao${i}">${i}</label>
                </div>
            `;
        }

        document.querySelectorAll('input[name="resposta"]').forEach(input => {
            input.addEventListener("change", function () {
                respostas[indiceAtual] = this.value;
            });
        });
    }

    document.getElementById("proximo").addEventListener("click", function () {
        if (indiceAtual < perguntas.length - 1) {
            indiceAtual++;
            carregarPergunta();
        } else {
            fetch("/salvar-respostas/", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                    "X-CSRFToken": getCSRFToken() // Pega o token do input hidden
                },
                body: JSON.stringify({ respostas: respostas })
            })
            .then(response => response.json())
            .then(data => {
                if (data.redirect) {
                    window.location.href = data.redirect;
                }
            });
        }
    });

    document.getElementById("anterior").addEventListener("click", function () {
        if (indiceAtual > 0) {
            indiceAtual--;
            carregarPergunta();
        }
    });

    carregarPergunta();
});
