﻿/*
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
		public tablaSimbolos identificadores,tipos,arreglos;
		public string errores_contextuales;
		public AContextual()
		{
			identificadores=new tablaSimbolos();
			tipos=new tablaSimbolos();
			arreglos=new tablaSimbolos();
		}
		
		
		//ProgramAST
		
		public object VisitProgramBasicAST(ProgramBasic v,object arg)
		{		
			if (identificadores.retrieve(v.ident.ident.value)==null)
			    {
			    	identificadores.enter(v.ident.ident.value,null);
			    }
			    else{
			    	errores_contextuales+="Error Contextual: El identificador \""+v.ident.ident+"\" ya ha sido utilizado.\n";
			    }

			    return null;
		}
		
		public object VisitProgramDAST(ProgramDAST v,object arg)
		{
			if (identificadores.retrieve(v.ident.ident.value)==null)
			    {
			    	identificadores.enter(v.ident.ident.value,null);
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
			if (identificadores.retrieve(v.ident.ident.value)==null)
			    {
			    	identificadores.enter(v.ident.ident.value,null);
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
			if (identificadores.retrieve(v.ident.ident.value)==null)
			    {
			    	identificadores.enter(v.ident.ident.value,null);
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
			string tipo=(string)v.tipo.visit(this,(int)arg);
			v.adornotipo=tipo;
			if (tipo=="char"){
				if(v.value.sym==sym.CHAR){
					identificadores.enter(v.value.value,v);
				}
				else
					errores_contextuales+="Error Contextual: El valor de asignación no corresponde al tipo de la variable.\n";
			}
			else if(tipo=="int"){
				if(v.value.sym==sym.NUM){
					identificadores.enter(v.value.value,v);
				}
				else
					errores_contextuales+="Error Contextual: El valor de asignación no corresponde al tipo de la variable.\n";
			}
			else if(tipo=="float"){
				if(v.value.sym==sym.NUM){
					identificadores.enter(v.value.value,v);
				}
				else
					errores_contextuales+="Error Contextual: El valor de asignación no corresponde al tipo de la variable.\n";
			}
			else{
				errores_contextuales+="Error Contextual: El tipo de la declaración no es válido.\n";
			}
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
			v.expresion.visit(this,(int)arg);
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
			return v.boolf.visit(this,(int)arg);
		}
		
		public object VisitBoolAST(BOOLAST v, object arg)
		{
			return v.value.value;
		}
		
		//----------------------------------------------------------------------------------------
		
		//Designator
		public object VisitDesigComplexAST(DesigComplexAST v,object arg)
		{
			return null;
		}
		
		public object VisitDesigBasicAST(DesigBasicAST v,object arg)
		{
			nodoTabla temp = tipos.retrieve(v.ident.ident.value);
			
			if(temp!=null)
			{
				return temp.declaración;
			}
			else
			{
				errores_contextuales+="Error Contextual: El identificador \""+v.ident+"\" no existe.\n";
				return null;
			}
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
			//Token temp = v.expr.visit();
			// Token temp2 = v.expr1.visit();
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
