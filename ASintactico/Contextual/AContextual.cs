/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 14/10/2012
 * Time: 05:56 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using ASintactico;

namespace AContextual
{
	/// <summary>
	/// Description of Asintactico.
	/// </summary>
	public class AContextual : Visitor
	{
		public tablaSimbolos identificadores,tipos;
		public string errores_contextuales;
		public AContextual()
		{
			identificadores=new tablaSimbolos();
			tipos=new tablaSimbolos();
		}
		
		
		//ProgramAST
		
		public object VisitProgramBasicAST(ProgramBasic v,object arg)
		{
			
			
			if (identificadores.retrieve(v.ident.ident==null)
			    {
			    	identificadores.enter(v.ident.ident,null);
			    }
			    else{
			    	errores_contextuales+="Error Contextual: El identificador \""+v.ident.ident+"\" ya ha sido utilizado.\n";
			    }

			    return null;
		}
		
		public object VisitProgramDAST(ProgramDAST v,object arg)
		{
			if (identificadores.retrieve(v.ident.ident==null)
			    {
			    	identificadores.enter(v.ident.ident,null);
			    	if(v.declaraciones != null)
			    	{
			    		v.declaraciones.visit(this,(int)arg);
			    	}
			    }
			    else{
			    	errores_contextuales+="Error Contextual: El identificador \""+v.ident.ident+"\" ya ha sido utilizado.\n";
			    }
			    return null;
			}
		
		public object VisitProgramDMAST(ProgramDMAST v,object arg)
		{
			if (identificadores.retrieve(v.ident.ident==null)
			    {
			    	identificadores.enter(v.ident.ident,null);
			    	if(v.metodos != null)
			    	{
			    		v.metodos.visit(this,(int)arg);
			    	}
			    	if(v.declaraciones != null)
			    	{
			    		v.declaraciones.visit(this,(int)arg);
			    	}
			    }
			    else{
			    	errores_contextuales+="Error Contextual: El identificador \""+v.ident.ident+"\" ya ha sido utilizado.\n";
			    }			   
			    return null;			    
			}
		
		public object VisitProgramMAST(ProgramMAST v,object arg)
		{
			if (identificadores.retrieve(v.ident.ident==null)
			    {
			    	identificadores.enter(v.ident.ident,null);
			    	if(v.metodos != null)
			    	{
			    		v.metodos.visit(this,(int)arg);
			    	}
			    }
			    else{
			    	errores_contextuales+="Error Contextual: El identificador \""+v.ident.ident+"\" ya ha sido utilizado.\n";
			    }			
			return null;
		}
		
		
		//DeclarationsAST
		
		public object VisitUnDeclAST(UnDeclAST v,object arg)
		{
			v.declaracion.visit(this,(int)arg);
			return null;
		}
		
		public object VisitMulDeclAST(MulDeclAST v,object arg)
		{
			v.declaracion.visit(this,(int)arg);
			v.declaraciones.visit(this,(int)arg);
			return null;
		}
		
		
		//DeclarationAST
		
		public object VisitConstDeclAST(ConstDeclAST v,object arg)
		{
			return null;
		}
		
		public object VisitClassDeclVAST(ClassDeclVAST v,object arg)
		{
			return null;
		}
		
		public object VisitClassDeclBasicAST(ClassDeclBasicAST v,object arg)
		{
			return null;
		}
		
		public object VisitDeclMulIDAST(VarDeclMulIDAST v,object arg)
		{
			return null;
		}
		
		public object VisitDeclUnIDAST(VarDeclUnIDAST v,object arg)
		{
			return null;
		}
		
		public object VisitMethodDeclFAST(MethodDeclFAST v,object arg)
		{
			return null;
		}
		
		public object VisitMethodDeclFMAST(MethodDeclFMAST v,object arg)
		{
			return null;
		}
		
		public object VisitMethodDeclMAST(MethodDeclMAST v,object arg)
		{
			return null;
		}
		
		public object VisitMethodDeclBasicAST(MethodDeclBasicAST v,object arg)
		{
			return null;
		}
		
		
		//TypeAST
		
		public object VisitTypeCAST(TypeCAST v,object arg)
		{
			return v.ident;
		}
		
		public object VisitTypeBasicAST(TypeBasicAST v,object arg)
		{
			return v.ident;
		}
		
		
		//BlockAST
		
		public object VisitBlockSAST(BlockSAST v,object arg)
		{
			v.statement.visit(this,(int)arg);
			return null;
		}
		
		public object VisitBlockBasicAST(BlockBasicAST v,object arg)
		{
			return null;
		}
		
		public object VisitDesigBasicFactorAST(DesigBasicFactorAST v,object arg)
		{
			return null;
		}
		
		public object VisitExprFactorAST(ExprFactorAST v,object arg)
		{
			return null;
		}
		
		public object VisitNewEFactorAST(NewEFactorAST v,object arg)
		{
			return null;
		}
		
		public object VisitNewBasicFactorAST(NewBasicFactorAST v,object arg)
		{
			return null;
		}
		
		public object VisitBoolFactorAST(BoolFactorAST v,object arg)
		{
			return null;
		}
		
		//----------------------------------------------------------------------------------------
		
		//Designator
		public object VisitDesigComplexAST(DesigComplexAST v,object arg)
		{
			return null;
		}
		
		public object VisitDesigBasicAST(DesigBasicAST v,object arg)
		{
			return null;
		}
		
		//----------------------------------------------------------------------------------------
		
		//DesigAddons
		public object VisitMulDesigAddonAST(MulDesigAddonAST v,object arg)
		{
			return null;
		}
		
		public object VisitUnDesigAddonAST(UnDesigAddonAST v,object arg)
		{
			return null;
		}
		
