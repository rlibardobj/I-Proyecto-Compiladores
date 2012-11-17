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
		public tablaSimbolos identificadores,tipos,arreglos,parametros;
		public string errores_contextuales;
		public AContextual()
		{
			identificadores=new tablaSimbolos();
			tipos=new tablaSimbolos();
			arreglos=new tablaSimbolos();
			parametros=new tablaSimbolos();
		}
		
		
		//ProgramAST
		
		public object VisitProgramBasicAST(ProgramBasic v,object arg)
		{
			if (identificadores.retrieve(v.ident.ident.value)==null)
			{
				identificadores.open_scope();
				tipos.open_scope();
				arreglos.open_scope();
				identificadores.enter(v.ident.ident.value,"",null);
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
				identificadores.open_scope();
				tipos.open_scope();
				arreglos.open_scope();
				identificadores.enter(v.ident.ident.value,"",null);
				if(v.declaraciones != null)
				{
					v.declaraciones.visit(this,"programa");
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
				identificadores.open_scope();
				tipos.open_scope();
				arreglos.open_scope();
				identificadores.enter(v.ident.ident.value,"",null);
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
				identificadores.open_scope();
				tipos.open_scope();
				arreglos.open_scope();
				identificadores.enter(v.ident.ident.value,"",null);
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
			if(((string)arg).Equals("clase")){
				v.declaracion.visit(this,"clase");
			}
			else{
				v.declaracion.visit(this,"programa");
			}
			return null;
		}
		
		public object VisitMulDeclAST(MulDeclAST v,object arg)
		{
			if(((string)arg).Equals("clase")){
				v.declaracion.visit(this,"clase");
				v.declaraciones.visit(this,"clase");
			}
			else{
				v.declaracion.visit(this,"programa");
				v.declaraciones.visit(this,"programa");
			}
			return null;
		}
		
		
		//DeclarationAST
		
		public object VisitConstDeclAST(ConstDeclAST v,object arg)
		{
			string tipo=(string)v.tipo.visit(this,(int)arg);
			v.adornotipo=tipo;
			if (tipo=="char"){
				if(v.value.sym==sym.CHAR){
					identificadores.enter(v.value.value,"",v);
				}
				else
					errores_contextuales+="Error Contextual: El valor de asignación no corresponde al tipo de la variable.\n";
			}
			else if(tipo=="int"){
				if(v.value.sym==sym.NUM){
					identificadores.enter(v.value.value,"",v);
				}
				else
					errores_contextuales+="Error Contextual: El valor de asignación no corresponde al tipo de la variable.\n";
			}
			else if(tipo=="float"){
				if(v.value.sym==sym.NUM){
					identificadores.enter(v.value.value,"",v);
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
			if ((identificadores.retrieve(v.ident.ident.value)==null)&&(tipos.retrieve(v.ident.ident.value)==null)
			    &&(arreglos.retrieve(v.ident.ident.value)==null)){
				identificadores.enter(v.ident.ident.value,"",v);
				v.declaraciones.visit(this,"clase");
			}
			else{
				errores_contextuales+="Error Contextual: El identificador \""+v.ident.ident.value+"\" ya ha sido utilizado.\n";
			}
			return null;
		}
		
		public object VisitClassDeclBasicAST(ClassDeclBasicAST v,object arg)
		{
			if ((identificadores.retrieve(v.ident.ident.value)==null)&&(tipos.retrieve(v.ident.ident.value)==null)
			    &&(arreglos.retrieve(v.ident.ident.value)==null)){
				identificadores.enter(v.ident.ident.value,"",v);
			}
			else{
				errores_contextuales+="Error Contextual: El identificador \""+v.ident.ident.value+"\" ya ha sido utilizado.\n";
			}
			return null;
		}
		
		public object VisitDeclMulIDAST(VarDeclMulIDAST v,object arg)
		{
			v.identificador.visit(this,arg);
			v.identificadores.visit(this,arg);
			return null;
		}
		
		public object VisitDeclUnIDAST(VarDeclUnIDAST v,object arg)
		{
			string decision=(string)arg,tipo=(string)v.tipo.visit(this,arg);
			v.adornotipo=tipo;
			if (decision.Equals("clase")){
				if(identificadores.retrieve(v.identificador.value)==null){
					tipos.enter(v.identificador.value,identificadores.primero(),v);
				}
			}
			else{
				if(identificadores.retrieve(v.identificador.value)==null){
					identificadores.enter(v.identificador.value,"",v);
				}
			}
			return null;
		}
		
		public object VisitMethodDeclFAST(MethodDeclFAST v,object arg)
		{
			v.adornotipo=(string)v.tipo.visit(this,(int) arg);
			if ((identificadores.retrieve(v.ident.value)==null)&&(arreglos.retrieve(v.ident.value)==null)){
				identificadores.enter(v.ident.value,"",v);
			}
			else{
				errores_contextuales+="Error Contextual: El identificador \""+v.ident+"\" ya ha sido utilizado.\n";
			}
			identificadores.open_scope();
			v.parametros.visit(this,v.ident.value);
			v.bloque.visit(this,v.adornotipo);
			identificadores.close_scope();
			return null;
		}
		
		public object VisitMethodDeclFMAST(MethodDeclFMAST v,object arg)
		{
			v.adornotipo=(string)v.tipo.visit(this,(int) arg);
			if ((identificadores.retrieve(v.ident.value)==null)&&(arreglos.retrieve(v.ident.value)==null)){
				identificadores.enter(v.ident.value,"",v);
			}
			else{
				errores_contextuales+="Error Contextual: El identificador \""+v.ident+"\" ya ha sido utilizado.\n";
			}
			identificadores.open_scope();
			v.parametros.visit(this,v.ident.value);
			v.declaraciones.visit(this,"programa");
			v.bloque.visit(this,v.adornotipo);
			identificadores.close_scope();
			return null;
		}
		
		public object VisitMethodDeclMAST(MethodDeclMAST v,object arg)
		{
			v.adornotipo=(string)v.tipo.visit(this,(int) arg);
			if ((identificadores.retrieve(v.ident.value)==null)&&(arreglos.retrieve(v.ident.value)==null)){
				identificadores.enter(v.ident.value,"",v);
			}
			else{
				errores_contextuales+="Error Contextual: El identificador \""+v.ident+"\" ya ha sido utilizado.\n";
			}
			identificadores.open_scope();
			v.declaraciones.visit(this,"programa");
			v.bloque.visit(this,v.adornotipo);
			identificadores.close_scope();
			return null;
		}
		
		public object VisitMethodDeclBasicAST(MethodDeclBasicAST v,object arg)
		{
			v.adornotipo=(string)v.tipo.visit(this,(int) arg);
			if ((identificadores.retrieve(v.ident.value)==null)&&(arreglos.retrieve(v.ident.value)==null)){
				identificadores.enter(v.ident.value,"",v);
			}
			else{
				errores_contextuales+="Error Contextual: El identificador \""+v.ident+"\" ya ha sido utilizado.\n";
			}
			identificadores.open_scope();
			v.bloque.visit(this,v.adornotipo);
			identificadores.close_scope();
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
			return v.desig.visit(this,arg);
		}
		
		public object VisitExprFactorAST(ExprFactorAST v,object arg)
		{
			if(((bool)v.expresion.visit(this,arg))){
				return v.expresion.visit(this,arg);
			}
			else {
				errores_contextuales+="Error Contextual: La expresión no es de tipo INT.\n";
			}
			return null;
		}
		
		public object VisitNewEFactorAST(NewEFactorAST v,object arg)
		{
			return null;
		}
		
		public object VisitNewBasicFactorAST(NewBasicFactorAST v,object arg)
		{
			if (tipos.retrieve(v.ident.ident.value)!=null){
				return v.ident.ident.value;
			}
			else{
				errores_contextuales+="Error Contextual: Tipo no encontrado.\n";
			}
			return null;
		}
		
		public object VisitBoolFactorAST(BoolFactorAST v,object arg)
		{
			return v.boolf.value;
		}
		
		public object VisitBoolAST(BOOLAST v, object arg)
		{
			return v.value.value;
		}
		
		//----------------------------------------------------------------------------------------
		
		//Designator
		public object VisitDesigComplexAST(DesigComplexAST v,object arg)
		{
			nodoTabla arreglo=arreglos.retrieve(v.ident.ident.value);
			if (arreglo!=null){
				return arreglo.declaración.visit(this,arg);
			}
			else if(tipos.retrieve(v.ident.ident.value)!=null){
				return v.addon.visit(this,v.ident.ident.value);
			}
			return v.addon.visit(this,arg);
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
			nodoTabla declaracion=tipos.retrieve(v.ident.ident.value,(string)arg);
			if(declaracion!=null){
				return declaracion.declaración;
			}
			else{
				errores_contextuales+="Error Contextual: El identificador \""+v.ident+"\" no existe.\n";
			}
			return null;
		}
		
		public object VisitUnCondFactAST(UnCondFactAST v,object arg)
		{
			return v.condfact.visit(this,arg);
		}
		
		public object VisitMulCondFactAST(MulCondFactAST v,object arg)
		{
			v.condfact.visit(this,arg);
			v.condfacts.visit(this,arg);
			return null;
		}
		
		//----------------------------------------------------------------------------------------
		
		//CondFact
		public object VisitConditionAST(ConditionAST v,object arg)
		{
			string temp = (string)v.expr.visit(this,arg);
			string temp2 = (string)v.expr1.visit(this,arg);
			if(((temp=="int")||(temp=="float"))&&((temp2=="int")||(temp2=="float"))){
				if (temp!=temp2)
					errores_contextuales+="Error Contextual: Tipos Incompatibles.\n";
			}
			return null;
		}

		
		//----------------------------------------------------------------------------------------
		
		//Conditions
		public object VisitUnCondTermAST(UnCondTermAST v,object arg)
		{
			return v.condterm.visit(this,arg);
		}
		
		public object VisitMulCondTermAST(MulCondTermAST v,object arg)
		{
			v.condterm.visit(this,arg);
			v.condterms.visit(this,arg);
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
			string t1=(string)v.term.visit(this,arg),t2=(string)v.terms.visit(this,arg);
			if ((t1==t2)&&((t1=="int")||(t1=="float"))){
				return t1;
			}
			else{
				errores_contextuales+="Error Contextual: Tipos Incompatibles.\n";
			}
			return null;
		}
		
		public object VisitMulTermExprAST(MulTermExprAST v,object arg)
		{
			string t1=(string)v.term.visit(this,arg),t2=(string)v.terms.visit(this,arg);
			if ((t1==t2)&&((t1=="int")||(t1=="float"))){
				return t1;
			}
			else{
				errores_contextuales+="Error Contextual: Tipos Incompatibles.\n";
			}
			return null;
		}
		
		public object VisitUnTermExprAST(UnTermExprAST v,object arg)
		{
			
			return v.term.visit(this,arg);
		}
		
		public object VisitUnTermMExprAST(UnTermMExprAST v,object arg)
		{
			return v.term.visit(this,arg);
		}
		
		//----------------------------------------------------------------------------------------
		
		//Term
		public object VisitUnFactorAST(UnFactorAST v,object arg)
		{
			return (string)v.factor.visit(this,arg);
		}
		
		public object VisitMulFactorAST(MulFactorAST v,object arg)
		{
			string t1=(string)v.fac.visit(this,arg),t2=(string)v.facs.visit(this,arg);
			if ((t1==t2)&&((t1=="int")||(t1=="float"))){
				return t1;
			}
			else{
				errores_contextuales+="Error Contextual: Tipos Incompatibles.\n";
			}
			return null;
		}
		
		//----------------------------------------------------------------------------------------
		
		//Factor
		public object VisitCharConstFactorAST(CharConstFactorAST v,object arg)
		{
			if(v.charconst.car.sym==sym.CHAR){
				return "char";
			}
			return null;
		}
		
		public object VisitNumFactorAST(NumFactorAST v,object arg)
		{
			if(v.num.num.sym==sym.NUM){
				return "int";
			}
			else if(v.num.num.sym==sym.FLOAT){
				return "float";
			}
			return null;
		}
		
		public object VisitDesigPFactorAST(DesigPFactorAST v,object arg)
		{
			return v.desig.visit(this,arg);
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
			if ((string)v.designator.visit(this,arg)=="int"){
				
			}
			else{
				errores_contextuales+="Error Contextual: El identificador no es de tpo int.\n";
			}
			return null;
		}
		
		public object VisitDesigplusStatAST(DesigplusStatAST v,object arg)
		{
			if ((string)v.designator.visit(this,arg)=="int"){
				
			}
			else{
				errores_contextuales+="Error Contextual: El identificador no es de tpo int.\n";
			}
			return null;
		}
		
		public object VisitReturnEStatAST(ReturnEStatAST v,object arg)
		{
			if ((string)v.expresion.visit(this,arg)==(string) arg)
			return true;
			return false;
		}
		
		public object VisitReturnBasicStatAST(ReturnBasicStatAST v,object arg)
		{
			if ((string)arg=="void")
				return true;
			return false;
		}
		
		public object VisitDesigEStatAST(DesigEStatAST v,object arg)
		{
			if ((string)v.designator.visit(this,arg)!=(string)v.expresion.visit(this,arg)){
				errores_contextuales+="Error Contextual: Tipos incompatibles.\n";
				return null;
			}
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
			v.condicion.visit(this,arg);
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
			v.bloque.visit(this,arg);
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
			string metodo=(string)arg;
			identificadores.enter(v.ident.ident.value,"",v);
			parametros.enter(metodo,v.ident.ident.value,v);
			return null;
		}
		
		public object VisitMulFormParsAST(MulFormParsAST v,object arg)
		{
			v.parametro.visit(this,arg);
			v.parametros.visit(this,arg);
			return null;
		}
	}
}
