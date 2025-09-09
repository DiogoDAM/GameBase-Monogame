import os

def substituir_palavra_em_arquivos(diretorio, extensao, palavra_antiga, palavra_nova):
    for pasta_atual, subpastas, arquivos in os.walk(diretorio):
        for arquivo in arquivos:
            if arquivo.endswith(extensao):
                caminho_arquivo = os.path.join(pasta_atual, arquivo)
                
                # Ler conteúdo
                with open(caminho_arquivo, "r", encoding="utf-8") as f:
                    conteudo = f.read()
                
                # Substituir palavra
                novo_conteudo = conteudo.replace(palavra_antiga, palavra_nova)
                
                # Apenas salvar se houve alteração
                if conteudo != novo_conteudo:
                    with open(caminho_arquivo, "w", encoding="utf-8") as f:
                        f.write(novo_conteudo)
                    
                    print(f"Alterado: {caminho_arquivo}")

if __name__ == "__main__":
    diretorio = input("Digite o caminho do diretório: ")
    extensao = input("Digite a extensão dos arquivos (exemplo: .txt, .py): ")
    palavra_antiga = input("Digite a palavra a ser substituída: ")
    palavra_nova = input("Digite a nova palavra: ")

    substituir_palavra_em_arquivos(diretorio, extensao, palavra_antiga, palavra_nova)
    print("Processo concluído.")

