using System;

namespace Boo.Ast.Impl
{
	[Serializable]
	public abstract class EnumMemberImpl : TypeMember
	{
		protected IntegerLiteralExpression _initializer;
		
		protected EnumMemberImpl()
		{
 		}
		
		protected EnumMemberImpl(IntegerLiteralExpression initializer)
		{
 			Initializer = initializer;
		}
		
		protected EnumMemberImpl(antlr.Token token, IntegerLiteralExpression initializer) : base(token)
		{
 			Initializer = initializer;
		}
		
		internal EnumMemberImpl(antlr.Token token) : base(token)
		{
 		}
		
		internal EnumMemberImpl(Node lexicalInfoProvider) : base(lexicalInfoProvider)
		{
 		}
		
		public override NodeType NodeType
		{
			get
			{
				return NodeType.EnumMember;
			}
		}
		public IntegerLiteralExpression Initializer
		{
			get
			{
				return _initializer;
			}
			
			set
			{
				
				if (_initializer != value)
				{
					_initializer = value;
					if (null != _initializer)
					{
						_initializer.InitializeParent(this);
					}
				}
			}
		}
		public override void Switch(IAstTransformer transformer, out Node resultingNode)
		{
			EnumMember thisNode = (EnumMember)this;
			EnumMember resultingTypedNode = thisNode;
			transformer.OnEnumMember(thisNode, ref resultingTypedNode);
			resultingNode = resultingTypedNode;
		}
	}
}
