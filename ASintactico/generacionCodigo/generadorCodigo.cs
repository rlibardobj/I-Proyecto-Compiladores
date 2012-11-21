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
		List<TypeBuilder> clases;
		List<FieldBuilder> variables;
		List<MethodBuilder> metodos;
		
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
			variables.Add(act.DefineField(v.value.value,tipo,FieldAttributes.Literal));
			return null;
		}
		
		public object VisitClassDeclVAST(ClassDeclVAST v,object arg)
		{
			TypeBuilder tipo=((TypeBuilder)arg).DefineNestedType(v.ident.ident.value);
			clases.Add(tipo);
			v.declaraciones.visit(this,tipo);
			return null;
		}
		
		public object VisitClassDeclBasicAST(ClassDeclBasicAST v,object arg)
		{
			clases.Add(((TypeBuilder)arg).DefineNestedType(v.ident.ident.value));
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
			variables.Add(act.DefineField(v.identificador.value,tipo,FieldAttributes.Private));
			return null;
		}
		//parametros(F) 
		public object VisitMethodDeclFAST(MethodDeclFAST v,object arg)
		{
			TypeBuilder act=(TypeBuilder)arg;
			string stringtipo=(string)v.tipo.visit(this,arg);
			Type tipo=this.tipo(stringtipo,arg);
			v.parametros.visit(this,arg);
			MethodBuilder metodo=act.DefineMethod(v.ident.value,MethodAttributes.Public,tipo,parametros.ToArray());
			metodos.Add(metodo);
			parametros.Clear();
			metodo.InitLocals=true;
			ILGenerator constructorMetodo=metodo.GetILGenerator();
			v.bloque.visit(this,constructorMetodo);
			return null;
		}
		//parametros(F) y declariones (M)
		public object VisitMethodDeclFMAST(MethodDeclFMAST v,object arg)
		{
			TypeBuilder act=(TypeBuilder)arg;
			string stringtipo=(string)v.tipo.visit(this,arg);
			Type tipo=this.tipo(stringtipo,arg);
			v.parametros.visit(this,arg);
			MethodBuilder metodo=act.DefineMethod(v.ident.value,MethodAttributes.Public,tipo,parametros.ToArray());
			metodos.Add(metodo);
			parametros.Clear();
			metodo.InitLocals=true;
			ILGenerator constructorMetodo=metodo.GetILGenerator();
			v.declaraciones.visit(this,constructorMetodo);
			v.bloque.visit(this,constructorMetodo);
			return null;
		}
		//declariones (M)
		public object VisitMethodDeclMAST(MethodDeclMAST v,object arg)
		{
			TypeBuilder act=(TypeBuilder)arg;
			string stringtipo=(string)v.tipo.visit(this,arg);
			Type tipo=this.tipo(stringtipo,arg);
			MethodBuilder metodo=act.DefineMethod(v.ident.value,MethodAttributes.Public,tipo,null);
			metodos.Add(metodo);
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
			metodos.Add(metodo);
			metodo.InitLocals=true;
			ILGenerator constructorMetodo=metodo.GetILGenerator();
			v.bloque.visit(this,constructorMetodo);
			return null;
		}
		
		
		//TypeAST
		//Type corchetes
		public object VisitTypeCAST(TypeCAST v,object arg)
		{
			return v.ident.value;
		}
		
		public object VisitTypeBasicAST(TypeBasicAST v,object arg)
		{
			return v.ident.value;
		}
		
		
		//BlockAST
        //block statement
		public object VisitBlockSAST(BlockSAST v,object arg)
		{
			v.statement.visit(this,arg);
			return null;
		}
		
		public object VisitBlockBasicAST(BlockBasicAST v,object arg)
		{
			return null;
		}
	    //vacio
		public object VisitDesigBasicFactorAST(DesigBasicFactorAST v,object arg)
		{
			return null;
		}
		//Expresiones entre parentesis
		public object VisitExprFactorAST(ExprFactorAST v,object arg)
		{
			v.expresion.visit(this, arg);
			return null;
		}
		//New ID expresion
		public object VisitNewEFactorAST(NewEFactorAST v,object arg)
		{			
			return null;
		}
		//new id sin expr
		public object VisitNewBasicFactorAST(NewBasicFactorAST v,object arg)
		{
			return null;
		}
		//Bool
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
			foreach (LocalBuilder temp in variablesLocales)
			{
				return temp;
			}
			foreach (FieldBuilder temp in variables)
			{
				if (temp.Name==v.ident.ident.value)
					return temp;
			}
			foreach (MethodBuilder temp in metodos)
			{
				if (temp.Name==v.ident.ident.value)
					return temp;
			}
			foreach (TypeBuilder temp in clases)
			{
				if (temp.Name==v.ident.ident.value)
					return temp;
			}
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
			v.condfact.visit(this,arg);
			return null;
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
			ILGenerator generador=(ILGenerator)arg;
			v.expr.visit(this,arg);
			v.expr1.visit(this,arg);
			switch (v.relop.value.value){
					case "=":{
						generador.Emit(OpCodes.Ceq);
						break;}
					case ">":{
						generador.Emit(OpCodes.Cgt);
						break;}
					case "<":{
						generador.Emit(OpCodes.Clt);
						break;}
					case ">=":{ //2>=1
						generador.Emit(OpCodes.Clt); // 0 a la pila
						generador.Emit(OpCodes.Ldc_I4_0); //meto 0 a la pila (0 es un falso)
						generador.Emit(OpCodes.Ceq); //comparo y si son iguales mete 1 a la pila
						break;}
					case "<=":{
						generador.Emit(OpCodes.Cgt); 
						generador.Emit(OpCodes.Ldc_I4_0);
						generador.Emit(OpCodes.Ceq);
						break;}
			}
			return null;
		}

		
		//----------------------------------------------------------------------------------------
		
		//Conditions
		public object VisitUnCondTermAST(UnCondTermAST v,object arg)
		{
			v.condterm.visit(this,arg);
			return null;
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
			v.expresion.visit(this,arg);
			return null;
		}
		public object VisitMulExprAST(MulExprAST v,object arg)
		{
			v.expresion.visit(this,arg);
			v.expresiones.visit(this,arg);
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
			ILGenerator generador=(ILGenerator)arg;
			generador.Emit(OpCodes.Ldc_I4,v.charconst.car.value);
			return null;
		}
		
		public object VisitNumFactorAST(NumFactorAST v,object arg)
		{
			ILGenerator generador=(ILGenerator)arg;
			generador.Emit(OpCodes.Ldc_I4,int.Parse(v.num.num.value));
			return null;
		}
		
		public object VisitDesigPFactorAST(DesigPFactorAST v,object arg)
		{
			ILGenerator generador=(ILGenerator)arg;
			generador.EmitCall(OpCodes.Call,(MethodBuilder)v.desig.visit(this,arg),null);
			return null;
		}
		
		public object VisitDesigPAFactorAST(DesigPAFactorAST v,object arg)
		{
			ILGenerator generador=(ILGenerator)arg;
			v.pars.visit(this,arg);
			generador.EmitCall(OpCodes.Call,(MethodBuilder)v.desig.visit(this,arg),null);
			return null;
		}
		
		public object VisitUnStatementAST(UnStatementAST v,object arg)
		{
			v.statement.visit(this,arg);
			return null;
		}
		
		public object VisitMulStatementAST(MulStatementAST v,object arg)
		{
			v.statement.visit(this,arg);
			v.statements.visit(this,arg);
			return null;
		}
		
		//----------------------------------------------------------------------------------------
		
		//Statement
		public object VisitDesigminusStatAST(DesigminusStatAST v,object arg)
		{
			ILGenerator generador=(ILGenerator)arg;
			object tipoVariable=v.designator.visit(this,1);
			if(tipoVariable.GetType().Name=="FieldBuilder")
			{
				generador.Emit(OpCodes.Ldc_I4_1);
				generador.Emit(OpCodes.Ldsfld,(FieldBuilder)tipoVariable);
				generador.Emit(OpCodes.Add);
				generador.Emit(OpCodes.Stsfld,(FieldBuilder)tipoVariable);
			}
			else
			{
				generador.Emit(OpCodes.Ldc_I4_1);
				generador.Emit(OpCodes.Ldsfld,(LocalBuilder)tipoVariable);
				generador.Emit(OpCodes.Add);
				generador.Emit(OpCodes.Stsfld,(LocalBuilder)tipoVariable);
			}
			return null;
		}
		
		public object VisitDesigplusStatAST(DesigplusStatAST v,object arg)
		{
			ILGenerator generador=(ILGenerator)arg;
			object tipoVariable=v.designator.visit(this,arg);
			if(tipoVariable.GetType().Name=="FieldBuilder")
			{
				generador.Emit(OpCodes.Ldc_I4_1);
				generador.Emit(OpCodes.Ldsfld,(FieldBuilder)tipoVariable);
				generador.Emit(OpCodes.Add);
				generador.Emit(OpCodes.Stsfld,(FieldBuilder)tipoVariable);
			}
			else
			{
				generador.Emit(OpCodes.Ldc_I4_1);
				generador.Emit(OpCodes.Ldsfld,(LocalBuilder)tipoVariable);
				generador.Emit(OpCodes.Add);
				generador.Emit(OpCodes.Stsfld,(LocalBuilder)tipoVariable);
			}
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
			ILGenerator generador=(ILGenerator)arg;
			Label etiquetaEntrada=generador.DefineLabel(),etiquetaSalida=generador.DefineLabel();
			generador.MarkLabel(etiquetaEntrada);
			v.condicion.visit(this,arg);
			//Salto a etiquetasalida si es false, sino visito statements y despues salto otra vez a entrada
			//codigo del while
			generador.MarkLabel(etiquetaSalida);
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
		
		public object VisitBoolAST(BOOLAST v, object arg)
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
