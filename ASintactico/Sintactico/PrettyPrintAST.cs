/*
 * Created by SharpDevelop.
 * User: HMSS
 * Date: 30/09/2012
 * Time: 03:49 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;


namespace ASintactico
{
	/// <summary>
	/// Description of PrettyPrintAST.
	/// </summary>
	public class PrettyPrintAST : Visitor
	{
		public String resultado;
		public PrettyPrintAST()
		{
			
		}
		
		
		public void imprimir(AST raiz)
        {
			raiz.visit(this,new int());
        }
		
		
		//Imprime separadores
		public void printtab(int n)
        {
          for(int num=n; num != 0; num--)
          {  resultado = resultado + "+++";
          }
           resultado = resultado + ">";
        }
		
		
		
	 //Métodos para imprimir AST
		
	   
	  //Program
	  public object VisitProgramBasicAST(ProgramBasic v,object arg)
	  { 
	  	//clase vacia, sólo imprime el nombre
	  	resultado = resultado +"\n"+(v.GetType());
	  	return null;
	  }
	  
	  public object VisitProgramDAST(ProgramDAST v,object arg)
	  {	     
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.declaraciones != null)
        v.declaraciones.visit(this,numaux+1);
        else
         {
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	     }
        return null;
	  }
	  
	  public object VisitProgramDMAST(ProgramDMAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
        v.declaraciones.visit(this,numaux+1);
        v.metodos.visit(this,numaux+1);  
	  	return null;
	  }
	  
	  public object VisitProgramMAST(ProgramMAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.metodos != null)
        v.metodos.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
	  	return null;
	  }
	  
	//----------------------------------------------------------------------------------------
	
		//Declarations
	  public object VisitUnDeclAST(UnDeclAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
        v.declaracion.visit(this,numaux+1);
	  	return null;
	  }
	  
	  public object VisitMulDeclAST(MulDeclAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
        v.declaracion.visit(this,numaux+1);
        v.declaraciones.visit(this,numaux+1);  
	  	return null;
	  }
	  
	//----------------------------------------------------------------------------------------  
	  
	    //Declaration
	  public object VisitConstDeclAST(ConstDeclAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType()+" " + v.value);
        v.tipo.visit(this,numaux+1);       
	  	return null;
	  }
	  
	  public object VisitClassDeclVAST(ClassDeclVAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.declaraciones != null)
        v.declaraciones.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
        if(v.ident != null){
        v.ident.visit(this,numaux+1);  
        }
        else{
        printtab(numaux+1);
        resultado = resultado +"\n"+("NULL");
        } 
	  	return null;
	  }
	  
	  public object VisitClassDeclBasicAST(ClassDeclBasicAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.ident != null)
        v.ident.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
	  	return null;
	  }
	  
	  public object VisitDeclMulIDAST(VarDeclMulIDAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.identificador != null)
        v.identificador.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
        if(v.identificadores != null){
        v.identificadores.visit(this,numaux+1);  
        }
        else{
        printtab(numaux+1);
        resultado = resultado +"\n"+("NULL");
        } 
	  	return null;
	  }
	  
	  public object VisitDeclUnIDAST(VarDeclUnIDAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
        v.identificador.visit(this,numaux+1);
        v.tipo.visit(this,numaux+1);  
	  	return null;
	  }
	  
	  public object VisitMethodDeclFAST(MethodDeclFAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.ident != null)
        v.ident.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
        if(v.parametros != null){
        v.parametros.visit(this,numaux+1);  
        }
        else{
        printtab(numaux+1);
        resultado = resultado +"\n"+("NULL");
        }
       if(v.tipo != null){
        v.tipo.visit(this,numaux+1);  
        }
        else{
        printtab(numaux+1);
        resultado = resultado +"\n"+("NULL");
        }        
	  	return null;
	  }
	  
	  public object VisitMethodDeclFMAST(MethodDeclFMAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.declaraciones != null)
        v.declaraciones.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
        if(v.ident != null){
        v.ident.visit(this,numaux+1);  
        }
        else{
        printtab(numaux+1);
        resultado = resultado +"\n"+("NULL");
        } 
        if(v.parametros != null){
        v.parametros.visit(this,numaux+1);  
        }
        else{
        printtab(numaux+1);
        resultado = resultado +"\n"+("NULL");
        }
        if(v.tipo != null){
        v.tipo.visit(this,numaux+1);  
        }
        else{
        printtab(numaux+1);
        resultado = resultado +"\n"+("NULL");
        }
	  	return null;
	  }
	  
	  public object VisitMethodDeclMAST(MethodDeclMAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+ (v.GetType());
                
        if (v.declaraciones != null)
        v.declaraciones.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
        if(v.ident != null){
        v.ident.visit(this,numaux+1);  
        }
        else{
        printtab(numaux+1);
        resultado = resultado +"\n"+("NULL");
        } 
        if(v.tipo != null){
        v.tipo.visit(this,numaux+1);  
        }
        else{
        printtab(numaux+1);
        resultado = resultado +"\n"+("NULL");
        }
        v.bloque.visit(this,numaux+1);
	  	return null;
	  }
	  
	  public object VisitMethodDeclBasicAST(MethodDeclBasicAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.ident != null)
        v.ident.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
        if(v.tipo != null){
        v.tipo.visit(this,numaux+1);  
        }
        else{
        printtab(numaux+1);
        resultado = resultado +"\n"+("NULL");
        } 	  
	  	return null;
	  }
	  
    //----------------------------------------------------------------------------------------
	  
       //Terminales
	  public object VisitIDAST(IDAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +(v.GetType()+". Valor: ");
        resultado = resultado +"\n"+(v.ident);
	  	return null;
	  }
	  
	  public object VisitRELOPAST(RELOPAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +(v.GetType()+". Valor: ");
                
        if (v.value != null)
        	resultado = resultado +"\n"+(v.value);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");       
        }
	  	return null;
	  }
	  
	  public object VisitNUMAST(NUMAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +(v.GetType()+". Valor: ");
                
        if (v.num != null)
        	resultado = resultado +"\n"+(v.num);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
	        }
	  	return null;
	  }
	  
	  public object VisitMULOPAST(MULOPAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +(v.GetType()+". Valor: ");
                
        if (v.value != null)
        	resultado = resultado +"\n"+(v.value);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
	        }
	  	return null;
	  }
	  
	  public object VisitCHARAST(CHARAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +(v.GetType()+". Valor: ");
                
        if (v.car != null)
        	resultado = resultado +"\n"+(v.car);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
	        }
	  	return null;
	  }
	  
	  public object VisitADDOPAST(ADDOPAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +(v.GetType()+". Valor: ");
                
        if (v.value != null)
        	resultado = resultado +"\n"+(v.value);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
	        }
	  	return null;
	  }
	   
    //----------------------------------------------------------------------------------------
	  
	  //FormPars
	  public object VisitUnFormParsAST(UnFormParsAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.ident != null)
        v.ident.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
        if(v.tipo != null){
        v.tipo.visit(this,numaux+1);  
        }
        else{
        printtab(numaux+1);
        resultado = resultado +"\n"+("NULL");
        } 
	  	return null;
	  }
	  
	  public object VisitMulFormParsAST(MulFormParsAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.parametro != null)
        v.parametro.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
        if(v.parametros != null){
        v.parametros.visit(this,numaux+1);  
        }
        else{
        printtab(numaux+1);
        resultado = resultado +"\n"+("NULL");
        } 
	  	return null;
	  }
	  
	 //---------------------------------------------------------------------------------------- 
	  
	    //Type
	  public object VisitTypeCAST(TypeCAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.ident != null)
        v.ident.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
       	return null;
	  }
	  
	  public object VisitTypeBasicAST(TypeBasicAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.ident != null)
        v.ident.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }        
	  	return null;
	  }
	  
	  //----------------------------------------------------------------------------------------
	  
	    //Block
	  public object VisitBlockSAST(BlockSAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.statement != null)
        v.statement.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }        
	  	return null;
	  }
	  
	  public object VisitBlockBasicAST(BlockBasicAST v,object arg)
	  {
	  	//clase vacia
	  	return null;
	  }
	  
	  //----------------------------------------------------------------------------------------
	  
	    //Statements
	  public object VisitUnStatementAST(UnStatementAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.statement != null)
        v.statement.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }       
	  	return null;
	  }
	  
	  public object VisitMulStatementAST(MulStatementAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.statement != null)
        v.statement.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
        if(v.statements != null){
        v.statements.visit(this,numaux+1);  
        }
        else{
        printtab(numaux+1);
        resultado = resultado +"\n"+("NULL");
        } 
	  	return null;
	  }
	  
	  //----------------------------------------------------------------------------------------
	  
	    //Statement
	  public object VisitDesigminusStatAST(DesigminusStatAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.designator != null)
        v.designator.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }        
	  	return null;
	  }
	  
	  public object VisitDesigplusStatAST(DesigplusStatAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.designator != null)
        v.designator.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
	  	return null;
	  }
	  
	  public object VisitReturnEStatAST(ReturnEStatAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.expresion != null)
        v.expresion.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }        
	  	return null;
	  }
	  
	  public object VisitReturnBasicStatAST(ReturnBasicStatAST v,object arg)
	  {
	  	//clase vacia, sólo imprime el nombre
	  	resultado = resultado +"\n"+(v.GetType());
	  	return null;
	  }
	  
	  public object VisitDesigEStatAST(DesigEStatAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.designator != null)
        v.designator.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
        if(v.expresion != null){
        v.expresion.visit(this,numaux+1);  
        }
        else{
        printtab(numaux+1);
        resultado = resultado +"\n"+("NULL");
        } 
	  	return null;
	  }
	  
	  public object VisitDesigPStatAST(DesigPStatAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.designator != null)
        v.designator.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
	  	return null;
	  }
	  
	  public object VisitDesigPAStatAST(DesigPAStatAST v,object arg)
	  {
	    int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.designator != null)
        v.designator.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
        if(v.expresion != null){
        v.expresion.visit(this,numaux+1);  
        }
        else{
        printtab(numaux+1);
        resultado = resultado +"\n"+("NULL");
        } 	
	  	return null;
	  }
	  
	  public object VisitIfElseStatAST(IfElseStatAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.ifstatement != null)
        v.ifstatement.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
        if(v.elsestatement != null){
        v.elsestatement.visit(this,numaux+1);  
        }
        else{
        printtab(numaux+1);
        resultado = resultado +"\n"+("NULL");
        } 
        if(v.condicion != null){
        v.condicion.visit(this,numaux+1);  
        }
        else{
        printtab(numaux+1);
        resultado = resultado +"\n"+("NULL");
        }
	  	return null;
	  }
	  
	  public object VisitIfStatAST(IfStatAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.condicion != null)
        v.condicion.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
        if(v.statement != null){
        v.statement.visit(this,numaux+1);  
        }
        else{
        printtab(numaux+1);
        resultado = resultado +"\n"+("NULL");
        } 
	  	return null;
	  }
	  
	  public object VisitReadStatAST(ReadStatAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.designator != null)
        v.designator.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
	  	return null;
	  }
	  
	  public object VisitWriteStatAST(WriteStatAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.expresion != null)
        v.expresion.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
	  	return null;
	  }
	  
	  public object VisitWriteNStatAST(WriteNStatAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.expresion != null)
        v.expresion.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
        if(v.numero != null){
        v.numero.visit(this,numaux+1);  
        }
        else{
        printtab(numaux+1);
        resultado = resultado +"\n"+("NULL");
        } 
	  	return null;
	  }
	  
	  public object VisitWhileStatAST(WhileStatAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.condicion != null)
        v.condicion.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
        if(v.statement != null){
        v.statement.visit(this,numaux+1);  
        }
        else{
        printtab(numaux+1);
        resultado = resultado +"\n"+("NULL");
        } 
	  	return null;
	  }
	  
	  public object VisitForEStatAST(ForEStatAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.expresion != null)
        v.expresion.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
        if(v.expresion1 != null){
        v.expresion1.visit(this,numaux+1);  
        }
        else{
        printtab(numaux+1);
        resultado = resultado +"\n"+("NULL");
        } 
        if(v.statement != null){
        v.statement.visit(this,numaux+1);  
        }
        else{
        printtab(numaux+1);
        resultado = resultado +"\n"+("NULL");
        } 
	  	return null;
	  }
	  
	  public object VisitForEEStatAST(ForEEStatAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.expresion != null)
        v.expresion.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
        if(v.expresion1 != null){
        v.expresion1.visit(this,numaux+1);  
        }
        else{
        printtab(numaux+1);
        resultado = resultado +"\n"+("NULL");
        } 
        if(v.expresion2 != null){
        v.expresion2.visit(this,numaux+1);  
        }
        else{
        printtab(numaux+1);
        resultado = resultado +"\n"+("NULL");
        } 
        if(v.statement != null){
        v.statement.visit(this,numaux+1);  
        }
        else{
        printtab(numaux+1);
        resultado = resultado +"\n"+("NULL");
        } 
	  	return null;
	  }
	  
	  public object VisitForBasicStatAST(ForBasicStatAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.expresion != null)
        v.expresion.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
        if(v.statement != null){
        v.statement.visit(this,numaux+1);  
        }
        else{
        printtab(numaux+1);
        resultado = resultado +"\n"+("NULL");
        } 
	  	return null;
	  }
	  
	  public object VisitPyComaStatAST(PyComaStatAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.pycoma != null)
        v.pycoma.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
	  	return null;
	  }
	  
	  public object VisitBreakStatAST(BreakStatAST v,object arg)
	  {
	  	//Clase vacia, sólo imprime nombre
	  	resultado = resultado +"\n"+(v.GetType());
	  	return null;
	  }
	  
	  public object VisitBlockStatAST(BlockStatAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.bloque != null)
        v.bloque.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
	  	return null;
	  }
	  
	  //----------------------------------------------------------------------------------------
	  
	    //CondTerm
	  public object VisitUnCondFactAST(UnCondFactAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.condfact != null)
        v.condfact.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
	  	return null;
	  }
	  
	  public object VisitMulCondFactAST(MulCondFactAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.condfact != null)
        v.condfact.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
        if(v.condfacts != null){
        v.condfacts.visit(this,numaux+1);  
        }
        else{
        printtab(numaux+1);
        resultado = resultado +"\n"+("NULL");
        } 
	  	return null;
	  }
	  
	  //----------------------------------------------------------------------------------------
	  
	    //CondFact
	  public object VisitConditionAST(ConditionAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.expr != null)
        v.expr.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
        if(v.expr1 != null){
        v.expr1.visit(this,numaux+1);  
        }
        else{
        printtab(numaux+1);
        resultado = resultado +"\n"+("NULL");
        } 
        if(v.relop != null){
        v.relop.visit(this,numaux+1);  
        }
        else{
        printtab(numaux+1);
        resultado = resultado +"\n"+("NULL");
        } 
	  	return null;
	  }
	  
	  //----------------------------------------------------------------------------------------
	  
	    //Conditions
	  public object VisitUnCondTermAST(UnCondTermAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.condterm != null)
        v.condterm.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
	  	return null;
	  }
	  
	  public object VisitMulCondTermAST(MulCondTermAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.condterm != null)
        v.condterm.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
        if(v.condterms != null){
        v.condterms.visit(this,numaux+1);  
        }
        else{
        printtab(numaux+1);
        resultado = resultado +"\n"+("NULL");
        } 
	  	return null;
	  }
	  
	  //----------------------------------------------------------------------------------------
	  
	    //ActPars
	  public object VisitUnExprAST(UnExprAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.expresion != null)
        v.expresion.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
	  	return null;
	  }
	  public object VisitMulExprAST(MulExprAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.expresion != null)
        v.expresion.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
        if(v.expresiones != null){
        v.expresiones.visit(this,numaux+1);  
        }
        else{
        printtab(numaux+1);
        resultado = resultado +"\n"+("NULL");
        } 
	  	return null;
	  }
	  
	  //----------------------------------------------------------------------------------------
	  
	    //Expr
	  public object VisitMulTermMExprAST(MulTermMExprAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.term != null)
        v.term.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
        if(v.terms != null){
        v.terms.visit(this,numaux+1);  
        }
        else{
        printtab(numaux+1);
        resultado = resultado +"\n"+("NULL");
        } 
	  	return null;
	  }
	  
	  public object VisitMulTermExprAST(MulTermExprAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.term != null)
        v.term.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
        if(v.terms != null){
        v.terms.visit(this,numaux+1);  
        }
        else{
        printtab(numaux+1);
        resultado = resultado +"\n"+("NULL");
        } 
	  	return null;
	  }
	  
	  public object VisitUnTermExprAST(UnTermExprAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.term != null)
        v.term.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
	  	return null;
	  }
	  
	  public object VisitUnTermMExprAST(UnTermMExprAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.term != null)
        v.term.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
	  	return null;
	  }
	  
	  //----------------------------------------------------------------------------------------
	  
	    //Term
	  public object VisitUnFactorAST(UnFactorAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.factor != null)
        v.factor.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
	  	return null;
	  }
	  
	  public object VisitMulFactorAST(MulFactorAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.fac != null)
        v.fac.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
        if(v.facs != null){
        v.facs.visit(this,numaux+1);  
        }
	  	return null;
	  }
	  
	  //----------------------------------------------------------------------------------------
	  
	    //Factor
	  public object VisitCharConstFactorAST(CharConstFactorAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.charconst != null)
        v.charconst.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
	  	return null;
	  }
	  
	  public object VisitNumFactorAST(NumFactorAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.num != null)
        v.num.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
	  	return null;
	  }
	  
	  public object VisitDesigPFactorAST(DesigPFactorAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.desig != null)
        v.desig.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
	  	return null;
	  }
	  
	  public object VisitDesigPAFactorAST(DesigPAFactorAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.desig != null)
        v.desig.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
        if(v.pars != null){
        v.pars.visit(this,numaux+1);  
        }
        else{
        printtab(numaux+1);
        resultado = resultado +"\n"+("NULL");
        } 
	  	return null;
	  }
	  
	  public object VisitDesigBasicFactorAST(DesigBasicFactorAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.desig != null)
        v.desig.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
	  	return null;
	  }
	  
	  public object VisitExprFactorAST(ExprFactorAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.expresion != null)
        v.expresion.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
	  	return null;
	  }
	  
	  public object VisitNewEFactorAST(NewEFactorAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.expresion != null)
        v.expresion.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
        if(v.ident != null){
        v.ident.visit(this,numaux+1);  
        }
        else{
        printtab(numaux+1);
        resultado = resultado +"\n"+("NULL");
        } 
	  	return null;
	  }
	  
	  public object VisitNewBasicFactorAST(NewBasicFactorAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.ident != null)
        v.ident.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
	  	return null;
	  }
	  
      public object VisitBoolFactorAST(BoolFactorAST v,object arg)
      {
      	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.boolf != null)
        v.boolf.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
      	return null;
      }
      
      //----------------------------------------------------------------------------------------
      
	    //Designator
	  public object VisitDesigComplexAST(DesigComplexAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.addon != null)
        v.addon.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
        if(v.ident != null){
        v.ident.visit(this,numaux+1);  
        }
        else{
        printtab(numaux+1);
        resultado = resultado +"\n"+("NULL");
        } 
	  	return null;
	   }
	  
	  public object VisitDesigBasicAST(DesigBasicAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.ident != null)
        v.ident.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
	  	return null;
	  }
	  
	  //----------------------------------------------------------------------------------------
	  
	    //DesigAddons
	  public object VisitMulDesigAddonAST(MulDesigAddonAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.addon != null)
        v.addon.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
        if(v.addons != null){
        v.addons.visit(this,numaux+1);  
        }
        else{
        printtab(numaux+1);
        resultado = resultado +"\n"+("NULL");
        } 
	  	return null;
	  }
	  
	  public object VisitUnDesigAddonAST(UnDesigAddonAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.addon != null)
        v.addon.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }         
	  	return null;
	  }
	  
	  //----------------------------------------------------------------------------------------
	  
	    //DesigAddon
	  public object VisitExprAddonAST(ExprAddonAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.expresion != null)
        v.expresion.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
        return null;
	  }
	  
	  public object VisitIDAddon(IDAddonAST v,object arg)
	  {
	  	int numaux = ((int)arg);
        printtab(numaux);
        resultado = resultado +"\n"+(v.GetType());
                
        if (v.ident != null)
        v.ident.visit(this,numaux+1);
        else{
           printtab(numaux+1);
           resultado = resultado +"\n"+("NULL");
   	    }
	  	return null;
	  }
	  
	  //----------------------------------------------------------------------------------------
	  
	  
         
  }
		
		
}
