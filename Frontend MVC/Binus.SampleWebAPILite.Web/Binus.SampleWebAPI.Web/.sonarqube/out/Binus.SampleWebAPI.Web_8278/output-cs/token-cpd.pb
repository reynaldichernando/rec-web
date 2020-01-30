å
ùC:\Users\Hendry\Documents\Visual Studio 2015\Projects\WebAPIMVCSample\Binus.SampleWebAPI.Web\Binus.SampleWebAPI.Web\App_Start\BasicAuthenticationAttribute.cs
	namespace 	
Binus
 
. 
SampleWebAPI 
. 
Web  
.  !
	App_Start! *
{ 
public		 

class		 (
BasicAuthenticationAttribute		 -
:		. /!
ActionFilterAttribute		0 E
{

 
public 
override 
void 
OnActionExecuting .
(. /"
ActionExecutingContext/ E
ActionContextF S
)S T
{ 	
if 
( 
ActionContext 
. 
HttpContext )
.) *
Session* 1
[1 2
$str2 >
]> ?
==@ B
nullC G
)G H
{ 
if 
( 
ActionContext !
.! "
HttpContext" -
.- .
Request. 5
.5 6
IsAjaxRequest6 C
(C D
)D E
)E F
{ 
string 
Address "
=# $
ActionContext% 2
.2 3
HttpContext3 >
.> ?
Request? F
.F G
UrlG J
.J K
SchemeK Q
+R S
$strT Y
+Z [
ActionContext\ i
.i j
HttpContextj u
.u v
Requestv }
.} ~
Url	~ Å
.
Å Ç
	Authority
Ç ã
+
å ç
ActionContext
é õ
.
õ ú
HttpContext
ú ß
.
ß ®
Request
® Ø
.
Ø ∞
ApplicationPath
∞ ø
.
ø ¿
TrimEnd
¿ «
(
« »
$char
» À
)
À Ã
;
Ã Õ
ActionContext !
.! "
HttpContext" -
.- .
Response. 6
.6 7

StatusCode7 A
=B C
$numD G
;G H
ActionContext !
.! "
HttpContext" -
.- .
Response. 6
.6 7
Write7 <
(< =
Address= D
+E F
$strG U
)U V
;V W
ActionContext !
.! "
HttpContext" -
.- .
Response. 6
.6 7
End7 :
(: ;
); <
;< =
}   
else!! 
{"" 
ActionContext## !
.##! "
HttpContext##" -
.##- .
Session##. 5
[##5 6
$str##6 C
]##C D
=##E F
ActionContext##G T
.##T U
HttpContext##U `
.##` a
Request##a h
.##h i
Url##i l
.##l m
ToString##m u
(##u v
)##v w
;##w x
ActionContext%% !
.%%! "
Result%%" (
=%%) *
new%%+ .!
RedirectToRouteResult%%/ D
(%%D E
new%%E H 
RouteValueDictionary%%I ]
(%%] ^
new%%^ a
{&& 

controller'' "
=''# $
$str''% ,
,'', -
action(( 
=((  
$str((! (
})) 
))) 
))) 
;)) 
}++ 
}-- 
return00 
;00 
}11 	
}22 
}33 à
çC:\Users\Hendry\Documents\Visual Studio 2015\Projects\WebAPIMVCSample\Binus.SampleWebAPI.Web\Binus.SampleWebAPI.Web\App_Start\BundleConfig.cs
	namespace 	
Binus
 
