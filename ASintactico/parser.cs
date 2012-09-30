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
    	StatementsAST stats=null,temp;
    	StatementAST sta;
    	if ((currentToken.sym==sym.IF)||(currentToken.sym==sym.FOR)||(currentToken.sym==sym.WHILE)||(currentToken.sym==sym.BREAK)
    	    ||(currentToken.sym==sym.READ)||(currentToken.sym==sym.RETURN)||(currentToken.sym==sym.WRITE)||(currentToken.sym==sym.LLAVEi)
    	    ||(currentToken.sym==sym.PyCOMA)||(currentToken.sym==sym.ID)){
    		sta=parseStatement();
    		stats=new UnStatementAST(sta);
    	}
    	while ((currentToken.sym==sym.IF)||(currentToken.sym==sym.FOR)||(currentToken.sym==sym.WHILE)||(currentToken.sym==sym.BREAK)
    	    ||(currentToken.sym==sym.READ)||(currentToken.sym==sym.RETURN)||(currentToken.sym==sym.WRITE)||(currentToken.sym==sym.LLAVEi)
    	    ||(currentToken.sym==sym.PyCOMA)||(currentToken.sym==sym.ID)){
    		sta=parseStatement();
    		stats=new MulStatementAST(new UnStatementAST(sta),stats);
    	}
    	return stats;
    }
    
    public StatementAST parseStatement()
    { 
      if(currentToken.sym == sym.ID) //Revisar
      {
      	DesignatorAST desig=parseDesignator();
          if (currentToken.sym==sym.ASIGN)
          {
          	acceptit();
            ExprAST expresion=parseExpr();
            return new DesigEStatAST(desig,expresion);
          }
          else if(currentToken.sym == sym.PARENi)
          {
              acceptit();
              ActParsAST pars=null;
              if ((currentToken.sym == sym.SUB)||(currentToken.sym==sym.NEW)||(currentToken.sym==sym.PARENi)||(currentToken.sym==sym.CHAR)||
                  (currentToken.sym==sym.NUM)||(currentToken.sym==sym.ID)||(currentToken.sym==sym.TRUE)||(currentToken.sym==sym.FALSE))
              {
               		pars=parseActPars();
              }
              accept(sym.PARENd);
              if (pars==null){
              	return new DesigPStatAST(desig);
              }
              else{
              	return new DesigPAStatAST(desig,pars);
              }
          }
          else if(currentToken.sym == sym.AUM)
          {
          	return new DesigplusStatAST(desig);
          }
          else if(currentToken.sym == sym.DEC)
          {
          	return new DesigminusStatAST(desig);
          }
          accept(sym.PyCOMA);
      }
      else if(currentToken.sym == sym.IF)
      {
      	ConditionsAST cond=null;
      	StatementAST ifsta=null,elsesta=null;
        acceptit();
        accept(sym.PARENi);
        cond=parseConditions();
        accept(sym.PARENd);
        ifsta=parseStatement();
        if (currentToken.sym == sym.ELSE)
        {
            acceptit();
            elsesta=parseStatement();
        }
        if (elsesta!=null){
        	return new IfElseStatAST(ifsta,elsesta,cond);
        }
        else{
        	return new IfStatAST(cond,ifsta);
        }
      }
      else if(currentToken.sym == sym.FOR) 
      {
      	ExprAST expr=null,expr1=null,expr2=null;
      	ConditionsAST cond;
      	StatementAST sta;
         acceptit();
         accept(sym.PARENi);
         expr=parseExpr();
         accept(sym.PyCOMA);
         if ((currentToken.sym == sym.SUB)||(currentToken.sym==sym.NEW)||(currentToken.sym==sym.PARENi)||(currentToken.sym==sym.CHAR)||
             (currentToken.sym==sym.NUM)||(currentToken.sym==sym.ID)||(currentToken.sym==sym.TRUE)||(currentToken.sym==sym.FALSE))
         {
              expr1=parseExpr();
              accept(sym.PyCOMA);
              if ((currentToken.sym == sym.SUB)||(currentToken.sym==sym.NEW)||(currentToken.sym==sym.PARENi)||(currentToken.sym==sym.CHAR)||
                  (currentToken.sym==sym.NUM)||(currentToken.sym==sym.ID)||(currentToken.sym==sym.TRUE)||(currentToken.sym==sym.FALSE))
              {
                  expr2=parseExpr();
              }
          }
          sta=parseStatement();
          if (expr2!=null){
          	return new ForEEStatAST(expr,expr1,expr2,sta);
          }
          else if(expr1!=null){
          	return new ForEStatAST(expr,expr1,sta);
          }
          else
          	return new ForBasicStatAST(expr,sta);
      }
      else if(currentToken.sym == sym.WHILE) 
      {
      	ConditionsAST cond;
      	StatementAST sta;
          acceptit();
          accept(sym.PARENi);
          cond=parseConditions();
          accept(sym.PARENd);
          sta=parseStatement();
          return new WhileStatAST(cond,sta);
      }
      else if(currentToken.sym == sym.BREAK) 
      {
          acceptit();
          accept(sym.PyCOMA);
          return new BreakStatAST();
      }
      else if(currentToken.sym == sym.RETURN) 
      {
      	ExprAST expr=null;
          acceptit();
          if ((currentToken.sym == sym.SUB)||(currentToken.sym==sym.NEW)||(currentToken.sym==sym.PARENi)||(currentToken.sym==sym.CHAR)||
              (currentToken.sym==sym.NUM)||(currentToken.sym==sym.ID)||(currentToken.sym==sym.TRUE)||(currentToken.sym==sym.FALSE))
          {
              expr=parseExpr();
          }
          accept(sym.PyCOMA);
          if (expr!=null){
          	return new ReturnEStatAST(expr);
          }
          else{
          	return new ReturnBasicStatAST();
          }
      }
      else if(currentToken.sym == sym.READ) 
      {
      	DesignatorAST desig;
          acceptit();
          accept(sym.PARENi);
          desig=parseDesignator();
          accept(sym.PARENd);
          accept(sym.PyCOMA);
          return new ReadStatAST(desig);
      }
      else if(currentToken.sym == sym.WRITE) 
      {
      	ExprAST expresion;
      	NUMAST numero=null;
          acceptit();
          accept(sym.PARENi);
          expresion=parseExpr();
          if (currentToken.sym == sym.COMA)
          {
              acceptit();
              if (currentToken.sym==sym.NUM){
              	numero=new NUMAST(currentToken.value);
              }
              accept(sym.NUM);
          }
          accept(sym.PARENd);
          accept(sym.PyCOMA);
          if (numero!=null){
          	return new WriteNStatAST(expresion,numero);
          }
          else
          	return new WriteStatAST(expresion);
      }
      else if(currentToken.sym == sym.CORCHi)
      {
      	BlockAST bloque;
          acceptit();
          bloque=parseBlock();
          return new BlockStatAST(bloque);
      }
      else if(currentToken.sym == sym.PyCOMA) 
      {
          acceptit();
          return new PyComaStatAST(new PyCOMAAST(currentToken.value));
      }
    return null;
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
    	ExprAST resultado=null, temp;
    	TermAST termino;
        if (currentToken.sym == sym.SUB)//Revisar
        {
            acceptit();
            termino=parseTerm();
            resultado=new UnTermMExprAST(termino);
       		while ((currentToken.sym == sym.SUM) | (currentToken.sym == sym.SUB))
        	{
            	acceptit();
            	termino=parseTerm();
            	temp=new UnTermExprAST(termino);
            	resultado=new MulTermMExprAST(temp,resultado);
        	}
       		return resultado;
        }
        else{
        	termino=parseTerm();
        	resultado=new UnTermExprAST(termino);
        	while ((currentToken.sym == sym.SUM) | (currentToken.sym == sym.SUB))
        	{
            	acceptit();
            	termino=parseTerm();
            	temp=new UnTermExprAST(termino);
            	resultado=new MulTermExprAST(temp,resultado);
        	}
        	return resultado;
    	}
    }

    public TermAST parseTerm()
    {
    	TermAST resultado=null,temp;
    	FactorAST factor;
        factor=parseFactor();
        resultado=new UnFactorAST(factor);
        while ((currentToken.sym == sym.MULT) | (currentToken.sym == sym.DIV) | (currentToken.sym == sym.MOD))
        {
            acceptit();
            factor=parseFactor();
            temp=new UnFactorAST(factor);
            resultado=new MulFactorAST(temp,resultado);
        }   
		return resultado;        
    }

    public FactorAST parseFactor()
    {
        if(currentToken.sym == sym.ID)
        {
        	DesignatorAST desig=parseDesignator();
            acceptit();
            if (currentToken.sym == sym.PARENi)
            {
            	ActParsAST pars=null;
                acceptit();
                if ((currentToken.sym == sym.SUB)||(currentToken.sym==sym.NEW)||(currentToken.sym==sym.PARENi)||(currentToken.sym==sym.CHAR)||
              		(currentToken.sym==sym.NUM)||(currentToken.sym==sym.ID)||(currentToken.sym==sym.TRUE)||(currentToken.sym==sym.FALSE))
                {
                    pars=parseActPars();
                }
                accept(sym.PARENd);
                if(pars!=null){
                	return new DesigPAFactorAST(desig,pars);
                }
                else
                	return new DesigPFactorAST(desig);
            }
            else return new DesigBasicFactorAST(desig);
        }
        else if(currentToken.sym == sym.NUM)
        { 
        	NUMAST num = new NUMAST(currentToken.value);
        	acceptit();
        	return new NumFactorAST(num);
        }
        else if(currentToken.sym == sym.CHAR)
        { 
        	CHARAST car = new CHARAST(currentToken.value);
        	acceptit();
        	return new CharConstFactorAST(car);
        }
        else if(currentToken.sym == sym.FALSE)//Revizar
        { 
        	BOOLAST bol = new BOOLAST(currentToken.value);
        	acceptit();
        	return new BoolFactorAST(bol);
        }
        else if(currentToken.sym == sym.TRUE)//Revizar
        { 
        	BOOLAST bol = new BOOLAST(currentToken.value);
        	acceptit();
        	return new BoolFactorAST(bol);
        }
        else if(currentToken.sym == sym.NEW)
        {
        	ExprAST expresion=null;
        	IDAST id;
            acceptit();
            id=new IDAST(currentToken.value);
            accept(sym.ID);
            if (currentToken.sym == sym.LLAVEi)
            {
                acceptit();
                expresion=parseExpr();
                accept(sym.LLAVEd);
            }
            if(expresion!=null){
            	return new NewEFactorAST(expresion,id);
            }
            else
            	return new NewBasicFactorAST(id);
        }
        else if(currentToken.sym == sym.PARENi)
        {
        	ExprAST expresion;
            acceptit();
            expresion=parseExpr();
            accept(sym.PARENd);
            return new ExprFactorAST(expresion);
        }
        return null;
    }

    public DesignatorAST parseDesignator()
    {
    	DesigAddonsAST addons=null;
    	IDAST id=new IDAST(currentToken.value),ids;
        accept(sym.ID);
        while (currentToken.sym == sym.PUNTO)
        { 
           acceptit();
           if (currentToken.sym == sym.ID)
           {
           	ids=new IDAST(currentToken.value);
           	acceptit();
           	addons=new MulDesigAddonAST(new UnDesigAddonAST(new IDAddonAST(ids)),addons);
           }
           else if (currentToken.sym == sym.LLAVEi)
           {
           	ExprAST expr;
               acceptit();
               expr=parseExpr();
               accept(sym.LLAVEd);
               addons=new MulDesigAddonAST(new UnDesigAddonAST(new ExprAddonAST(expr)),addons);
           }
        }
        if (addons!=null){
        	return new DesigComplexAST(addons,id);
        }
        else
        	return new DesigBasicAST(id);
    }


    public ADDOPAST parseAddop()
    {
    	 if (currentToken.sym == sym.SUM) {
    		acceptit();
    		return new ADDOPAST(currentToken.value);
    	}
         else if (currentToken.sym == sym.SUB) { 
    		acceptit();
    		return new ADDOPAST(currentToken.value);
    	}
         return null;

    }

    public RELOPAST parseRelop()
    {
    	 if (currentToken.sym == sym.IGUAL) { 
    		acceptit();
    		return new RELOPAST(currentToken.value);
    	}
        else if (currentToken.sym == sym.DIST) { 
    		acceptit();
    		return new RELOPAST(currentToken.value);
    	}
        else if (currentToken.sym == sym.MAYOR) { 
    		acceptit();
    		return new RELOPAST(currentToken.value);
    	}
        else if (currentToken.sym == sym.MAYORi) { 
    		acceptit(); 
    		return new RELOPAST(currentToken.value);
    	}
        else if (currentToken.sym == sym.MENOR) { 
    		acceptit(); 
    		return new RELOPAST(currentToken.value);
    	}
        else if (currentToken.sym == sym.MENORi) { 
    		acceptit(); 
    		return new RELOPAST(currentToken.value);
    	}
        else if (currentToken.sym == sym.MAYOR) { 
    		acceptit(); 
    		return new RELOPAST(currentToken.value);
    	}
        else if (currentToken.sym == sym.MAYORi) { 
    		acceptit(); 
    		return new RELOPAST(currentToken.value);
    	}
        else if (currentToken.sym == sym.MENOR) { 
    		acceptit(); 
    		return new RELOPAST(currentToken.value);
    	}
        else if (currentToken.sym == sym.MENORi) { 
    		acceptit();
			return new RELOPAST(currentToken.value);    		
    	}
        return null;

    }

    public MULOPAST parseMulop()
    {
    	 if (currentToken.sym == sym.MULT) { 
    		acceptit();
    		return new MULOPAST(currentToken.value);
    	}
        else if (currentToken.sym == sym.DIV) {
    		acceptit(); 
    		return new MULOPAST(currentToken.value);
    	}
        else if (currentToken.sym == sym.MOD) {
    		acceptit(); 
    		return new MULOPAST(currentToken.value);
    	} 
    	return null;

    }
}
}
