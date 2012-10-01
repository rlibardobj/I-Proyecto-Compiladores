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
	AST raiz;
    private Token currentToken;
    private Scanner scanner;
    public string errores;

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
        	if (currentToken.sym == expectedKind){
                currentToken = scanner.nextToken();
            	errores=errores+currentToken.sym;
        	}
            else{
            	errores=errores+("Error Sintáctico.Se esperaba " + expectedKind + " pero en su lugar viene: " + currentToken.sym +". Linea: "+currentToken.line.ToString()+". Columna: "+currentToken.column.ToString()+ "\n");
            }
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
            errores=errores+currentToken.sym;
        }
        catch (Exception e)
        { }
    }

    //Constructor
    public void parse()
    {
        acceptit(); //obtiene el primer token
        raiz=parseProgram();
        if (currentToken.sym != sym.EOF){
        	errores=errores+"Basura al final del archivo";
        }
    }

    public ProgramAST parseProgram()
    { 
    	errores=errores+"parseProgram";
    	DeclarationsAST declaraciones=null,metodos=null;
    	IDAST id;
    	errores=errores+currentToken.value;
    	errores=errores+currentToken.sym;
    	
         acceptit();
         errores=errores+"prueba";
         id=new IDAST(currentToken.value);
         accept(sym.ID);
         errores=errores+"error";
         if ((currentToken.sym == sym.CONST) | (currentToken.sym == sym.ID) |
             (currentToken.sym == sym.CLASS))
         { 
          declaraciones=parseDecls();
         }
          //Corchete
         accept(sym.LLAVEi);
         while((currentToken.sym == sym.VOID) | (currentToken.sym == sym.ID))// | (currentToken.sym == sym.LLAVEd))
         { 
            metodos=parseDecls(); //Método Decl
         }
         accept(sym.LLAVEd); 
         if (declaraciones!=null){
         	if (metodos!=null){
         		return new ProgramDMAST(declaraciones,metodos,id);
         	}
         	else
         		return new ProgramDAST(declaraciones,id);
         }
         else{
         	if (metodos!=null){
         		return new ProgramMAST(metodos,id);
         	}
         	else
         		return new ProgramBasic(id);
         }
    }

    public DeclarationsAST parseDecls(){
    	Console.WriteLine("parseDecls");
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
    	else if ((currentToken.sym==sym.ID)||(currentToken.sym==sym.VOID)){
    		decl1=parseMethodDecl();
    		resultado=new UnDeclAST(decl1);
    	}
    	while ((currentToken.sym==sym.CONST)|(currentToken.sym==sym.ID)|(currentToken.sym==sym.CLASS)){
    		if (currentToken.sym==sym.CONST){
    			decl2=parseConstDecl();
    			temp=new UnDeclAST(decl2);
    			resultado=new MulDeclAST(temp,resultado);
    		}
    		else if (currentToken.sym==sym.ID){
    			decl2=parseVarDecl();
    			temp=new UnDeclAST(decl2);
    			resultado=new MulDeclAST(temp,resultado);
    		}
    		else if (currentToken.sym==sym.CLASS){
    			decl2=parseClassDecl();
    			temp=new UnDeclAST(decl2);
    			resultado=new MulDeclAST(temp,resultado);
    		}
    		else if ((currentToken.sym==sym.ID)||(currentToken.sym==sym.VOID)){
    			decl2=parseMethodDecl();
    			temp=new UnDeclAST(decl2);
    			resultado=new MulDeclAST(temp,resultado);
    		}
    	}
    	return resultado;
    }

    public DeclarationAST parseConstDecl()
    {
    	Console.WriteLine("parseConstDecl");
    	TypeAST tipo;
        accept(sym.CONST);
        tipo=parseType();
        accept(sym.ID);
        accept(sym.ASIGN);
        if (currentToken.sym == sym.NUM)
        {
        	acceptit();
        	accept(sym.PyCOMA);
        	return new ConstDeclAST(tipo,currentToken.value);
        }
        else if(currentToken.sym == sym.CHAR)
        {
        	acceptit();
        	accept(sym.PyCOMA);
        	return new ConstDeclAST(tipo,currentToken.value);
        }
        return null;
        //adderror    
    }

    public DeclarationAST parseVarDecl()
    {
    	Console.WriteLine("parseVarDecl");
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
    	Console.WriteLine("parseClassDecl");
    	TerminalesAST ident=null;
    	DeclarationsAST declaraciones=null,temp=null;
        accept(sym.CLASS);
        if (currentToken.sym==sym.ID){
        	ident=new IDAST(currentToken.value);
       	}
        acceptit();
        accept(sym.LLAVEi);
        if (currentToken.sym==sym.ID){
        	declaraciones=new UnDeclAST(parseVarDecl());
       	}
        while ((currentToken.sym == sym.ID) )//| (currentToken.sym == sym.LLAVEd))
        {
        	declaraciones=new MulDeclAST (new UnDeclAST(parseVarDecl()),declaraciones);
        }
        accept(sym.LLAVEd);
        if (declaraciones==null){
        	return new ClassDeclBasicAST(ident);
        }
        else
        	return new ClassDeclVAST(declaraciones,ident);
    }

    public DeclarationAST parseMethodDecl()
    {
    	Console.WriteLine("parseMethodDecl");
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
            		return new MethodDeclFMAST(parametros,declaraciones,tipo,ident,bloque);
            	}
            	else{
            		return new MethodDeclFAST(parametros,tipo,ident,bloque);
            	}
            }
            else{
            	if (declaraciones!=null){
            		return new MethodDeclMAST(declaraciones,tipo,ident,bloque);
            	}
            	else{
            		return new MethodDeclBasicAST(tipo,ident,bloque);
            	}
            } 
}

    public FormParsAST parseFormPars()
    {
    	Console.WriteLine("parseFormPars");
    	FormParsAST parametros=null;
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
    	Console.WriteLine("parseType");
    	IDAST ident=null;
    	ident=new IDAST(currentToken.value);
    	accept(sym.ID);
    	if (currentToken.sym == sym.CORCHi){
            acceptit();
            accept(sym.CORCHd);
            return new TypeCAST(ident);
    	}
    	else{
    		return new TypeBasicAST(ident);
      	}
    }
    
    public StatementsAST parseStatements(){
    	Console.WriteLine("parseStatements");
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
    	Console.WriteLine("parseStatement");
      if(currentToken.sym == sym.ID) //Revisar
      {
      	DesignatorAST desig=parseDesignator();
          if (currentToken.sym==sym.ASIGN)
          {
          	acceptit();
            ExprAST expresion=parseExpr();
            accept (sym.PyCOMA);
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
              accept(sym.PyCOMA);
              if (pars==null){
              	return new DesigPStatAST(desig);
              }
              else{
              	return new DesigPAStatAST(desig,pars);
              }
          }
          else if(currentToken.sym == sym.AUM)
          {
          	acceptit();
          	accept(sym.PyCOMA);
          	return new DesigplusStatAST(desig);
          }
          else if(currentToken.sym == sym.DEC)
          {
          	acceptit();
          	accept(sym.PyCOMA);
          	return new DesigminusStatAST(desig);
          }
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
      else if(currentToken.sym == sym.LLAVEi)
      {
      	BlockAST bloque;
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
    	errores=errores+"parseBlock";
    	StatementsAST statements=null;
        accept(sym.LLAVEi); //Revizar cond while
        if ((currentToken.sym == sym.ID) | (currentToken.sym == sym.IF) | (currentToken.sym == sym.FOR) | (currentToken.sym == sym.WHILE) | (currentToken.sym == sym.BREAK) | (currentToken.sym == sym.RETURN) | (currentToken.sym == sym.READ) | (currentToken.sym == sym.WRITE) | (currentToken.sym == sym.CORCHi) | (currentToken.sym == sym.PyCOMA))
        {
            statements=parseStatements();
        }
        accept(sym.LLAVEd);
        if (statements==null){
        	return new BlockBasicAST();
        }
        else{
        	return new BlockSAST(statements);
        }
    }

    public ActParsAST parseActPars()
    {
    	Console.WriteLine("parseActPars");
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
    	Console.WriteLine("parseConditions");
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
    	Console.WriteLine("parseCondTerm");
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
    	Console.WriteLine("parseCondFact");
    	ExprAST expr,expr1;
        expr=parseExpr();
        RELOPAST relop=parseRelop();
        expr1=parseExpr();
        return new ConditionAST(expr,expr1,relop);
    }

    public ExprAST parseExpr()
    {
    	Console.WriteLine("parseExpr");
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
    	Console.WriteLine("parseTerm");
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
    	Console.WriteLine("parseFactor");
        if(currentToken.sym == sym.ID)
        {
        	DesignatorAST desig=parseDesignator();
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
            if (currentToken.sym == sym.CORCHi)
            {
                acceptit();
                expresion=parseExpr();
                accept(sym.CORCHd);
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
    	Console.WriteLine("parseDesignator");
    	DesigAddonsAST addons=null;
    	IDAST id=new IDAST(currentToken.value),ids;
        accept(sym.ID);
        while ((currentToken.sym == sym.PUNTO)||(currentToken.sym==sym.CORCHi))
        { 
           if (currentToken.sym == sym.CORCHi)
           {
           	ExprAST expr;
            acceptit();
            expr=parseExpr();
            accept(sym.CORCHd);
            addons=new MulDesigAddonAST(new UnDesigAddonAST(new ExprAddonAST(expr)),addons);
           }
           else if (currentToken.sym == sym.PUNTO)
           {
           	acceptit();
            ids=new IDAST(currentToken.value);
           	accept(sym.ID);
           	addons=new MulDesigAddonAST(new UnDesigAddonAST(new IDAddonAST(ids)),addons);
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
    	Console.WriteLine("parseADDOP");
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
    	Console.WriteLine("parseRELOP");
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
    	Console.WriteLine("parseMULOP");
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
