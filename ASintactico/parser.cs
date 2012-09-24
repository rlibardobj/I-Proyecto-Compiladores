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

    //Constructor 
	public parser(Scanner s)
	{
        scanner = s;
	}

   //Acepta el token
    private void accept(int expectedKind)
    {
        try
        {
            if (currentToken.sym == expectedKind)
                currentToken = scanner.next_token();
            else
                printf("Error Sintáctico.Se esperaba " + expectedKind + " pero en su lugar viene: " + currentToken.sym);
        }
        catch (Exception e)
        { }
    }

    //Avanza
    private void acceptit()
    {
        try
        {
            currentToken = scanner.next_token();
        }
        catch (Exception e)
        { }
    }

    //Constructor
    public void parse()
    {
        acceptit(); //obtiene el primer token
        parseProgram();
        if (currentToken.sym != sym.EOF)
           printf("ERROR: Basura al final del archivo");
    }

    public void parseProgram()
    { 
      //palabra class
      if(currentToken.sym == sym.CLASS)
      {
          acceptit();
          accept(sym.ID);
          if ((currentToken.sym == sym.CONST) | (currentToken.sym == sym.ID) |
              (currentToken.sym == sym.CLASS))
          { 
          	parseDecls();
          }
          //Corchete
          accept(sym.CORCHi);
          while((currentToken.sym == sym.VOID) | (currentToken.sym == sym.ID))// | (currentToken.sym == sym.LLAVEd))
          { 
            parseMethodDecl(); //Método Decl
          }         
          accept(sym.CORCHd);
             
      }

    }

    public void parseDecls(){
    	if (currentToken.sym
    }

    public void parseConstDecl()
    {
        accept(sym.CONST);
        parseType();
        accept(sym.ID);
        accept(sym.ASIGN);
        if (currentToken.sym == sym.NUM)
        { 
           accepit();
        }
        else if(currentToken.sym == sym.CHAR)
        {
           accepit();
        }
    
    }

    public void parseVarDecl()
    {
        parseType();
        accept(sym.ID);//ident
        while (currentToken.sym == sym.COMA)
        {
            acceptit(); //acepta coma
            accept(sym.ID);//acepta ident
            accept(sym.PyCOMA);//acepta punto y coma
        
        }
    
    }

    public void parseClassDecl()
    {
        accept(sym.CLASS);
        accept(sym.ID);
        accept(sym.CORCHi);
        while ((currentToken.sym == sym.ID) )//| (currentToken.sym == sym.LLAVEd))
        {
            parseVarDecl();
        }
        accept(sym.CORCHd);
    }

    public void parseMethodDecl()
    {

        if ((currentToken.sym == sym.ID) )//| (currentToken.sym == sym.LLAVEd))
        {
            acceptit();
            accept(sym.ID);
            while(currentToken.sym == sym.PARENi)
            {
                acceptit();
                parseFormPars();
                accept(sym.PARENd);
            }
            while(currentToken.sym == sym.ID)
            {
             parseVarDecl();
            }
            parseBlock();

        }
        else if (currentToken.sym == sym.VOID)
        {
            acceptit();
            accept(sym.ID);
            while (currentToken.sym == sym.PARENi)
            {
                acceptit();
                parseFormPars();
                accept(sym.PARENd);
            }
            while (currentToken.sym == sym.ID)
            {
                parseVarDecl();
            }
            parseBlock();
        
        }
    
    }

    public void parseFormPars()
    {
        parseType();
        accep(sym.ID);
        while (currentToken.sym == sym.COMA)
        {
            acceptit();
            parseType();
            accept(sym.ID);
        }
    }

    public void parseType()
    {
        accept(sym.ID);
        while (currentToken.sym == sym.LLAVEi)
        {
            acceptit();
            accept(sym.LLAVEd);
        }

    }

    //Revizar
    public void parseStatement()
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
          accept(sym.PyComa);
      }
      else if(currentToken.sym == sym.IF)
      {
          acceptit();
          accept(sym.PARENi);
          parseConditional();
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
          parseConditional();
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
          accept(PARENi);
          parseDesignator();
          accept(sym.PARENd);
          accept(sym.PyCOMA);
      }
      else if(currentToken.sym == sym.WRITE) 
      {
          acceptit();
          accept(PARENi);
          parseExpr();
          if (currentToken.sym == sym.COMA)
          {
              acceptit();
              accept(sym.NUM);
          }
          accept(PARENd);
          accept(PyCOMA);
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

    public void parseBlock()
    {
        accept(sym.CORCHi); //Revizar cond while
        while ((currentToken.sym == sym.ID) | (currentToken.sym == sym.IF) | (currentToken.sym == sym.FOR) | (currentToken.sym == sym.WHILE) | (currentToken.sym == sym.BREAK) | (currentToken.sym == sym.RETURN) | (currentToken.sym == sym.READ) | (currentToken.sym == sym.WRITE) | (currentToken.sym == sym.CORCi) | (currentToken.sym == sym.PyCOMA))
        {
            parseStatement();
        }
        accept(sym.CORCHd);
    }

    public void parseActPars()
    {
        parseExpr();
        while (currentToken.sym == sym.COMA)
        {
            acceptit();
            parseExpre();
        }
    
    }

    public void parseCondition()
    {
        parseCondTerm();
        while (currentToken.sym == sym.O)
        {
            acceptit();
            parseCondTerm();
        }
    }

    public void parseCondTerm()
    {
        parseCondFact();
        while (currentToken.sym == sym.Y)
        {
            acceptit();
            parseCondFact();
        }
    }

    public void parseCondFact()
    {
        parseExpr();
        parseRelop();
        parseExpr();
    }

    public void parseExpr()
    {
        if (currentToken.sym == sym.SUB)//Revizar
        {
            acceptit();
        }
        parseTerm(); 
        while ((currentToken.sym == sym.SUM) | (currentToken.sym == sym.SUB))
        {
            acceptit();
            parseTerm();
        }
    }

    public void parseTerm()
    {
        parseFactor();//Revizar modular %
        while ((currentToken.sym == sym.MULT) | (currentToken.sym == sym.DIV) | (currentToken.sym == sym.MOD))
        {
            acceptit();
            parseFactor();
        }    
    }

    public void parseFactor()
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
        { accepit(); }
        else if(currentToken.sym == sym.NEW)
        {
            accepit();
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
            accepit();
            parseExpr();
            accept(sym.PARENd);
        }

    }

    public void parseDesignator()
    {
        accept(sym.ID);
        while (currentToken.sym == sym.PUNTO)
        { 
           accepit();
           if (currentToken.sym == sym.ID)
           {
               acceptit();
           }
           else if (currentToken.sym == sym.LLAVEi)
           {
               accepit();
               parseExpr();
               accept(sym.LLAVEd);
           }
        }
    }


    public void parseRelop()
    {
        if (currentToken.sym == sym.IGUAL) { acceptit(); }
        else if (currentToken.sym == sym.DIST) { acceptit(); }
        else if (currentToken.sym == sym.MAYOR) { accepit(); }
        else if (currentToken.sym == sym.MAYORi) { accepit(); }
        else if (currentToken.sym == sym.MENOR) { accepit(); }
        else if (currentToken.sym == sym.MENORi) { accepit(); }
    }

    public void parseAddop()
    {
        if (currentToken.sym == sym.SUM) { acceptit(); }
        else if (currentToken.sym == sym.SUB) { acceptit(); }
    }

    public void parseMulop()
    {
        if (currentToken.sym == sym.MULT) { acceptit(); }
        else if (currentToken.sym == sym.DIV) { acceptit(); }
        else if (currentToken.sym == sym.MOD
            ) { accepit(); }
    }
}
}
