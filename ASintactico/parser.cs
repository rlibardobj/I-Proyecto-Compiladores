/*
 * Created by SharpDevelop.
 * User: HMSS
 * Date: 16/09/2012
 * Time: 10:50 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico{
public class parser
{

    private Token currentToken;
    private Scanner scanner;
    public Errores error;

    //Constructor 
	public parser (Scanner s)
	{
        scanner = s;
	}

   //Acepta el token
    private void accept(int expectedKind)
    {
        try
        {
            if (currentToken.sym == expectedKind)
                currentToken = scanner.nextToken();
            else{
            	
            }
                //printf("Error Sintáctico.Se esperaba " + expectedKind + " pero en su lugar viene: " + currentToken.sym);
        }
        catch (Exception e)
        { }
    }

    //Avanza
    private void acceptit()
    {
        try
        {
            currentToken = scanner.nextToken();
        }
        catch (Exception e)
        { }
    }

    //Constructor
    public void parse()
    {
        acceptit(); //obtiene el primer token
        parseProgram();
        if (currentToken.sym != sym.EOF){
        	
        }
           //printf("ERROR: Basura al final del archivo");
    }

    public ProgramAST parseProgram()
    { 
    	DeclarationsAST declaraciones;
      //palabra class
      if(currentToken.sym == sym.CLASS)
      {
          acceptit();
          accept(sym.ID);
          if ((currentToken.sym == sym.CONST) | (currentToken.sym == sym.ID) |
              (currentToken.sym == sym.CLASS))
          { 
          	declaraciones=parseDecls();
          }
          //Corchete
          accept(sym.CORCHi);
          /*while((currentToken.sym == sym.VOID) | (currentToken.sym == sym.ID))// | (currentToken.sym == sym.LLAVEd))
          { 
            parseMethodDecl(); //Método Decl
          }*/
          accept(sym.CORCHd);
             
      }
      declaraciones=parseDecls();
      return new ProgramDAST(declaraciones);
    }

    public DeclarationsAST parseDecls(){
    	DeclarationsAST resultado=null,temp;
    	DeclarationAST decl1,decl2;
    	if (currentToken.sym==sym.CONST){
    		decl1= parseConstDecl();
    		resultado=new UnDeclAST(decl1);
    	}
    	else if (currentToken.sym==sym.ID){
    		decl1=parseVarDecl();
    		resultado=new UnDeclAST(decl1);
    	}
    	else if (currentToken.sym==sym.CLASS){
    		decl1=parseClassDecl();
    		resultado=new UnDeclAST(decl1);
    	}
    	while ((currentToken.sym==sym.CONST)|(currentToken.sym==sym.ID)|(currentToken.sym==sym.CLASS)){
    		if (currentToken.sym==sym.CONST){
    			decl2=parseConstDecl();
    			temp=new UnDeclAST(decl2);
    			resultado=new MulDeclAST(resultado,temp);
    		}
    		else if (currentToken.sym==sym.ID){
    			decl2=parseVarDecl();
    			temp=new UnDeclAST(decl2);
    			resultado=new MulDeclAST(resultado,temp);
    		}
    		else if (currentToken.sym==sym.CLASS){
    			decl2=parseClassDecl();
    			temp=new UnDeclAST(decl2);
    			resultado=new MulDeclAST(resultado,temp);
    		}
    	}
    	return resultado;
    }

    public DeclarationAST parseConstDecl()
    {
    	TypeAST tipo;
        accept(sym.CONST);
        tipo=parseType();
        accept(sym.ID);
        accept(sym.ASIGN);
        if (currentToken.sym == sym.NUM)
        { 
        	return new ConstDeclAST(tipo,currentToken.value);
        }
        else if(currentToken.sym == sym.CHAR)
        {
        	return new ConstDeclAST(tipo,currentToken.value);
        }
        return null;
        //adderror    
    }

    public DeclarationAST parseVarDecl()
    {
    	DeclarationAST resultado=null, temp=null;
    	TypeAST tipo;
       	tipo= parseType();
       	if (currentToken.sym==sym.ID){
       		resultado=new VarDeclUnIDAST(new IDAST(currentToken.value),tipo);
       	}
       	acceptit();
        while (currentToken.sym == sym.COMA)
        {
            acceptit(); //acepta coma
            if (currentToken.sym==sym.ID){
            	temp=new VarDeclUnIDAST(new IDAST(currentToken.value),tipo);
            }
            resultado=new VarDeclMulIDAST(resultado,temp);
            acceptit();//acepta ident        
        }
        accept(sym.PyCOMA);
		return resultado;        
    }

    public DeclarationAST parseClassDecl()
    {
    	TerminalesAST ident=null;
    	DeclarationsAST declaraciones=null,temp=null;
        accept(sym.CLASS);
        if (currentToken.sym==sym.ID){
        	ident=new IDAST(currentToken.value);
       	}
        acceptit();
        accept(sym.CORCHi);
        if (currentToken.sym==sym.ID){
        	declaraciones=new UnDeclAST(parseVarDecl());
       	}
        while ((currentToken.sym == sym.ID) )//| (currentToken.sym == sym.LLAVEd))
        {
        	declaraciones=new MulDeclAST (new UnDeclAST(parseVarDecl()),declaraciones);
        }
        accept(sym.CORCHd);
        if (declaraciones==null){
        	return new ClassDeclBasicAST(ident);
        }
        else
        	return new ClassDeclVAST(declaraciones,ident);
    }

    public DeclarationAST parseMethodDecl()
    {
    	BlockAST bloque=null;
    	FormParsAST parametros=null;
    	DeclarationsAST declaraciones=null;
    	IDAST ident=null;
    	TypeAST tipo=null;
        if ((currentToken.sym == sym.ID))
        {
        	tipo=parseType();
        }
        else if(currentToken.sym==sym.VOID){
        	tipo=new TypeBasicAST(new IDAST("void"));
        	acceptit();
        }
            if (currentToken.sym==sym.ID){
            	ident=new IDAST(currentToken.value);
       		}
            acceptit();
            accept(sym.PARENi);
            if (currentToken.sym==sym.ID){
            	parametros=parseFormPars();
            }
            accept(sym.PARENd);
            if(currentToken.sym == sym.ID)
            {
            	declaraciones=new UnDeclAST(parseVarDecl());
            }
            while (currentToken.sym == sym.ID)
            {
            	declaraciones=new MulDeclAST(new UnDeclAST(parseVarDecl()),declaraciones);
            }
            bloque=parseBlock();
            if (parametros!=null){
            	if (declaraciones!=null){
            		return new MethodDeclFMAST(parametros,declaraciones,tipo,ident);
            	}
            	else{
            		return new MethodDeclFAST(parametros,tipo,ident);
            	}
            }
            else{
            	if (declaraciones!=null){
            		return new MethodDeclMAST(declaraciones,tipo,ident);
            	}
            	else{
            		return new MethodDeclBasicAST(tipo,ident);
            	}
            } 
}

    public FormParsAST parseFormPars()
    {
    	FormParsAST parametros=null, temp;
    	TypeAST tipo;
    	IDAST ident=null;
        tipo=parseType();
        if (currentToken.sym==sym.ID){
        	ident=new IDAST(currentToken.value);
        	accept(sym.ID);
        	parametros=new UnFormParsAST(ident,tipo);
        }
        while (currentToken.sym == sym.COMA)
        {
            acceptit();
            tipo=parseType();
            if (currentToken.sym==sym.ID){
            	ident=new IDAST(currentToken.value);
        		accept(sym.ID);
            }
            parametros=new MulFormParsAST(new UnFormParsAST(ident,tipo),parametros);
        }
        return parametros;
    }

    public TypeAST parseType()
    {
    	IDAST ident=null;
    	if (currentToken.sym==sym.ID){
    		ident=new IDAST(currentToken.value);
    	}    	
    	if (currentToken.sym == sym.LLAVEi){
            acceptit();
            accept(sym.LLAVEd);
            return new TypeCAST(ident);
    	}
    	else{
    		return new TypeBasicAST(ident);
      	}
    }
    
    public StatementsAST parseStatements(){
    	return null;
    }
    
    public StatementAST parseStatement()
    { 
      if(currentToken.sym == sym.ID) //Revizar
      {
          acceptit();
          accept(sym.ASIGN);
          if(currentToken.sym == sym.EXPR)//Revizar
          {
              parseExpr();
          }
          else if(currentToken.sym == sym.PARENi)
          {
              acceptit();
              if(currentToken.sym == sym.EXPR)//Revizar
              {
               parseActPars();
              }
              accept(sym.PARENd);
          }
          else if(currentToken.sym == sym.AUM)
          {
              acceptit();
          }
          else if(currentToken.sym == sym.DEC)
          {
              acceptit();
          }
          accept(sym.PyCOMA);
      }
      else if(currentToken.sym == sym.IF)
      {
          acceptit();
          accept(sym.PARENi);
          parseConditions();
          accept(sym.PARENd);
          parseStatement();
          if (currentToken.sym == sym.ELSE)
          {
              acceptit();
              parseStatement();
          }
         
      }
      else if(currentToken.sym == sym.FOR) 
      {
          acceptit();
          accept(sym.PARENi);
          parseExpr();
          accept(sym.PyCOMA);
          if (currentToken.sym == sym.EXPR)//Revizar
          {
              parseExpr();
              accept(sym.PyCOMA);
              if (currentToken.sym == sym.EXPR)
              {
                  parseExpr();
              }
          }
          parseStatement();
      }
      else if(currentToken.sym == sym.WHILE) 
      {
          acceptit();
          accept(sym.PARENi);
          parseConditions();
          accept(sym.PARENd);
          parseStatement();
      }
      else if(currentToken.sym == sym.BREAK) 
      {
          acceptit();
          accept(sym.PyCOMA);
      }
      else if(currentToken.sym == sym.RETURN) 
      {
          acceptit();
          if (currentToken.sym == sym.EXPR)//Revizar
          {
              parseExpr();
          }
          accept(sym.PyCOMA);
      }
      else if(currentToken.sym == sym.READ) 
      {
          acceptit();
          accept(sym.PARENi);
          parseDesignator();
          accept(sym.PARENd);
          accept(sym.PyCOMA);
      }
      else if(currentToken.sym == sym.WRITE) 
      {
          acceptit();
          accept(sym.PARENi);
          parseExpr();
          if (currentToken.sym == sym.COMA)
          {
              acceptit();
              accept(sym.NUM);
          }
          accept(sym.PARENd);
          accept(sym.PyCOMA);
      }
      else if((currentToken.sym == sym.CORCHi) | (currentToken.sym == sym.CORCHd))
      {
          acceptit();
          parseBlock();
      }
      else if(currentToken.sym == sym.PyCOMA) 
      {
          acceptit();
      }
    
    }
    
    public BlockAST parseBlock()
    {
    	StatementsAST statements=null;
        accept(sym.CORCHi); //Revizar cond while
        if ((currentToken.sym == sym.ID) | (currentToken.sym == sym.IF) | (currentToken.sym == sym.FOR) | (currentToken.sym == sym.WHILE) | (currentToken.sym == sym.BREAK) | (currentToken.sym == sym.RETURN) | (currentToken.sym == sym.READ) | (currentToken.sym == sym.WRITE) | (currentToken.sym == sym.CORCHi) | (currentToken.sym == sym.PyCOMA))
        {
            statements=parseStatements();
        }
        accept(sym.CORCHd);
        if (statements==null){
        	return new BlockBasicAST();
        }
        else{
        	return new BlockSAST(statements);
        }
    }

    public ActParsAST parseActPars()
    {
    	ActParsAST expres=null;
    	expres=new UnExprAST(parseExpr());
        while (currentToken.sym == sym.COMA)
        {
            acceptit();
            expres=new MulExprAST(new UnExprAST(parseExpr()),expres);
        }
    	return expres;
    }

    public ConditionsAST parseConditions()
    {
    	ConditionsAST cond=null;
    	cond=new UnCondTermAST(parseCondTerm());
        while (currentToken.sym == sym.O)
        {
            acceptit();
            cond=new MulCondTermAST(new UnCondTermAST(parseCondTerm()),cond);
        }
        return cond;
    }

    public CondTermAST parseCondTerm()
    {
    	CondTermAST cond=null;
    	cond=new UnCondFactAST(parseCondFact());
        while (currentToken.sym == sym.Y)
        {
            acceptit();
            cond = new MulCondFactAST(new UnCondFactAST(parseCondFact()),cond);
        }
        return cond;
    }

    public ConditionAST parseCondFact()
    {
    	ExprAST expr,expr1;
        expr=parseExpr();
        RELOPAST relop=parseRelop();
        expr1=parseExpr();
        return new ConditionAST(expr,expr1,relop);
    }

    public ExprAST parseExpr()
    {
        if (currentToken.sym == sym.SUB)//Revisar
        {
            acceptit();
        }
        parseTerm(); 
        while ((currentToken.sym == sym.SUM) | (currentToken.sym == sym.SUB))
        {
            acceptit();
            parseTerm();
        }
        return null;
    }

    public TermAST parseTerm()
    {
        parseFactor();//Revizar modular %
        while ((currentToken.sym == sym.MULT) | (currentToken.sym == sym.DIV) | (currentToken.sym == sym.MOD))
        {
            acceptit();
            parseFactor();
        }   
		return null;        
    }

    public FactorAST parseFactor()
    {
        if(currentToken.sym == sym.ID)
        {
            acceptit();
            if (currentToken.sym == sym.PARENi)
            {
                acceptit();//revizar if
                if ((currentToken.sym == sym.SUB) | (currentToken.sym == sym.ID) | (currentToken.sym == sym.NUM) | (currentToken.sym == sym.CHAR) | (currentToken.sym == sym.TBOOL) | (currentToken.sym == sym.NEW) | (currentToken.sym == sym.PARENi))
                {
                    parseActPars();
                }
                accept(sym.PARENd);
            }
        }
        else if(currentToken.sym == sym.NUM)
        { acceptit(); }
        else if(currentToken.sym == sym.CHAR)
        { acceptit(); }
        else if(currentToken.sym == sym.TBOOL)//Revizar
        { acceptit(); }
        else if(currentToken.sym == sym.NEW)
        {
            acceptit();
            accept(sym.ID);
            if (currentToken.sym == sym.LLAVEi)
            {
                acceptit();
                parseExpr();
                accept(sym.LLAVEd);
            }
        }
        else if(currentToken.sym == sym.PARENi)
        {
            acceptit();
            parseExpr();
            accept(sym.PARENd);
        }
		return null;
    }

    public DesignatorAST parseDesignator()
    {
        accept(sym.ID);
        while (currentToken.sym == sym.PUNTO)
        { 
           acceptit();
           if (currentToken.sym == sym.ID)
           {
               acceptit();
           }
           else if (currentToken.sym == sym.LLAVEi)
           {
               acceptit();
               parseExpr();
               accept(sym.LLAVEd);
           }
        }
        return null;
    }


    public RELOPAST parseRelop()
    {
        if (currentToken.sym == sym.IGUAL) { acceptit(); }
        else if (currentToken.sym == sym.DIST) { acceptit(); }
        else if (currentToken.sym == sym.MAYOR) { acceptit(); }
        else if (currentToken.sym == sym.MAYORi) { acceptit(); }
        else if (currentToken.sym == sym.MENOR) { acceptit(); }
        else if (currentToken.sym == sym.MENORi) { acceptit(); }
        return null;
    }

    public ADDOPAST parseAddop()
    {
        if (currentToken.sym == sym.SUM) { acceptit(); }
        else if (currentToken.sym == sym.SUB) { acceptit(); }
        return null;
    }

    public MULOPAST parseMulop()
    {
        if (currentToken.sym == sym.MULT) { acceptit(); }
        else if (currentToken.sym == sym.DIV) { acceptit(); }
        else if (currentToken.sym == sym.MOD
            ) { acceptit(); }
        return null;
    }
}
}
