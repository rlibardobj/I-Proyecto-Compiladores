/*
 * Creado por SharpDevelop.
 * Usuario: rlibardobj
 * Fecha: 07/11/2012
 * Hora: 01:22 p.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;

namespace ASintactico.generacionCodigo
{
	/// <summary>
	/// Description of generadorCodigo.
	/// </summary>
	public class generadorCodigo:Visitor
	{
		
		ModuleBuilder modulo;
		List<Type> parametros;
		List<LocalBuilder> variablesLocales;
		public generadorCodigo()
		{
		}
		
		public object VisitProgramBasicAST(ProgramBasic v,object arg)
		{
			return null;
		}
		
		public object VisitProgramDAST(ProgramDAST v,object arg)
		{
			Type pointType = null;

			AppDomain currentDom = Thread.GetDomain();

			string asmFileName = "compilador.exe";

			AssemblyName myAsmName = new AssemblyName();
			myAsmName.Name = "Ensamblaje";

			AssemblyBuilder myAsmBldr = currentDom.DefineDynamicAssembly(
				myAsmName,
				AssemblyBuilderAccess.RunAndSave);

			modulo = myAsmBldr.DefineDynamicModule(asmFileName,
			                                       asmFileName);

			TypeBuilder act = modulo.DefineType(v.ident.ident.value);
			v.declaraciones.visit(this,act);

			pointType = act.CreateType();

			Console.WriteLine("Tipo Completado");
			
			myAsmBldr.Save(asmFileName);

			Console.WriteLine("Emsamblaje guardado con el nombre '{0}'.", asmFileName);

			return pointType;
		}
		
		public object VisitProgramDMAST(ProgramDMAST v,object arg)
		{
			Type pointType = null;

			AppDomain currentDom = Thread.GetDomain();

			string asmFileName = "compilador.exe";

			AssemblyName myAsmName = new AssemblyName();
			myAsmName.Name = "Ensamblaje";

			AssemblyBuilder myAsmBldr = currentDom.DefineDynamicAssembly(
				myAsmName,
				AssemblyBuilderAccess.RunAndSave);

			modulo = myAsmBldr.DefineDynamicModule(asmFileName,
			                                       asmFileName);

			TypeBuilder act = modulo.DefineType(v.ident.ident.value);
			v.declaraciones.visit(this,act);
			v.metodos.visit(this,act);
			
			pointType = act.CreateType();

			Console.WriteLine("Tipo Completado");
			
			myAsmBldr.Save(asmFileName);

			Console.WriteLine("Emsamblaje guardado con el nombre '{0}'.", asmFileName);

			return pointType;
		}
		
		public object VisitProgramMAST(ProgramMAST v,object arg)
		{
			Type pointType = null;

			AppDomain currentDom = Thread.GetDomain();

			string asmFileName = "compilador.exe";

			AssemblyName myAsmName = new AssemblyName();
			myAsmName.Name = "Ensamblaje";

			AssemblyBuilder myAsmBldr = currentDom.DefineDynamicAssembly(
				myAsmName,
				AssemblyBuilderAccess.RunAndSave);

			modulo = myAsmBldr.DefineDynamicModule(asmFileName,asmFileName);

			TypeBuilder act = modulo.DefineType(v.ident.ident.value);
			v.metodos.visit(this,act);
			
			pointType = act.CreateType();

			Console.WriteLine("Tipo Completado");
			
			myAsmBldr.Save(asmFileName);

			Console.WriteLine("Emsamblaje guardado con el nombre '{0}'.", asmFileName);

			return pointType;
		}
		
		
		//DeclarationsAST
		
		public object VisitUnDeclAST(UnDeclAST v,object arg)
		{
			v.declaracion.visit(this,arg);
			return null;
		}
		
		public object VisitMulDeclAST(MulDeclAST v,object arg)
		{
			v.declaracion.visit(this,arg);
			v.declaraciones.visit(this,arg);
			return null;
		}
		
		
		//DeclarationAST
		
		public object VisitConstDeclAST(ConstDeclAST v,object arg)
		{
			TypeBuilder act=(TypeBuilder)arg;
			string stringtipo=(string)v.tipo.visit(this,arg);
			Type tipo=this.tipo(stringtipo,act);
			act.DefineField(v.value.value,tipo,FieldAttributes.InitOnly);
			return null;
		}
		
		public object VisitClassDeclVAST(ClassDeclVAST v,object arg)
		{
			TypeBuilder tipo=((TypeBuilder)arg).DefineNestedType(v.ident.ident.value);
			v.declaraciones.visit(this,tipo);
			return null;
		}
		
		public object VisitClassDeclBasicAST(ClassDeclBasicAST v,object arg)
		{
			((TypeBuilder)arg).DefineNestedType(v.ident.ident.value);
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
			TypeBuilder act=(TypeBuilder)arg;
			string stringtipo=(string)v.tipo.visit(this,arg);
			Type tipo=this.tipo(stringtipo,act);
			act.DefineField(v.identificador.value,tipo,FieldAttributes.Private);
			return null;
		}
		
		public object VisitMethodDeclFAST(MethodDeclFAST v,object arg)
		{
			TypeBuilder act=(TypeBuilder)arg;
			string stringtipo=(string)v.tipo.visit(this,arg);
			Type tipo=this.tipo(stringtipo,arg);
			v.parametros.visit(this,arg);
			MethodBuilder metodo=act.DefineMethod(v.ident.value,MethodAttributes.Public,tipo,parametros.ToArray());
			parametros.Clear();
			metodo.InitLocals=true;
			ILGenerator constructorMetodo=metodo.GetILGenerator();
			v.bloque.visit(this,constructorMetodo);
			return null;
		}
		
		public object VisitMethodDeclFMAST(MethodDeclFMAST v,object arg)
		{
			TypeBuilder act=(TypeBuilder)arg;
			string stringtipo=(string)v.tipo.visit(this,arg);
			Type tipo=this.tipo(stringtipo,arg);
			v.parametros.visit(this,arg);
			MethodBuilder metodo=act.DefineMethod(v.ident.value,MethodAttributes.Public,tipo,parametros.ToArray());
			parametros.Clear();
			metodo.InitLocals=true;
			ILGenerator constructorMetodo=metodo.GetILGenerator();
			v.declaraciones.visit(this,constructorMetodo);
			v.bloque.visit(this,constructorMetodo);
			return null;
		}
		
		public object VisitMethodDeclMAST(MethodDeclMAST v,object arg)
		{
			TypeBuilder act=(TypeBuilder)arg;
			string stringtipo=(string)v.tipo.visit(this,arg);
			Type tipo=this.tipo(stringtipo,arg);
			MethodBuilder metodo=act.DefineMethod(v.ident.value,MethodAttributes.Public,tipo,null);
			metodo.InitLocals=true;
			ILGenerator constructorMetodo=metodo.GetILGenerator();
			v.declaraciones.visit(this,constructorMetodo);
			v.bloque.visit(this,constructorMetodo);
			return null;
		}
		
		public object VisitMethodDeclBasicAST(MethodDeclBasicAST v,object arg)
		{
			TypeBuilder act=(TypeBuilder)arg;
			string stringtipo=(string)v.tipo.visit(this,arg);
			Type tipo=this.tipo(stringtipo,arg);
			MethodBuilder metodo=act.DefineMethod(v.ident.value,MethodAttributes.Public,tipo,null);
			metodo.InitLocals=true;
			ILGenerator constructorMetodo=metodo.GetILGenerator();
			v.bloque.visit(this,constructorMetodo);
			return null;
		}
		
		
		//TypeAST
		
		public object VisitTypeCAST(TypeCAST v,object arg)
		{
			return v.ident.value;
		}
		
		public object VisitTypeBasicAST(TypeBasicAST v,object arg)
		{
			return v.ident.value;
		}
		
		
		//BlockAST
		
		public object VisitBlockSAST(BlockSAST v,object arg)
		{
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
		
		public object VisitBoolAST(BOOLAST v, object arg)
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
			return false;
		}
		
		public object VisitReturnBasicStatAST(ReturnBasicStatAST v,object arg)
		{
			return false;
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
			parametros.Add(tipo((string)v.tipo.visit(this,arg),arg));
			return null;
		}
		
		public object VisitMulFormParsAST(MulFormParsAST v,object arg)
		{
			v.parametro.visit(this,arg);
			return null;
		}

		public Type tipo(string type, object arg){
			switch(type){
					case "int": {return typeof(int);
						break;}
					case "char": {return typeof(char);
						break;}
					case "bool": {return typeof(bool);
						break;}
				default: 
					{return ((TypeBuilder)arg).GetNestedType(type);
						break;}
			}
			return null;
		}
	}
}
