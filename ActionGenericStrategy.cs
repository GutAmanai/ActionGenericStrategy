
    public enum Operacoes
    {
        OperacaoNome
    }

    public class ActionGenericStrategy
    {
        private static readonly Dictionary<Operacoes, Action> _dicionarioAcoes;

        static ActionGenericStrategy()
        {
            _dicionarioAcoes = new Dictionary<Operacoes, Action>();
            Build();
        }

        public static void Do(Operacoes task, Action action)
        {
            if (!_dicionarioAcoes.ContainsKey(task))
                _dicionarioAcoes[task] = action;
        }

        public static void Execute(Operacoes operacao)
        {

            if (_dicionarioAcoes.ContainsKey(operacao))
            {
                try
                {
                    Action action = _dicionarioAcoes[operacao];
                    action.Invoke();
                }
                catch (Exception ex)
                {
                    // "Erro ao executar {0}.", operacao.ToString()
                }
            }
            else
            {
                // A task {0} não foi executada, pois ela não possui configuração;
            }
        }

        private static void Build()
        {
            Do(Operacoes.OperacaoNome, () =>
            {
              // Adiciona alguma chamada de metodo  
            });
        }