		//----------------------------------------------------------------------------------------
		
		public object VisitExprAddonAST(ExprAddonAST v,object arg)
		{
			return null;
		}
		
		public object VisitIDAddon(IDAddonAST v,object arg)
		{
			return null;
		}
		
		public object VisitUnCondFactAST(UnCondFactAST v,object arg)
		{
			return null;
		}
		
		public object VisitMulCondFactAST(MulCondFactAST v,object arg)
		{
			return null;
		}
		
		//----------------------------------------------------------------------------------------
		
		//CondFact
		public object VisitConditionAST(ConditionAST v,object arg)
		{
			return null;
		}
		
		//----------------------------------------------------------------------------------------
		
		//Conditions
		public object VisitUnCondTermAST(UnCondTermAST v,object arg)
		{
			return null;
		}
		
		public object VisitMulCondTermAST(MulCondTermAST v,object arg)
		{
			return null;
		}
		
		//----------------------------------------------------------------------------------------
		
		//ActPars
		public object VisitUnExprAST(UnExprAST v,object arg)
		{
			return null;
		}
		public object VisitMulExprAST(MulExprAST v,object arg)
		{
			return null;
		}
		
		//----------------------------------------------------------------------------------------
		
		//Expr
		public object VisitMulTermMExprAST(MulTermMExprAST v,object arg)
		{
			return null;
		}
		
		public object VisitMulTermExprAST(MulTermExprAST v,object arg)
		{
			return null;
		}
		
		public object VisitUnTermExprAST(UnTermExprAST v,object arg)
		{
			return null;
		}
		
		public object VisitUnTermMExprAST(UnTermMExprAST v,object arg)
		{
			return null;
		}
		
		//----------------------------------------------------------------------------------------
		
		//Term
		public object VisitUnFactorAST(UnFactorAST v,object arg)
		{
			return null;
		}
		
		public object VisitMulFactorAST(MulFactorAST v,object arg)
		{
			return null;
		}
		
		//----------------------------------------------------------------------------------------
		
		//Factor
		public object VisitCharConstFactorAST(CharConstFactorAST v,object arg)
		{
			return null;
		}
		
		public object VisitNumFactorAST(NumFactorAST v,object arg)
		{
			return null;
		}
		
		public object VisitDesigPFactorAST(DesigPFactorAST v,object arg)
		{
			return null;
		}
		
		public object VisitDesigPAFactorAST(DesigPAFactorAST v,object arg)
		{
			return null;
		}
		
		public object VisitUnStatementAST(UnStatementAST v,object arg)
		{
			return null;
		}
		
		public object VisitMulStatementAST(MulStatementAST v,object arg)
		{
			return null;
		}
		
		//----------------------------------------------------------------------------------------
		
		//Statement
		public object VisitDesigminusStatAST(DesigminusStatAST v,object arg)
		{
			return null;
		}
		
		public object VisitDesigplusStatAST(DesigplusStatAST v,object arg)
		{
			return null;
		}
		
		public object VisitReturnEStatAST(ReturnEStatAST v,object arg)
		{
			return null;
		}
		
		public object VisitReturnBasicStatAST(ReturnBasicStatAST v,object arg)
		{
			return null;
		}
		
		public object VisitDesigEStatAST(DesigEStatAST v,object arg)
		{
			return null;
		}
		
		public object VisitDesigPStatAST(DesigPStatAST v,object arg)
		{
			return null;
		}
		
		public object VisitDesigPAStatAST(DesigPAStatAST v,object arg)
		{
			return null;
		}
		
		public object VisitIfElseStatAST(IfElseStatAST v,object arg)
		{
			return null;
		}
		
		public object VisitIfStatAST(IfStatAST v,object arg)
		{
			return null;
		}
		
		public object VisitReadStatAST(ReadStatAST v,object arg)
		{
			return null;
		}
		
		public object VisitWriteStatAST(WriteStatAST v,object arg)
		{
			return null;
		}
		
		public object VisitWriteNStatAST(WriteNStatAST v,object arg)
		{
			return null;
		}
		
		public object VisitWhileStatAST(WhileStatAST v,object arg)
		{
			return null;
		}
		
		public object VisitForEStatAST(ForEStatAST v,object arg)
		{
			return null;
		}
		
		public object VisitForEEStatAST(ForEEStatAST v,object arg)
		{
			return null;
		}
		
		public object VisitForBasicStatAST(ForBasicStatAST v,object arg)
		{
			return null;
		}
		
		public object VisitPyComaStatAST(PyComaStatAST v,object arg)
		{
			return null;
		}
		
		public object VisitBreakStatAST(BreakStatAST v,object arg)
		{
			return null;
		}
		
		public object VisitBlockStatAST(BlockStatAST v,object arg)
		{
			return null;
		}
		
		public object VisitIDAST(IDAST v,object arg)
		{
			return null;
		}
		
		public object VisitRELOPAST(RELOPAST v,object arg)
		{
			return null;
		}
		
		public object VisitNUMAST(NUMAST v,object arg)
		{
			return null;
		}
		
		public object VisitMULOPAST(MULOPAST v,object arg)
		{
			return null;
		}
		
		public object VisitCHARAST(CHARAST v,object arg)
		{
			return null;
		}
		
		public object VisitADDOPAST(ADDOPAST v,object arg)
		{
			return null;
		}
		
		//----------------------------------------------------------------------------------------
		
		//FormPars
		public object VisitUnFormParsAST(UnFormParsAST v,object arg)
		{
			return null;
		}
		
		public object VisitMulFormParsAST(MulFormParsAST v,object arg)
		{
			return null;
		}
	}
}
