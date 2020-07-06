using Login_Cadastro.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Cadastro.Modelo
{
    class Controle
    {
        public bool tem;
        public String mensagem = "";
        public bool acessar(String login, String senha)
        {
            LoginDao Dao = new LoginDao();
            tem = Dao.verificarLogin(login, senha);
            
            if (!Dao.mensagem.Equals(""))
            {
                this.mensagem = Dao.mensagem;
            }
            
            return tem;
        }
    
        public String cadastrar(String email,String senha, String ConfSenha)
        {
            LoginDao Dao = new LoginDao();
            this.mensagem = Dao.cadastrar(email, senha, ConfSenha);
            if (Dao.tem)
            {
                this.tem = true;
            }
            return mensagem;
        }

    }
}
