using System;

namespace revisao {
  class Program {
    static void Main(string[] args) {
      Aluno[] alunos = new Aluno[5]; // criando um array Aluno de tamanho 5

      var indiceAluno = 0; // iniciando o índice do array Aluno com 0 para incrementar
      string opcaoUsuario = ObterOpcaoUsuario();

      while (opcaoUsuario.ToUpper() != "X") {
        switch (opcaoUsuario) {
          case "1": // adicionando aluno
            Console.Write("Informe o nome do aluno: ");
            var aluno = new Aluno(); // instanciando um objeto do tipo Aluno
            aluno.Nome = Console.ReadLine(); // lendo o aluno digitado

            Console.Write("Informe a nota do aluno: ");

            // se a nota for decimal adiciona a nota, caso contrário entra no throw new
            if (decimal.TryParse(Console.ReadLine(), out decimal nota)) { // convertendo o valor digitado em decimal; 
              aluno.Nota = nota;
            }
            else { // tratando o erro caso seja digitado um valor diferente de decimal - 
              throw new ArgumentException("Valor da nota deve ser decimal");
            }

            alunos[indiceAluno] = aluno;
            indiceAluno++; // incrementando o array Aluno e pulando para a próxima casa do array

            break;
          case "2": // listando alunos
            foreach (var a in alunos) { // para cada aluno a leia o aluno
              if (!string.IsNullOrEmpty(a.Nome)) { // se o Nome do array Aluno não for null, imprime; vai imprimir apenas os dados do array, no qual não for null no Nome
                Console.WriteLine($"ALUNO: {a.Nome} - NOTA: {a.Nota}"); // imprimindo os alunos cadastrado na tela
              }
            }
            break;
          case "3": // calculando média total de alunos
            decimal notaTotal = 0;
            var nrAlunos = 0;

            for (int i = 0; i < alunos.Length; i++) {
              if (!string.IsNullOrEmpty(alunos[i].Nome)) {
                notaTotal = notaTotal + alunos[i].Nota; // somando as notas dos alunos do array
                nrAlunos++; // pegando a quantidade de alunos no array
              }
            }

            var mediaGeral = notaTotal / nrAlunos; // calculando a média das notas dos alunos no array
            Conceito conceitoGeral; // declarando conceitoGeral como o enum Conceito

            // condição para definir o conceito geral conforme a média geral dos alunos
            if (mediaGeral < 2) {
              conceitoGeral = Conceito.E;
            }
            else if (mediaGeral < 4) {
              conceitoGeral = Conceito.D;
            }
            else if (mediaGeral < 6) {
              conceitoGeral = Conceito.C;
            }
            else if (mediaGeral < 8) {
              conceitoGeral = Conceito.B;
            }
            else {
              conceitoGeral = Conceito.A;
            }

            Console.WriteLine($"MÉDIA GERAL: {mediaGeral} - CONCEITO: {conceitoGeral}"); // imprimindo a média geral e o conceito da turma
            break;
        default:
          throw new ArgumentOutOfRangeException(); // exceção caso seja escolhido um valor diferente do menu aprensentado
        }

        opcaoUsuario = ObterOpcaoUsuario();
      }
    }

    private static string ObterOpcaoUsuario() {
      Console.WriteLine();
      Console.WriteLine("Informe a opção desejada:");
      Console.WriteLine("1 - Inserir novo aluno");
      Console.WriteLine("2 - Listar alunos");
      Console.WriteLine("3 - Calcular média geral");
      Console.WriteLine("X - Sair");
      Console.WriteLine();

      string opcaoUsuario = Console.ReadLine();
      Console.WriteLine();

      return opcaoUsuario;
    }
  }
}