. 
SampleWebAPI 
. 
Web  
{ 
public 

class 
BundleConfig 
{ 
public		 
static		 
void		 
RegisterBundles		 *
(		* +
BundleCollection		+ ;
bundles		< C
)		C D
{

 	
bundles 
. 
Add 
( 
new 
ScriptBundle (
(( )
$str) ;
); <
.< =
Include= D
(D E
$str ?
)? @
)@ A
;A B
bundles 
. 
Add 
( 
new 
ScriptBundle (
(( )
$str) 9
)9 :
.: ;
Include; B
(B C
$str 2
)2 3
)3 4
;4 5
bundles 
. 
Add 
( 
new 
ScriptBundle (
(( )
$str) >
)> ?
.? @
Include@ G
(G H
$str <
)< =
)= >
;> ?
bundles 
. 
Add 
( 
new 
ScriptBundle (
(( )
$str) >
)> ?
.? @
Include@ G
(G H
$str 7
)7 8
)8 9
;9 :
bundles 
. 
Add 
( 
new 
ScriptBundle (
(( )
$str) >
)> ?
.? @
Include@ G
(G H
$str 6
,6 7
$str 4
)4 5
)5 6
;6 7
bundles 
. 
Add 
( 
new 
StyleBundle '
(' (
$str( 7
)7 8
.8 9
Include9 @
(@ A
$str 3
,3 4
$str ;
,; <
$str .
). /
)/ 0
;0 1
}   	
}!! 
}"" É1
ëC:\Users\Hendry\Documents\Visual Studio 2015\Projects\WebAPIMVCSample\Binus.SampleWebAPI.Web\Binus.SampleWebAPI.Web\App_Start\CustomViewEngine.cs
	namespace 	
Binus
 
. 
SampleWebAPI 
. 
Web  
.  !
	App_Start! *
{ 
public 

class 
CustomViewEngine !
:" #
RazorViewEngine$ 3
{ 
public		 
CustomViewEngine		 
(		  
)		  !
{

 	
var 
viewLocations 
= 
new  #
[# $
]$ %
{& '
$str $
,$ %
$str '
,' (
$str *
,* +
} 
; 
this 
. &
PartialViewLocationFormats +
=, -
viewLocations. ;
;; <
this 
. 
ViewLocationFormats $
=% &
viewLocations' 4
;4 5
} 	
	protected 
override 
IView  
CreatePartialView! 2
(2 3
ControllerContext3 D
ControllerContextE V
,V W
stringX ^
PartialPath_ j
)j k
{ 	
var 
SiteCode 
= 
GeValue "
(" #
ControllerContext# 4
)4 5
;5 6
return 
base 
. 
CreatePartialView )
() *
ControllerContext* ;
,; <
PartialPath= H
.H I
ReplaceI P
(P Q
$strQ U
,U V
SiteCodeW _
[_ `
$num` a
]a b
)b c
.c d
Replaced k
(k l
$strl p
,p q
SiteCoder z
[z {
$num{ |
]| }
)} ~
)~ 
;	 Ä
} 	
	protected 
override 
IView  

CreateView! +
(+ ,
ControllerContext, =
ControllerContext> O
,O P
stringQ W
ViewPathX `
,` a
stringb h

MasterPathi s
)s t
{ 	
var   
SiteCode   
=   
GeValue   "
(  " #
ControllerContext  # 4
)  4 5
;  5 6
return!! 
base!! 
.!! 

CreateView!! "
(!!" #
ControllerContext!!# 4
,!!4 5
ViewPath!!6 >
.!!> ?
Replace!!? F
(!!F G
$str!!G K
,!!K L
SiteCode!!M U
[!!U V
$num!!V W
]!!W X
)!!X Y
.!!Y Z
Replace!!Z a
(!!a b
$str!!b f
,!!f g
SiteCode!!h p
[!!p q
$num!!q r
]!!r s
)!!s t
,!!t u

MasterPath	!!v Ä
.
!!Ä Å
Replace
!!Å à
(
!!à â
$str
!!â ç
,
!!ç é
SiteCode
!!è ó
[
!!ó ò
$num
!!ò ô
]
!!ô ö
)
!!ö õ
.
!!õ ú
Replace
!!ú £
(
!!£ §
$str
!!§ ®
,
!!® ©
SiteCode
!!™ ≤
[
!!≤ ≥
$num
!!≥ ¥
]
!!¥ µ
)
!!µ ∂
)
!!∂ ∑
;
!!∑ ∏
}"" 	
	protected%% 
override%% 
bool%% 

FileExists%%  *
(%%* +
ControllerContext%%+ <
ControllerContext%%= N
,%%N O
string%%P V
VirtualPath%%W b
)%%b c
{&& 	
var'' 
SiteCode'' 
='' 
GeValue'' "
(''" #
ControllerContext''# 4
)''4 5
;''5 6
return(( 
base(( 
.(( 

FileExists(( "
(((" #
ControllerContext((# 4
,((4 5
VirtualPath((6 A
.((A B
Replace((B I
(((I J
$str((J N
,((N O
SiteCode((P X
[((X Y
$num((Y Z
]((Z [
)(([ \
.((\ ]
Replace((] d
(((d e
$str((e i
,((i j
SiteCode((k s
[((s t
$num((t u
]((u v
)((v w
)((w x
;((x y
})) 	
private++ 
static++ 
string++ 
[++ 
]++ 
GeValue++  '
(++' (
ControllerContext++( 9
ControllerContext++: K
)++K L
{,, 	
var.. 

Controller.. 
=.. 
ControllerContext.. .
.... /

Controller../ 9
;..9 :
var// 
Result// 
=// 
ControllerContext// *
.//* +
	RouteData//+ 4
;//4 5
string00 
[00 
]00 

ReturnData00 
=00  !
new00" %
string00& ,
[00, -
$num00- .
]00. /
;00/ 0
String11 
[11 
]11 
	Namespace11 
=11  

Controller11! +
.11+ ,
ToString11, 4
(114 5
)115 6
.116 7
Split117 <
(11< =
$str11= @
.11@ A
ToCharArray11A L
(11L M
)11M N
)11N O
;11O P

ReturnData33 
[33 
$num33 
]33 
=33 
	Namespace33 %
[33% &
(33& '
	Namespace33' 0
.330 1
Count331 6
(336 7
)337 8
-338 9
$num339 :
)33: ;
]33; <
.33< =
ToString33= E
(33E F
)33F G
;33G H

ReturnData44 
[44 
$num44 
]44 
=44 
	Namespace44 %
[44% &
(44& '
	Namespace44' 0
.440 1
Count441 6
(446 7
)447 8
-448 9
$num449 :
)44: ;
]44; <
.44< =
ToString44= E
(44E F
)44F G
;44G H
return@@ 

ReturnData@@ 
;@@ 
}AA 	
}BB 
}CC ˇ
çC:\Users\Hendry\Documents\Visual Studio 2015\Projects\WebAPIMVCSample\Binus.SampleWebAPI.Web\Binus.SampleWebAPI.Web\App_Start\FilterConfig.cs
	namespace 	
Binus
 
. 
SampleWebAPI 
. 
Web  
{ 
public 

class 
FilterConfig 
{ 
public 
static 
void !
RegisterGlobalFilters 0
(0 1"
GlobalFilterCollection1 G
filtersH O
)O P
{		 	
filters

 
.

 
Add

 
(

 
new

  
HandleErrorAttribute

 0
(

0 1
)

1 2
)

2 3
;

3 4
} 	
} 
} ø;
èC:\Users\Hendry\Documents\Visual Studio 2015\Projects\WebAPIMVCSample\Binus.SampleWebAPI.Web\Binus.SampleWebAPI.Web\App_Start\IdentityConfig.cs
	namespace 	
Binus
 
. 
SampleWebAPI 
. 
Web  
{ 
public 

class 
EmailService 
: #
IIdentityMessageService  7
{ 
public 
Task 
	SendAsync 
( 
IdentityMessage -
message. 5
)5 6
{ 	
return 
Task 
. 

FromResult "
(" #
$num# $
)$ %
;% &
} 	
} 
public 

class 

SmsService 
: #
IIdentityMessageService 5
{ 
public 
Task 
	SendAsync 
( 
IdentityMessage -
message. 5
)5 6
{ 	
return 
Task 
. 

FromResult "
(" #
$num# $
)$ %
;% &
}   	
}!! 
public$$ 

class$$ "
ApplicationUserManager$$ '
:$$( )
UserManager$$* 5
<$$5 6
ApplicationUser$$6 E
>$$E F
{%% 
public&& "
ApplicationUserManager&& %
(&&% &

IUserStore&&& 0
<&&0 1
ApplicationUser&&1 @
>&&@ A
store&&B G
)&&G H
:'' 
base'' 
('' 
store'' 
)'' 
{(( 	
})) 	
public++ 
static++ "
ApplicationUserManager++ ,
Create++- 3
(++3 4"
IdentityFactoryOptions++4 J
<++J K"
ApplicationUserManager++K a
>++a b
options++c j
,++j k
IOwinContext++l x
context	++y Ä
)
++Ä Å
{,, 	
var-- 
manager-- 
=-- 
new-- "
ApplicationUserManager-- 4
(--4 5
new--5 8
	UserStore--9 B
<--B C
ApplicationUser--C R
>--R S
(--S T
context--T [
.--[ \
Get--\ _
<--_ ` 
ApplicationDbContext--` t
>--t u
(--u v
)--v w
)--w x
)--x y
;--y z
manager// 
.// 
UserValidator// !
=//" #
new//$ '
UserValidator//( 5
<//5 6
ApplicationUser//6 E
>//E F
(//F G
manager//G N
)//N O
{00 *
AllowOnlyAlphanumericUserNames11 .
=11/ 0
false111 6
,116 7
RequireUniqueEmail22 "
=22# $
true22% )
}33 
;33 
manager66 
.66 
PasswordValidator66 %
=66& '
new66( +
PasswordValidator66, =
{77 
RequiredLength88 
=88  
$num88! "
,88" ##
RequireNonLetterOrDigit99 '
=99( )
true99* .
,99. /
RequireDigit:: 
=:: 
true:: #
,::# $
RequireLowercase;;  
=;;! "
true;;# '
,;;' (
RequireUppercase<<  
=<<! "
true<<# '
,<<' (
}== 
;== 
manager@@ 
.@@ '
UserLockoutEnabledByDefault@@ /
=@@0 1
true@@2 6
;@@6 7
managerAA 
.AA )
DefaultAccountLockoutTimeSpanAA 1
=AA2 3
TimeSpanAA4 <
.AA< =
FromMinutesAA= H
(AAH I
$numAAI J
)AAJ K
;AAK L
managerBB 
.BB 0
$MaxFailedAccessAttemptsBeforeLockoutBB 8
=BB9 :
$numBB; <
;BB< =
managerFF 
.FF %
RegisterTwoFactorProviderFF -
(FF- .
$strFF. :
,FF: ;
newFF< ?$
PhoneNumberTokenProviderFF@ X
<FFX Y
ApplicationUserFFY h
>FFh i
{GG 
MessageFormatHH 
=HH 
$strHH  ;
}II 
)II 
;II 
managerJJ 
.JJ %
RegisterTwoFactorProviderJJ -
(JJ- .
$strJJ. :
,JJ: ;
newJJ< ?
EmailTokenProviderJJ@ R
<JJR S
ApplicationUserJJS b
>JJb c
{KK 
SubjectLL 
=LL 
$strLL )
,LL) *

BodyFormatMM 
=MM 
$strMM 8
}NN 
)NN 
;NN 
managerOO 
.OO 
EmailServiceOO  
=OO! "
newOO# &
EmailServiceOO' 3
(OO3 4
)OO4 5
;OO5 6
managerPP 
.PP 

SmsServicePP 
=PP  
newPP! $

SmsServicePP% /
(PP/ 0
)PP0 1
;PP1 2
varQQ "
dataProtectionProviderQQ &
=QQ' (
optionsQQ) 0
.QQ0 1"
DataProtectionProviderQQ1 G
;QQG H
ifRR 
(RR "
dataProtectionProviderRR &
!=RR' )
nullRR* .
)RR. /
{SS 
managerTT 
.TT 
UserTokenProviderTT )
=TT* +
newUU &
DataProtectorTokenProviderUU 2
<UU2 3
ApplicationUserUU3 B
>UUB C
(UUC D"
dataProtectionProviderUUD Z
.UUZ [
CreateUU[ a
(UUa b
$strUUb t
)UUt u
)UUu v
;UUv w
}VV 
returnWW 
managerWW 
;WW 
}XX 	
}YY 
public\\ 

class\\ $
ApplicationSignInManager\\ )
:\\* +
SignInManager\\, 9
<\\9 :
ApplicationUser\\: I
,\\I J
string\\K Q
>\\Q R
{]] 
public^^ $
ApplicationSignInManager^^ '
(^^' ("
ApplicationUserManager^^( >
userManager^^? J
,^^J K"
IAuthenticationManager^^L b!
authenticationManager^^c x
)^^x y
:__ 
base__ 
(__ 
userManager__ 
,__ !
authenticationManager__  5
)__5 6
{`` 	
}aa 	
publiccc 
overridecc 
Taskcc 
<cc 
ClaimsIdentitycc +
>cc+ ,#
CreateUserIdentityAsynccc- D
(ccD E
ApplicationUserccE T
userccU Y
)ccY Z
{dd 	
returnee 
useree 
.ee %
GenerateUserIdentityAsyncee 1
(ee1 2
(ee2 3"
ApplicationUserManageree3 I
)eeI J
UserManagereeJ U
)eeU V
;eeV W
}ff 	
publichh 
statichh $
ApplicationSignInManagerhh .
Createhh/ 5
(hh5 6"
IdentityFactoryOptionshh6 L
<hhL M$
ApplicationSignInManagerhhM e
>hhe f
optionshhg n
,hhn o
IOwinContexthhp |
context	hh} Ñ
)
hhÑ Ö
{ii 	
returnjj 
newjj $
ApplicationSignInManagerjj /
(jj/ 0
contextjj0 7
.jj7 8
GetUserManagerjj8 F
<jjF G"
ApplicationUserManagerjjG ]
>jj] ^
(jj^ _
)jj_ `
,jj` a
contextjjb i
.jji j
Authenticationjjj x
)jjx y
;jjy z
}kk 	
}ll 
}mm √
åC:\Users\Hendry\Documents\Visual Studio 2015\Projects\WebAPIMVCSample\Binus.SampleWebAPI.Web\Binus.SampleWebAPI.Web\App_Start\RouteConfig.cs
	namespace 	
Binus
 
. 
SampleWebAPI 
. 
Web  
{ 
public 

class 
RouteConfig 
{ 
public		 
static		 
void		 
RegisterRoutes		 )
(		) *
RouteCollection		* 9
routes		: @
)		@ A
{

 	
routes 
. 
IgnoreRoute 
( 
$str ;
); <
;< =
if 
(  
ConfigurationManager $
.$ %
AppSettings% 0
[0 1
$str1 A
]A B
.B C
ToStringC K
(K L
)L M
!=N P
$strQ T
)T U
{ 
routes 
. 
MapRoute 
(  
name 
: 
$str #
,# $
url 
: 
$str <
,< =
defaults 
: 
new !
{" #

controller$ .
=/ 0
$str1 8
,8 9
action: @
=A B
$strC J
,J K
typeL P
=Q R
UrlParameterS _
._ `
Optional` h
,h i
idj l
=m n
UrlParametero {
.{ |
Optional	| Ñ
}
Ö Ü
) 
; 
} 
else 
{ 
routes 
. 
MapRoute 
(  
name 
: 
$str !
,! "
url 
: 
$str :
,: ;
defaults 
: 
new 
{  !

controller" ,
=- .
$str/ ;
,; <
action= C
=D E
$strF M
,M N
typeO S
=T U
UrlParameterV b
.b c
Optionalc k
,k l
idm o
=p q
UrlParameterr ~
.~ 
Optional	 á
}
à â
) 
; 
} 
} 	
} 
} Ò
çC:\Users\Hendry\Documents\Visual Studio 2015\Projects\WebAPIMVCSample\Binus.SampleWebAPI.Web\Binus.SampleWebAPI.Web\App_Start\Startup.Auth.cs
	namespace

 	
Binus


 
.

 
SampleWebAPI

 
.

 
Web

  
{ 
public 

partial 
class 
Startup  
{ 
public 
void 
ConfigureAuth !
(! "
IAppBuilder" -
app. 1
)1 2
{ 	
app 
.  
CreatePerOwinContext $
($ % 
ApplicationDbContext% 9
.9 :
Create: @
)@ A
;A B
app 
.  
CreatePerOwinContext $
<$ %"
ApplicationUserManager% ;
>; <
(< ="
ApplicationUserManager= S
.S T
CreateT Z
)Z [
;[ \
app 
.  
CreatePerOwinContext $
<$ %$
ApplicationSignInManager% =
>= >
(> ?$
ApplicationSignInManager? W
.W X
CreateX ^
)^ _
;_ `
app 
. #
UseCookieAuthentication '
(' (
new( +'
CookieAuthenticationOptions, G
{ 
AuthenticationType "
=# $&
DefaultAuthenticationTypes% ?
.? @
ApplicationCookie@ Q
,Q R
	LoginPath 
= 
new 

PathString  *
(* +
$str+ ;
); <
,< =
Provider 
= 
new (
CookieAuthenticationProvider ;
{ 
OnValidateIdentity!! &
=!!' ("
SecurityStampValidator!!) ?
.!!? @
OnValidateIdentity!!@ R
<!!R S"
ApplicationUserManager!!S i
,!!i j
ApplicationUser!!k z
>!!z {
(!!{ |
validateInterval"" (
:""( )
TimeSpan""* 2
.""2 3
FromMinutes""3 >
(""> ?
$num""? A
)""A B
,""B C
regenerateIdentity## *
:##* +
(##, -
manager##- 4
,##4 5
user##6 :
)##: ;
=>##< >
user##? C
.##C D%
GenerateUserIdentityAsync##D ]
(##] ^
manager##^ e
)##e f
)##f g
}$$ 
}%% 
)%% 
;%% 
app&& 
.&& #
UseExternalSignInCookie&& '
(&&' (&
DefaultAuthenticationTypes&&( B
.&&B C
ExternalCookie&&C Q
)&&Q R
;&&R S
app)) 
.)) $
UseTwoFactorSignInCookie)) (
())( )&
DefaultAuthenticationTypes))) C
.))C D
TwoFactorCookie))D S
,))S T
TimeSpan))U ]
.))] ^
FromMinutes))^ i
())i j
$num))j k
)))k l
)))l m
;))m n
app.. 
... -
!UseTwoFactorRememberBrowserCookie.. 1
(..1 2&
DefaultAuthenticationTypes..2 L
...L M*
TwoFactorRememberBrowserCookie..M k
)..k l
;..l m
}BB 	
}CC 
}DD è	
çC:\Users\Hendry\Documents\Visual Studio 2015\Projects\WebAPIMVCSample\Binus.SampleWebAPI.Web\Binus.SampleWebAPI.Web\App_Start\WebApiConfig.cs
	namespace 	
Binus
 
. 
SampleWebAPI 
. 
Web  
{ 
public 

static 
class 
WebApiConfig $
{		 
public

 
static

 
void

 
Register

 #
(

# $
HttpConfiguration

$ 5
config

6 <
)

< =
{ 	
config 
. "
MapHttpAttributeRoutes )
() *
)* +
;+ ,
config 
. 
Routes 
. 
MapHttpRoute &
(& '
name 
: 
$str "
," #
routeTemplate 
: 
$str 6
,6 7
defaults 
: 
new 
{ 
id  "
=# $
RouteParameter% 3
.3 4
Optional4 <
}= >
) 
; 
} 	
} 
} ≠
ÉC:\Users\Hendry\Documents\Visual Studio 2015\Projects\WebAPIMVCSample\Binus.SampleWebAPI.Web\Binus.SampleWebAPI.Web\Class\Global.cs
	namespace 	
Binus
 
. 
SampleWebAPI 
. 
Web  
.  !
Class! &
{ 
public		 

static		 
class		 
Global		 
{

 
public 
static 
string 
WebAPIBaseURL *
=+ , 
ConfigurationManager- A
.A B
AppSettingsB M
[M N
$strN ]
]] ^
.^ _
ToString_ g
(g h
)h i
;i j
public 
enum 
Method 
{ 
GET  
=  !
$num! "
," #
POST$ (
=( )
$num) *
}+ ,
;, -
} 
} ˆ'
©C:\Users\Hendry\Documents\Visual Studio 2015\Projects\WebAPIMVCSample\Binus.SampleWebAPI.Web\Binus.SampleWebAPI.Web\Controllers\Backend\msBook\msBookMongoDBController.cs
	namespace		 	
Binus		
 
.		 
SampleWebAPI		 
.		 
Web		  
.		  !
Controllers		! ,
.		, -
Backend		- 4
.		4 5
msBook		5 ;
{

 
[ 
	App_Start 
. 
BasicAuthentication "
]" #
public 

class #
msBookMongoDBController (
:) *

Controller+ 5
{ 
public 
ActionResult 
Index !
(! "
)" #
{ 	

RESTResult 
Result 
= 
(  !
new! $
REST% )
() *
Global* 0
.0 1
WebAPIBaseURL1 >
,> ?
$str@ r
,r s
RESTt x
.x y
Methody 
.	 Ä
POST
Ä Ñ
)
Ñ Ö
.
Ö Ü
Result
Ü å
)
å ç
;
ç é
if 
( 
Result 
. 
Success 
) 
{ 
msBookViewModel 
	ViewModel  )
=* +
new, /
msBookViewModel0 ?
(? @
)@ A
;A B
	ViewModel 
. 
BooksMongoDB &
=' (
Result) /
./ 0
Deserialize0 ;
<; <
List< @
<@ A
msBookMonggoDBA O
>O P
>P Q
(Q R
)R S
;S T
return 
View 
( 
	ViewModel %
)% &
;& '
} 
else 
{ 
return 
View 
( 
) 
; 
} 
} 	
public 
ActionResult 
Manipulation (
(( )
msBookViewModel) 8
Data9 =
)= >
{   	
msUser!! 
CurrentUser!! 
=!!  
(!!! "
msUser!!" (
)!!( )
Session!!) 0
[!!0 1
$str!!1 =
]!!= >
;!!> ?
Data"" 
."" 
BookMongoDB"" 
."" 
UserIn"" #
=""$ %
CurrentUser""& 1
.""1 2
Nama""2 6
;""6 7
Data## 
.## 
BookMongoDB## 
.## 
UserUp## #
=##$ %
CurrentUser##& 1
.##1 2
Nama##2 6
;##6 7

RESTResult$$ 

ResultItem$$ !
=$$" #
($$$ %
new$$% (
REST$$) -
($$- .
Global$$. 4
.$$4 5
WebAPIBaseURL$$5 B
,$$B C
$str$$D 
,	$$ Ä
REST
$$Å Ö
.
$$Ö Ü
Method
$$Ü å
.
$$å ç
POST
$$ç ë
,
$$ë í
Data
$$ì ó
.
$$ó ò
BookMongoDB
$$ò £
)
$$£ §
.
$$§ •
Result
$$• ´
)
$$´ ¨
;
$$¨ ≠
if%% 
(%% 

ResultItem%% 
.%% 
Success%% "
)%%" #
{&& 
return'' 
Json'' 
('' 
new'' 
{''  !
Result''" (
='') *
$str''+ 4
,''4 5
URL''6 9
='': ;
$str''< L
}''M N
)''N O
;''O P
}(( 
else)) 
{** 
return++ 
Json++ 
(++ 
new++ 
{++  !
Result++" (
=++) *
$str+++ 1
,++1 2
Message++3 :
=++; <
$str++= Z
}++[ \
)++\ ]
;++] ^
},, 
}// 	
public11 
ActionResult11 
Edit11  
(11  !
msBookMonggoDB11! /
Data110 4
)114 5
{22 	

RESTResult33 
Result33 
=33 
(33  !
new33! $
REST33% )
(33) *
Global33* 0
.330 1
WebAPIBaseURL331 >
,33> ?
$str33@ r
,33r s
REST33t x
.33x y
Method33y 
.	33 Ä
POST
33Ä Ñ
,
33Ñ Ö
Data
33Ü ä
)
33ä ã
.
33ã å
Result
33å í
)
33í ì
;
33ì î
if44 
(44 
Result44 
.44 
Success44 
)44 
{55 
return66 
Json66 
(66 
Result66 "
.66" #
Deserialize66# .
<66. /
List66/ 3
<663 4
msBookMonggoDB664 B
>66B C
>66C D
(66D E
)66E F
)66F G
;66G H
}77 
else88 
{99 
return:: 
View:: 
(:: 
):: 
;:: 
};; 
}>> 	
}@@ 
}AA ¢2
®C:\Users\Hendry\Documents\Visual Studio 2015\Projects\WebAPIMVCSample\Binus.SampleWebAPI.Web\Binus.SampleWebAPI.Web\Controllers\Backend\msBook\msBookOracleController.cs
	namespace

 	
Binus


 
.

 
SampleWebAPI

 
.

 
Web

  
.

  !
Controllers

! ,
.

, -
Backend

- 4
.

4 5
msBook

5 ;
{ 
public 

class "
msBookOracleController '
:( )

Controller* 4
{ 
[ 	
	App_Start	 
. 
BasicAuthentication &
]& '
public 
ActionResult 
Index !
(! "
)" #
{ 	

RESTResult 
Result 
= 
(  !
new! $
REST% )
() *
Global* 0
.0 1
WebAPIBaseURL1 >
,> ?
$str@ q
,q r
RESTs w
.w x
Methodx ~
.~ 
POST	 É
)
É Ñ
.
Ñ Ö
Result
Ö ã
)
ã å
;
å ç
if 
( 
Result 
. 
Success 
) 
{ 
msBookViewModel 
	ViewModel  )
=* +
new, /
msBookViewModel0 ?
(? @
)@ A
;A B
	ViewModel 
. 
Books 
=  !
Result" (
.( )
Deserialize) 4
<4 5
List5 9
<9 :
msBookMSSQLOracle: K
>K L
>L M
(M N
)N O
;O P
return 
View 
( 
	ViewModel %
)% &
;& '
} 
else 
{ 
return 
View 
( 
) 
; 
} 
} 	
public   
ActionResult   
Manipulation   (
(  ( )
msBookViewModel  ) 8
Data  9 =
)  = >
{!! 	
msUser"" 
CurrentUser"" 
=""  
(""! "
msUser""" (
)""( )
Session"") 0
[""0 1
$str""1 =
]""= >
;""> ?
Data## 
.## 
Book## 
.## 
UserIn## 
=## 
CurrentUser## *
.##* +
Nama##+ /
;##/ 0
Data$$ 
.$$ 
Book$$ 
.$$ 
UserUp$$ 
=$$ 
CurrentUser$$ *
.$$* +
Nama$$+ /
;$$/ 0

RESTResult%% 

ResultItem%% !
=%%" #
(%%$ %
new%%% (
REST%%) -
(%%- .
Global%%. 4
.%%4 5
WebAPIBaseURL%%5 B
,%%B C
$str%%D ~
,%%~ 
REST
%%Ä Ñ
.
%%Ñ Ö
Method
%%Ö ã
.
%%ã å
POST
%%å ê
,
%%ê ë
Data
%%í ñ
.
%%ñ ó
Book
%%ó õ
)
%%õ ú
.
%%ú ù
Result
%%ù £
)
%%£ §
;
%%§ •
if&& 
(&& 

ResultItem&& 
.&& 
Success&& "
)&&" #
{'' 
return(( 
Json(( 
((( 
new(( 
{((  !
Result((" (
=(() *
$str((+ 4
,((4 5
URL((6 9
=((: ;
$str((< K
}((L M
)((M N
;((N O
})) 
else** 
{++ 
return,, 
Json,, 
(,, 
new,, 
{,,  !
Result,," (
=,,) *
$str,,+ 1
,,,1 2
Message,,3 :
=,,; <
$str,,= Z
},,[ \
),,\ ]
;,,] ^
}-- 
}00 	
public22 
ActionResult22 
Edit22  
(22  !
msBookMSSQLOracle22! 2
Data223 7
)227 8
{33 	

RESTResult44 
Result44 
=44 
(44  !
new44! $
REST44% )
(44) *
Global44* 0
.440 1
WebAPIBaseURL441 >
,44> ?
$str44@ q
,44q r
REST44s w
.44w x
Method44x ~
.44~ 
POST	44 É
,
44É Ñ
Data
44Ö â
)
44â ä
.
44ä ã
Result
44ã ë
)
44ë í
;
44í ì
if55 
(55 
Result55 
.55 
Success55 
)55 
{66 
return77 
Json77 
(77 
Result77 "
.77" #
Deserialize77# .
<77. /
List77/ 3
<773 4
msBookMSSQLOracle774 E
>77E F
>77F G
(77G H
)77H I
)77I J
;77J K
}88 
else99 
{:: 
return;; 
View;; 
(;; 
);; 
;;; 
}<< 
}?? 	
publicAA 
ActionResultAA 
DeleteAA "
(AA" #
)AA# $
{BB 	

RESTResultCC 
ResultCC 
=CC 
(CC  !
newCC! $
RESTCC% )
(CC) *
GlobalCC* 0
.CC0 1
WebAPIBaseURLCC1 >
,CC> ?
$strCC@ q
,CCq r
RESTCCs w
.CCw x
MethodCCx ~
.CC~ 
POST	CC É
)
CCÉ Ñ
.
CCÑ Ö
Result
CCÖ ã
)
CCã å
;
CCå ç
ifDD 
(DD 
ResultDD 
.DD 
SuccessDD 
)DD 
{EE 
msBookViewModelFF 
	ViewModelFF  )
=FF* +
newFF, /
msBookViewModelFF0 ?
(FF? @
)FF@ A
;FFA B
	ViewModelGG 
.GG 
BooksGG 
=GG  !
ResultGG" (
.GG( )
DeserializeGG) 4
<GG4 5
ListGG5 9
<GG9 :
msBookMSSQLOracleGG: K
>GGK L
>GGL M
(GGM N
)GGN O
;GGO P
returnHH 
ViewHH 
(HH 
	ViewModelHH %
)HH% &
;HH& '
}II 
elseJJ 
{KK 
returnLL 
ViewLL 
(LL 
)LL 
;LL 
}MM 
}PP 	
}QQ 
}RR ü2
ßC:\Users\Hendry\Documents\Visual Studio 2015\Projects\WebAPIMVCSample\Binus.SampleWebAPI.Web\Binus.SampleWebAPI.Web\Controllers\Backend\msBook\msBookMSSQLController.cs
	namespace

 	
Binus


 
.

 
SampleWebAPI

 
.

 
Web

  
.

  !
Controllers

! ,
.

, -
Backend

- 4
.

4 5
msBook

5 ;
{ 
[ 
	App_Start 
. 
BasicAuthentication "
]" #
public 

class !
msBookMSSQLController &
:' (

Controller) 3
{ 
public 
ActionResult 
Index !
(! "
)" #
{ 	

RESTResult 
Result 
= 
(  !
new! $
REST% )
() *
Global* 0
.0 1
WebAPIBaseURL1 >
,> ?
$str@ p
,p q
RESTr v
.v w
Methodw }
.} ~
POST	~ Ç
)
Ç É
.
É Ñ
Result
Ñ ä
)
ä ã
;
ã å
if 
( 
Result 
. 
Success 
) 
{ 
msBookViewModel 
	ViewModel  )
=* +
new, /
msBookViewModel0 ?
(? @
)@ A
;A B
	ViewModel 
. 
Books 
=  !
Result" (
.( )
Deserialize) 4
<4 5
List5 9
<9 :
msBookMSSQLOracle: K
>K L
>L M
(M N
)N O
;O P
return 
View 
( 
	ViewModel %
)% &
;& '
} 
else 
{ 
return 
View 
( 
) 
; 
} 
} 	
public   
ActionResult   
Manipulation   (
(  ( )
msBookViewModel  ) 8
Data  9 =
)  = >
{!! 	
msUser"" 
CurrentUser"" 
=""  
(""! "
msUser""" (
)""( )
Session"") 0
[""0 1
$str""1 =
]""= >
;""> ?
Data## 
.## 
Book## 
.## 
UserIn## 
=## 
CurrentUser## *
.##* +
Nama##+ /
;##/ 0
Data$$ 
.$$ 
Book$$ 
.$$ 
UserUp$$ 
=$$ 
CurrentUser$$ *
.$$* +
Nama$$+ /
;$$/ 0

RESTResult%% 

ResultItem%% !
=%%" #
(%%$ %
new%%% (
REST%%) -
(%%- .
Global%%. 4
.%%4 5
WebAPIBaseURL%%5 B
,%%B C
$str%%D }
,%%} ~
REST	%% É
.
%%É Ñ
Method
%%Ñ ä
.
%%ä ã
POST
%%ã è
,
%%è ê
Data
%%ê î
.
%%î ï
Book
%%ï ô
)
%%ô ö
.
%%ö õ
Result
%%õ °
)
%%° ¢
;
%%¢ £
if&& 
(&& 

ResultItem&& 
.&& 
Success&& "
)&&" #
{'' 
return(( 
Json(( 
((( 
new(( 
{((  !
Result((" (
=(() *
$str((+ 4
,((4 5
URL((6 9
=((: ;
$str((< J
}((K L
)((L M
;((M N
})) 
else** 
{++ 
return,, 
Json,, 
(,, 
new,, 
{,,  !
Result,," (
=,,) *
$str,,+ 1
,,,1 2
Message,,3 :
=,,; <
$str,,= Z
},,[ \
),,\ ]
;,,] ^
}-- 
}00 	
public22 
ActionResult22 
Edit22  
(22  !
msBookMSSQLOracle22! 2
Data223 7
)227 8
{33 	

RESTResult44 
Result44 
=44 
(44  !
new44! $
REST44% )
(44) *
Global44* 0
.440 1
WebAPIBaseURL441 >
,44> ?
$str44@ p
,44p q
REST44r v
.44v w
Method44w }
.44} ~
POST	44~ Ç
,
44Ç É
Data
44Ñ à
)
44à â
.
44â ä
Result
44ä ê
)
44ê ë
;
44ë í
if55 
(55 
Result55 
.55 
Success55 
)55 
{66 
return77 
Json77 
(77 
Result77 "
.77" #
Deserialize77# .
<77. /
List77/ 3
<773 4
msBookMSSQLOracle774 E
>77E F
>77F G
(77G H
)77H I
)77I J
;77J K
}88 
else99 
{:: 
return;; 
View;; 
(;; 
);; 
;;; 
}<< 
}?? 	
publicAA 
ActionResultAA 
DeleteAA "
(AA" #
)AA# $
{BB 	

RESTResultCC 
ResultCC 
=CC 
(CC  !
newCC! $
RESTCC% )
(CC) *
GlobalCC* 0
.CC0 1
WebAPIBaseURLCC1 >
,CC> ?
$strCC@ p
,CCp q
RESTCCr v
.CCv w
MethodCCw }
.CC} ~
POST	CC~ Ç
)
CCÇ É
.
CCÉ Ñ
Result
CCÑ ä
)
CCä ã
;
CCã å
ifDD 
(DD 
ResultDD 
.DD 
SuccessDD 
)DD 
{EE 
msBookViewModelFF 
	ViewModelFF  )
=FF* +
newFF, /
msBookViewModelFF0 ?
(FF? @
)FF@ A
;FFA B
	ViewModelGG 
.GG 
BooksGG 
=GG  !
ResultGG" (
.GG( )
DeserializeGG) 4
<GG4 5
ListGG5 9
<GG9 :
msBookMSSQLOracleGG: K
>GGK L
>GGL M
(GGM N
)GGN O
;GGO P
returnHH 
ViewHH 
(HH 
	ViewModelHH %
)HH% &
;HH& '
}II 
elseJJ 
{KK 
returnLL 
ViewLL 
(LL 
)LL 
;LL 
}MM 
}PP 	
}QQ 
}RR äP
òC:\Users\Hendry\Documents\Visual Studio 2015\Projects\WebAPIMVCSample\Binus.SampleWebAPI.Web\Binus.SampleWebAPI.Web\Controllers\Login\LoginController.cs
	namespace 	
Binus
 
. 
SampleWebAPI 
. 
Web  
.  !
Controllers! ,
., -
Login- 2
{ 
public 

class 
LoginController  
:! "

Controller# -
{ 
public 
LoginController 
( 
)  
{ 	
} 	
public 
ActionResult 
Index !
(! "
)" #
{ 	
return 
View 
( 
) 
; 
}## 	
[%% 	
HttpPost%%	 
]%% 
[&& 	$
ValidateAntiForgeryToken&&	 !
]&&! "
public'' 
async'' 
Task'' 
<'' 
ActionResult'' &
>''& '
Auth''( ,
('', -
UserViewModel''- :
Model''; @
)''@ A
{(( 	
string)) 
URL)) 
;)) 
URL++ 
=++ 
Request++ 
.++ 
Url++ 
.++ 
GetLeftPart++ )
(++) *

UriPartial++* 4
.++4 5
	Authority++5 >
)++> ?
+++@ A
Url++B E
.++E F
Content++F M
(++M N
$str++N Q
)++Q R
+++S T
$str++U b
;++b c
StringBuilder,, 
RetValue,, "
=,,# $
new,,% (
StringBuilder,,) 6
(,,6 7
),,7 8
;,,8 9

JsonResult-- 
RetData-- 
=--  
new--! $

JsonResult--% /
(--/ 0
)--0 1
;--1 2
if.. 
(.. 
Session.. 
[.. 
$str.. $
]..$ %
==..& (
null..) -
)..- .
{// 
try00 
{11 

RESTResult33 
Result33 %
=33& '
new33( +

RESTResult33, 6
(336 7
)337 8
;338 9
if44 
(44 
Request44 
.44  
Form44  $
[44$ %
$str44% +
]44+ ,
!=44, .
null44. 2
)442 3
{55 

UserHRISDB66 "
Data66# '
=66( )
new66* -

UserHRISDB66. 8
(668 9
)669 :
;66: ;
Data77 
.77 
Username77 %
=77& '
Crypto77( .
.77. /
Encrypt77/ 6
(776 7
Model777 <
.77< =
UserName77= E
)77E F
;77F G
Data88 
.88 
Password88 %
=88& '
Crypto88( .
.88. /
Encrypt88/ 6
(886 7
Model887 <
.88< =
Password88= E
)88E F
;88F G
Result99 
=99  
(99! "
new99" %
REST99& *
(99* +
Global99+ 1
.991 2
WebAPIBaseURL992 ?
,99? @
$str99A l
,99l m
REST99n r
.99r s
Method99s y
.99y z
POST99z ~
,99~ 
Data
99Ä Ñ
)
99Ñ Ö
.
99Ö Ü
Result
99Ü å
)
99å ç
;
99ç é
}:: 
else;; 
if;; 
(;; 
Request;; $
.;;$ %
Form;;% )
[;;) *
$str;;* .
];;. /
!=;;0 2
null;;3 7
);;7 8
{<< 
AuthUser==  
Data==! %
===& '
new==( +
AuthUser==, 4
(==4 5
)==5 6
;==6 7
Data>> 
.>> 
Username>> %
=>>& '
Crypto>>( .
.>>. /
Encrypt>>/ 6
(>>6 7
Model>>7 <
.>>< =
UserName>>= E
)>>E F
;>>F G
Data?? 
.?? 
Password?? %
=??& '
Crypto??( .
.??. /
Encrypt??/ 6
(??6 7
Model??7 <
.??< =
Password??= E
)??E F
;??F G
Result@@ 
=@@  
(@@! "
new@@" %
REST@@& *
(@@* +
Global@@+ 1
.@@1 2
WebAPIBaseURL@@2 ?
,@@? @
$str@@A n
,@@n o
REST@@p t
.@@t u
Method@@u {
.@@{ |
POST	@@| Ä
,
@@Ä Å"
ConfigurationManager
@@Å ï
.
@@ï ñ
AppSettings
@@ñ °
[
@@° ¢
$str
@@¢ Ø
]
@@Ø ∞
.
@@∞ ±
ToString
@@± π
(
@@π ∫
)
@@∫ ª
,
@@ª º
Data
@@Ω ¡
)
@@¡ ¬
.
@@¬ √
Result
@@√ …
)
@@…  
;
@@  À
}AA 
ifEE 
(EE 
ResultEE 
.EE 
SuccessEE &
)EE& '
{FF 
msUserGG 
UserGG #
=GG$ %
newGG& )
msUserGG* 0
(GG0 1
)GG1 2
;GG2 3
ifHH 
(HH 
RequestHH #
.HH# $
FormHH$ (
[HH( )
$strHH) /
]HH/ 0
!=HH1 3
nullHH4 8
)HH8 9
{II 

UserHRISDBJJ &

UserHRISDBJJ' 1
=JJ2 3
ResultJJ4 :
.JJ: ;
DeserializeJJ; F
<JJF G

UserHRISDBJJG Q
>JJQ R
(JJR S
)JJS T
;JJT U
UserKK  
.KK  !
NamaKK! %
=KK& '

UserHRISDBKK( 2
.KK2 3
NamaKK3 7
;KK7 8
UserLL  
.LL  !
EmailLL! &
=LL' (

UserHRISDBLL) 3
.LL3 4
Email1LL4 :
;LL: ;
}MM 
elseNN 
{OO 
UserPP  
=PP! "
ResultPP# )
.PP) *
DeserializePP* 5
<PP5 6
msUserPP6 <
>PP< =
(PP= >
)PP> ?
;PP? @
UserQQ  
.QQ  !
NamaQQ! %
=QQ& '
UserQQ( ,
.QQ, -
UsernameQQ- 5
;QQ5 6
}RR 
ifSS 
(SS 
UserSS  
!=SS! #
nullSS$ (
)SS( )
{TT 
SessionWW #
[WW# $
$strWW$ 0
]WW0 1
=WW2 3
UserWW4 8
;WW8 9
RetDataZZ #
=ZZ$ %
JsonZZ& *
(ZZ* +
newZZ+ .
{ZZ/ 0
ResultZZ1 7
=ZZ8 9
$strZZ: C
,ZZC D
MessageZZE L
=ZZM N
$str	ZZO ä
,
ZZä ã
URL
ZZå è
=
ZZê ë
URL
ZZí ï
}
ZZñ ó
)
ZZó ò
;
ZZò ô
}]] 
else^^ 
{__ 
RetData`` #
=``$ %
Json``& *
(``* +
new``+ .
{``/ 0
Result``1 7
=``8 9
$str``: @
,``@ A
Message``B I
=``J K
$str``L j
}``k l
)``l m
;``m n
}aa 
}bb 
elsecc 
{dd 
ifee 
(ee 
Resultee !
.ee! "

StatusCodeee" ,
==ee- /
Systemee0 6
.ee6 7
Netee7 :
.ee: ;
HttpStatusCodeee; I
.eeI J
UnauthorizedeeJ V
)eeV W
{ff 
RetDatagg #
=gg$ %
Jsongg& *
(gg* +
newgg+ .
{gg/ 0
Resultgg1 7
=gg8 9
$strgg: @
,gg@ A
MessageggB I
=ggJ K
$strggL j
}ggk l
)ggl m
;ggm n
}hh 
elseii 
ifii 
(ii  !
Resultii! '
.ii' (
JSONii( ,
.ii, -
Containsii- 5
(ii5 6
$strii6 E
)iiE F
)iiF G
{jj 
RetDatakk #
=kk$ %
Jsonkk& *
(kk* +
newkk+ .
{kk/ 0
Resultkk1 7
=kk8 9
$strkk: @
,kk@ A
MessagekkB I
=kkJ K
$strkkL j
}kkk l
)kkl m
;kkm n
}ll 
elsemm 
{nn 
RetDataoo #
=oo$ %
Jsonoo& *
(oo* +
newoo+ .
{oo/ 0
Resultoo1 7
=oo8 9
$stroo: @
,oo@ A
MessageooB I
=ooJ K
$strooL }
}oo~ 
)	oo Ä
;
ooÄ Å
}pp 
}rr 
}uu 
catchvv 
(vv 
	Exceptionvv  
Exvv! #
)vv# $
{ww 
RetDatayy 
=yy 
Jsonyy "
(yy" #
newyy# &
{yy' (
Resultyy) /
=yy0 1
$stryy2 8
,yy8 9
Messageyy: A
=yyB C
$stryyD _
+yy` a
Exyyb d
.yyd e
Messageyye l
.yyl m
ToStringyym u
(yyu v
)yyv w
}yyx y
)yyy z
;yyz {
}zz 
}{{ 
else|| 
{}} 
RetData~~ 
=~~ 
Json~~ 
(~~ 
new~~ "
{~~# $
Result~~% +
=~~, -
$str~~. 7
,~~7 8
Message~~9 @
=~~A B
$str~~C ~
,~~~ 
URL
~~Ä É
=
~~Ñ Ö
URL
~~Ü â
}
~~ä ã
)
~~ã å
;
~~å ç
} 
return
ÉÉ 
RetData
ÉÉ 
;
ÉÉ 
}
ÑÑ 	
public
ÖÖ 
async
ÖÖ 
Task
ÖÖ 
<
ÖÖ 
ActionResult
ÖÖ &
>
ÖÖ& '
Logout
ÖÖ( .
(
ÖÖ. /
)
ÖÖ/ 0
{
ÜÜ 	
Session
áá 
.
áá 
Abandon
áá 
(
áá 
)
áá 
;
áá 
Session
àà 
.
àà 
Clear
àà 
(
àà 
)
àà 
;
àà 
return
ââ 
RedirectToAction
ââ #
(
ââ# $
$str
ââ$ +
,
ââ+ ,
$str
ââ- 4
)
ââ4 5
;
ââ5 6
}
ää 	
}
åå 
}çç ø
ÇC:\Users\Hendry\Documents\Visual Studio 2015\Projects\WebAPIMVCSample\Binus.SampleWebAPI.Web\Binus.SampleWebAPI.Web\Global.asax.cs
	namespace

 	
Binus


 
.

 
SampleWebAPI

 
.

 
Web

  
{ 
public 

class 
MvcApplication 
:  !
System" (
.( )
Web) ,
., -
HttpApplication- <
{ 
	protected 
void 
Application_Start (
(( )
)) *
{ 	"
ValueProviderFactories "
." #
	Factories# ,
., -
Add- 0
(0 1
new1 4$
JsonValueProviderFactory5 M
(M N
)N O
)O P
;P Q
AreaRegistration 
. 
RegisterAllAreas -
(- .
). /
;/ 0
FilterConfig 
. !
RegisterGlobalFilters .
(. /
GlobalFilters/ <
.< =
Filters= D
)D E
;E F
RouteConfig 
. 
RegisterRoutes &
(& '

RouteTable' 1
.1 2
Routes2 8
)8 9
;9 :
BundleConfig 
. 
RegisterBundles (
(( )
BundleTable) 4
.4 5
Bundles5 <
)< =
;= >
ViewEngines 
. 
Engines 
.  
Clear  %
(% &
)& '
;' (
ViewEngines 
. 
Engines 
.  
Add  #
(# $
new$ '
CustomViewEngine( 8
(8 9
)9 :
): ;
;; <
} 	
} 
} ˙G
èC:\Users\Hendry\Documents\Visual Studio 2015\Projects\WebAPIMVCSample\Binus.SampleWebAPI.Web\Binus.SampleWebAPI.Web\Models\AccountViewModels.cs
	namespace 	
Binus
 
. 
SampleWebAPI 
. 
Web  
.  !
Models! '
{ 
public 

class .
"ExternalLoginConfirmationViewModel 3
{ 
[ 	
Required	 
] 
[		 	
Display			 
(		 
Name		 
=		 
$str		 
)		  
]		  !
public

 
string

 
Email

 
{

 
get

 !
;

! "
set

# &
;

& '
}

( )
} 
public 

class &
ExternalLoginListViewModel +
{ 
public 
string 
	ReturnUrl 
{  !
get" %
;% &
set' *
;* +
}, -
} 
public 

class 
SendCodeViewModel "
{ 
public 
string 
SelectedProvider &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 
ICollection 
< 
System !
.! "
Web" %
.% &
Mvc& )
.) *
SelectListItem* 8
>8 9
	Providers: C
{D E
getF I
;I J
setK N
;N O
}P Q
public 
string 
	ReturnUrl 
{  !
get" %
;% &
set' *
;* +
}, -
public 
bool 

RememberMe 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
public 

class 
VerifyCodeViewModel $
{ 
[ 	
Required	 
] 
public 
string 
Provider 
{  
get! $
;$ %
set& )
;) *
}+ ,
[ 	
Required	 
] 
[   	
Display  	 
(   
Name   
=   
$str   
)   
]    
public!! 
string!! 
Code!! 
{!! 
get!!  
;!!  !
set!!" %
;!!% &
}!!' (
public"" 
string"" 
	ReturnUrl"" 
{""  !
get""" %
;""% &
set""' *
;""* +
}"", -
[$$ 	
Display$$	 
($$ 
Name$$ 
=$$ 
$str$$ 0
)$$0 1
]$$1 2
public%% 
bool%% 
RememberBrowser%% #
{%%$ %
get%%& )
;%%) *
set%%+ .
;%%. /
}%%0 1
public'' 
bool'' 

RememberMe'' 
{''  
get''! $
;''$ %
set''& )
;'') *
}''+ ,
}(( 
public** 

class** 
ForgotViewModel**  
{++ 
[,, 	
Required,,	 
],, 
[-- 	
Display--	 
(-- 
Name-- 
=-- 
$str-- 
)--  
]--  !
public.. 
string.. 
Email.. 
{.. 
get.. !
;..! "
set..# &
;..& '
}..( )
}// 
public11 

class11 
LoginViewModel11 
{22 
[33 	
Required33	 
]33 
[44 	
Display44	 
(44 
Name44 
=44 
$str44 
)44  
]44  !
[55 	
EmailAddress55	 
]55 
public66 
string66 
Email66 
{66 
get66 !
;66! "
set66# &
;66& '
}66( )
[88 	
Required88	 
]88 
[99 	
DataType99	 
(99 
DataType99 
.99 
Password99 #
)99# $
]99$ %
[:: 	
Display::	 
(:: 
Name:: 
=:: 
$str:: "
)::" #
]::# $
public;; 
string;; 
Password;; 
{;;  
get;;! $
;;;$ %
set;;& )
;;;) *
};;+ ,
[== 	
Display==	 
(== 
Name== 
=== 
$str== &
)==& '
]==' (
public>> 
bool>> 

RememberMe>> 
{>>  
get>>! $
;>>$ %
set>>& )
;>>) *
}>>+ ,
}?? 
publicAA 

classAA 
RegisterViewModelAA "
{BB 
[CC 	
RequiredCC	 
]CC 
[DD 	
EmailAddressDD	 
]DD 
[EE 	
DisplayEE	 
(EE 
NameEE 
=EE 
$strEE 
)EE  
]EE  !
publicFF 
stringFF 
EmailFF 
{FF 
getFF !
;FF! "
setFF# &
;FF& '
}FF( )
[HH 	
RequiredHH	 
]HH 
[II 	
StringLengthII	 
(II 
$numII 
,II 
ErrorMessageII '
=II( )
$strII* Y
,IIY Z
MinimumLengthII[ h
=IIi j
$numIIk l
)IIl m
]IIm n
[JJ 	
DataTypeJJ	 
(JJ 
DataTypeJJ 
.JJ 
PasswordJJ #
)JJ# $
]JJ$ %
[KK 	
DisplayKK	 
(KK 
NameKK 
=KK 
$strKK "
)KK" #
]KK# $
publicLL 
stringLL 
PasswordLL 
{LL  
getLL! $
;LL$ %
setLL& )
;LL) *
}LL+ ,
[NN 	
DataTypeNN	 
(NN 
DataTypeNN 
.NN 
PasswordNN #
)NN# $
]NN$ %
[OO 	
DisplayOO	 
(OO 
NameOO 
=OO 
$strOO *
)OO* +
]OO+ ,
[PP 	
ComparePP	 
(PP 
$strPP 
,PP 
ErrorMessagePP )
=PP* +
$strPP, b
)PPb c
]PPc d
publicQQ 
stringQQ 
ConfirmPasswordQQ %
{QQ& '
getQQ( +
;QQ+ ,
setQQ- 0
;QQ0 1
}QQ2 3
}RR 
publicTT 

classTT "
ResetPasswordViewModelTT '
{UU 
[VV 	
RequiredVV	 
]VV 
[WW 	
EmailAddressWW	 
]WW 
[XX 	
DisplayXX	 
(XX 
NameXX 
=XX 
$strXX 
)XX  
]XX  !
publicYY 
stringYY 
EmailYY 
{YY 
getYY !
;YY! "
setYY# &
;YY& '
}YY( )
[[[ 	
Required[[	 
][[ 
[\\ 	
StringLength\\	 
(\\ 
$num\\ 
,\\ 
ErrorMessage\\ '
=\\( )
$str\\* Y
,\\Y Z
MinimumLength\\[ h
=\\i j
$num\\k l
)\\l m
]\\m n
[]] 	
DataType]]	 
(]] 
DataType]] 
.]] 
Password]] #
)]]# $
]]]$ %
[^^ 	
Display^^	 
(^^ 
Name^^ 
=^^ 
$str^^ "
)^^" #
]^^# $
public__ 
string__ 
Password__ 
{__  
get__! $
;__$ %
set__& )
;__) *
}__+ ,
[aa 	
DataTypeaa	 
(aa 
DataTypeaa 
.aa 
Passwordaa #
)aa# $
]aa$ %
[bb 	
Displaybb	 
(bb 
Namebb 
=bb 
$strbb *
)bb* +
]bb+ ,
[cc 	
Comparecc	 
(cc 
$strcc 
,cc 
ErrorMessagecc )
=cc* +
$strcc, b
)ccb c
]ccc d
publicdd 
stringdd 
ConfirmPassworddd %
{dd& '
getdd( +
;dd+ ,
setdd- 0
;dd0 1
}dd2 3
publicff 
stringff 
Codeff 
{ff 
getff  
;ff  !
setff" %
;ff% &
}ff' (
}gg 
publicii 

classii #
ForgotPasswordViewModelii (
{jj 
[kk 	
Requiredkk	 
]kk 
[ll 	
EmailAddressll	 
]ll 
[mm 	
Displaymm	 
(mm 
Namemm 
=mm 
$strmm 
)mm  
]mm  !
publicnn 
stringnn 
Emailnn 
{nn 
getnn !
;nn! "
setnn# &
;nn& '
}nn( )
}oo 
}pp È
åC:\Users\Hendry\Documents\Visual Studio 2015\Projects\WebAPIMVCSample\Binus.SampleWebAPI.Web\Binus.SampleWebAPI.Web\Models\IdentityModels.cs
	namespace 	
Binus
 
. 
SampleWebAPI 
. 
Web  
.  !
Models! '
{ 
public

 

class

 
ApplicationUser

  
:

! "
IdentityUser

# /
{ 
public 
async 
Task 
< 
ClaimsIdentity (
>( )%
GenerateUserIdentityAsync* C
(C D
UserManagerD O
<O P
ApplicationUserP _
>_ `
managera h
)h i
{ 	
var 
userIdentity 
= 
await $
manager% ,
., -
CreateIdentityAsync- @
(@ A
thisA E
,E F&
DefaultAuthenticationTypesG a
.a b
ApplicationCookieb s
)s t
;t u
return 
userIdentity 
;  
} 	
} 
public 

class  
ApplicationDbContext %
:& '
IdentityDbContext( 9
<9 :
ApplicationUser: I
>I J
{ 
public  
ApplicationDbContext #
(# $
)$ %
: 
base 
( 
$str &
,& '
throwIfV1Schema( 7
:7 8
false9 >
)> ?
{ 	
} 	
public 
static  
ApplicationDbContext *
Create+ 1
(1 2
)2 3
{ 	
return 
new  
ApplicationDbContext +
(+ ,
), -
;- .
} 	
}   
}!! …9
éC:\Users\Hendry\Documents\Visual Studio 2015\Projects\WebAPIMVCSample\Binus.SampleWebAPI.Web\Binus.SampleWebAPI.Web\Models\ManageViewModels.cs
	namespace 	
Binus
 
. 
SampleWebAPI 
. 
Web  
.  !
Models! '
{ 
public 

class 
IndexViewModel 
{		 
public

 
bool

 
HasPassword

 
{

  !
get

" %
;

% &
set

' *
;

* +
}

, -
public 
IList 
< 
UserLoginInfo "
>" #
Logins$ *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
public 
string 
PhoneNumber !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
bool 
	TwoFactor 
{ 
get  #
;# $
set% (
;( )
}* +
public 
bool 
BrowserRemembered %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
} 
public 

class !
ManageLoginsViewModel &
{ 
public 
IList 
< 
UserLoginInfo "
>" #
CurrentLogins$ 1
{2 3
get4 7
;7 8
set9 <
;< =
}> ?
public 
IList 
< %
AuthenticationDescription .
>. /
OtherLogins0 ;
{< =
get> A
;A B
setC F
;F G
}H I
} 
public 

class 
FactorViewModel  
{ 
public 
string 
Purpose 
{ 
get  #
;# $
set% (
;( )
}* +
} 
public 

class  
SetPasswordViewModel %
{ 
[ 	
Required	 
] 
[ 	
StringLength	 
( 
$num 
, 
ErrorMessage '
=( )
$str* Y
,Y Z
MinimumLength[ h
=i j
$numk l
)l m
]m n
[   	
DataType  	 
(   
DataType   
.   
Password   #
)  # $
]  $ %
[!! 	
Display!!	 
(!! 
Name!! 
=!! 
$str!! &
)!!& '
]!!' (
public"" 
string"" 
NewPassword"" !
{""" #
get""$ '
;""' (
set"") ,
;"", -
}"". /
[$$ 	
DataType$$	 
($$ 
DataType$$ 
.$$ 
Password$$ #
)$$# $
]$$$ %
[%% 	
Display%%	 
(%% 
Name%% 
=%% 
$str%% .
)%%. /
]%%/ 0
[&& 	
Compare&&	 
(&& 
$str&& 
,&& 
ErrorMessage&&  ,
=&&- .
$str&&/ i
)&&i j
]&&j k
public'' 
string'' 
ConfirmPassword'' %
{''& '
get''( +
;''+ ,
set''- 0
;''0 1
}''2 3
}(( 
public** 

class** #
ChangePasswordViewModel** (
{++ 
[,, 	
Required,,	 
],, 
[-- 	
DataType--	 
(-- 
DataType-- 
.-- 
Password-- #
)--# $
]--$ %
[.. 	
Display..	 
(.. 
Name.. 
=.. 
$str.. *
)..* +
]..+ ,
public// 
string// 
OldPassword// !
{//" #
get//$ '
;//' (
set//) ,
;//, -
}//. /
[11 	
Required11	 
]11 
[22 	
StringLength22	 
(22 
$num22 
,22 
ErrorMessage22 '
=22( )
$str22* Y
,22Y Z
MinimumLength22[ h
=22i j
$num22k l
)22l m
]22m n
[33 	
DataType33	 
(33 
DataType33 
.33 
Password33 #
)33# $
]33$ %
[44 	
Display44	 
(44 
Name44 
=44 
$str44 &
)44& '
]44' (
public55 
string55 
NewPassword55 !
{55" #
get55$ '
;55' (
set55) ,
;55, -
}55. /
[77 	
DataType77	 
(77 
DataType77 
.77 
Password77 #
)77# $
]77$ %
[88 	
Display88	 
(88 
Name88 
=88 
$str88 .
)88. /
]88/ 0
[99 	
Compare99	 
(99 
$str99 
,99 
ErrorMessage99  ,
=99- .
$str99/ i
)99i j
]99j k
public:: 
string:: 
ConfirmPassword:: %
{::& '
get::( +
;::+ ,
set::- 0
;::0 1
}::2 3
};; 
public== 

class== #
AddPhoneNumberViewModel== (
{>> 
[?? 	
Required??	 
]?? 
[@@ 	
Phone@@	 
]@@ 
[AA 	
DisplayAA	 
(AA 
NameAA 
=AA 
$strAA &
)AA& '
]AA' (
publicBB 
stringBB 
NumberBB 
{BB 
getBB "
;BB" #
setBB$ '
;BB' (
}BB) *
}CC 
publicEE 

classEE &
VerifyPhoneNumberViewModelEE +
{FF 
[GG 	
RequiredGG	 
]GG 
[HH 	
DisplayHH	 
(HH 
NameHH 
=HH 
$strHH 
)HH 
]HH  
publicII 
stringII 
CodeII 
{II 
getII  
;II  !
setII" %
;II% &
}II' (
[KK 	
RequiredKK	 
]KK 
[LL 	
PhoneLL	 
]LL 
[MM 	
DisplayMM	 
(MM 
NameMM 
=MM 
$strMM &
)MM& '
]MM' (
publicNN 
stringNN 
PhoneNumberNN !
{NN" #
getNN$ '
;NN' (
setNN) ,
;NN, -
}NN. /
}OO 
publicQQ 

classQQ '
ConfigureTwoFactorViewModelQQ ,
{RR 
publicSS 
stringSS 
SelectedProviderSS &
{SS' (
getSS) ,
;SS, -
setSS. 1
;SS1 2
}SS3 4
publicTT 
ICollectionTT 
<TT 
SystemTT !
.TT! "
WebTT" %
.TT% &
MvcTT& )
.TT) *
SelectListItemTT* 8
>TT8 9
	ProvidersTT: C
{TTD E
getTTF I
;TTI J
setTTK N
;TTN O
}TTP Q
}UU 
}VV ∫
éC:\Users\Hendry\Documents\Visual Studio 2015\Projects\WebAPIMVCSample\Binus.SampleWebAPI.Web\Binus.SampleWebAPI.Web\Properties\AssemblyInfo.cs
[ 
assembly 	
:	 

AssemblyTitle 
( 
$str 1
)1 2
]2 3
[		 
assembly		 	
:			 

AssemblyDescription		 
(		 
$str		 !
)		! "
]		" #
[

 
assembly

 	
:

	 
!
AssemblyConfiguration

  
(

  !
$str

! #
)

# $
]

$ %
[ 
assembly 	
:	 

AssemblyCompany 
( 
$str 
) 
] 
[ 
assembly 	
:	 

AssemblyProduct 
( 
$str 3
)3 4
]4 5
[ 
assembly 	
:	 

AssemblyCopyright 
( 
$str 0
)0 1
]1 2
[ 
assembly 	
:	 

AssemblyTrademark 
( 
$str 
)  
]  !
[ 
assembly 	
:	 

AssemblyCulture 
( 
$str 
) 
] 
[ 
assembly 	
:	 


ComVisible 
( 
false 
) 
] 
[ 
assembly 	
:	 

Guid 
( 
$str 6
)6 7
]7 8
["" 
assembly"" 	
:""	 

AssemblyVersion"" 
("" 
$str"" $
)""$ %
]""% &
[## 
assembly## 	
:##	 

AssemblyFileVersion## 
(## 
$str## (
)##( )
]##) *≠
~C:\Users\Hendry\Documents\Visual Studio 2015\Projects\WebAPIMVCSample\Binus.SampleWebAPI.Web\Binus.SampleWebAPI.Web\Startup.cs
[ 
assembly 	
:	 
 
OwinStartupAttribute 
(  
typeof  &
(& '
Binus' ,
., -
SampleWebAPI- 9
.9 :
Web: =
.= >
Startup> E
)E F
)F G
]G H
	namespace 	
Binus
 
. 
SampleWebAPI 
. 
Web  
{ 
public 

partial 
class 
Startup  
{ 
public		 
void		 
Configuration		 !
(		! "
IAppBuilder		" -
app		. 1
)		1 2
{

 	
ConfigureAuth 
( 
app 
) 
; 
} 	
} 
}  	
ôC:\Users\Hendry\Documents\Visual Studio 2015\Projects\WebAPIMVCSample\Binus.SampleWebAPI.Web\Binus.SampleWebAPI.Web\ViewModels\msBooks\msBookViewModel.cs
	namespace 	
Binus
 
. 
SampleWebAPI 
. 
Web  
.  !

ViewModels! +
.+ ,
msBooks, 3
{ 
public 

class 
msBookViewModel  
{ 
public 
msBookMSSQLOracle  
Book! %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public		 
List		 
<		 
msBookMSSQLOracle		 %
>		% &
Books		' ,
{		- .
get		/ 2
;		2 3
set		4 7
;		7 8
}		9 :
public 
msBookMonggoDB 
BookMongoDB )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public 
List 
< 
msBookMonggoDB "
>" #
BooksMongoDB$ 0
{1 2
get3 6
;6 7
set8 ;
;; <
}= >
} 
} É
îC:\Users\Hendry\Documents\Visual Studio 2015\Projects\WebAPIMVCSample\Binus.SampleWebAPI.Web\Binus.SampleWebAPI.Web\ViewModels\User\UserViewModel.cs
	namespace 	
Binus
 
. 
SampleWebAPI 
. 
Web  
.  !

ViewModels! +
.+ ,
Users, 1
{ 
public 

class 
UserViewModel 
{ 
public 
string 
UserName 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
Password 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
}		 