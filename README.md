# Test_Training
## Restrict: this is simulate production code, so 
 1. CAN'T change signature.
 2. CAN'T make accessibility level from non-public to public

# Project sequence
- 1.XmasChecker
    - for dependency can't control
    - to learn how to deal with DateTime type
- 2.RsaSecureToken
    - learn loose dependency by Interface
    - introduce stub/mock framework (NSubstitute)
    - DI / IoC
- 3.IsolatedByInheritanceAndOverride
    - isolated by inheritance and virtual keyword
    - mock object to verify
- 4.BaseClassCoupling
    - isolated static dependency
    - inheritance override
    - property injection
- 5.AssertionSamples
    - compare object by properties
    - partial compare
    - verify Exceptions
- 6.ServerApiDependency (sum up challenge)
    - remove static dependency
    - knowing inheritance and override to loose coupling
    - mock object for Assersion
    - verify Exceptions by FluentAssertion

tips: 傳入 stub 物件的多種方式，可參考：
--
http://www.dotblogs.com.tw/hatelove/archive/2012/11/27/learning-tdd-in-30-days-day6-several-ways-to-isolate-object-dependency-and-easy-for-testing.aspx

- 1. 透過 target 的 constructor 傳入 interface/abstract 的 instance (DI auto-wiring)
- 2. 透過 target 的 public property 傳入 (DI auto-wiring)
- 3. target 方法的參數 (常看到傳入的參數型別為 interface的那種情況)
- 4. target 將欲 stub 的方法擷取成 protected virtual 方法，使用 繼承 + override 的方式來測試原始target class
