简单的按照您的要求弄了一个解决方案:
项目中没有添加AOP的东西：
1：对于AOP我之前有3个解决方案
	a:依赖第三方PostSharp去做AOP编程（引用私有DLL即可）
	b:Unity也支持AOP，比如在web.config中配置接口实现AOP编程去记录日志等功能
	c:MVC+Attribute 其实也是一种AOP编程理念

