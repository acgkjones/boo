using System;

namespace Boo.Ast.Impl
{
	[Serializable]
	public abstract class IntegerLiteralExpressionImpl : LiteralExpression
	{
		protected string _value;
		
		protected IntegerLiteralExpressionImpl()
		{
 		}
		
		protected IntegerLiteralExpressionImpl(string value)
		{
 			Value = value;
		}
		
		protected IntegerLiteralExpressionImpl(antlr.Token token, string value) : base(token)
		{
 			Value = value;
		}
		
		internal IntegerLiteralExpressionImpl(antlr.Token token) : base(token)
		{
 		}
		
		internal IntegerLiteralExpressionImpl(Node lexicalInfoProvider) : base(lexicalInfoProvider)
		{
 		}
		
		public override NodeType NodeType
		{
			get
			{
				return NodeType.IntegerLiteralExpression;
			}
		}
		public string Value
		{
			get
			{
				return _value;
			}
			
			set
			{
				
				_value = value;
			}
		}
		public override void Switch(IAstTransformer transformer, out Node resultingNode)
		{
			IntegerLiteralExpression thisNode = (IntegerLiteralExpression)this;
			Expression resultingTypedNode = thisNode;
			transformer.OnIntegerLiteralExpression(thisNode, ref resultingTypedNode);
			resultingNode = resultingTypedNode;
		}
	}
}
