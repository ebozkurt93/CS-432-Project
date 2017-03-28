﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabExampleClient
{
    public partial class Form1 : Form
    {
        String auth_server_pub = "<RSAKeyValue><Modulus>y6T47THzsHpfjWz1KWjdgVy9bp2zsCXGZ2k8FQJlvpw71GpvKtlmrkOdFC4Yzz+OHqCeG37ZTxWKPfinfblsxlpASZ8G+4DR+d1JQFtSTn/6qz5LqCZK3KwmJGeK+oqsQ9S4h+BegCsKtzZvmd0nNDL/AhKkFb3c/n0vxie+II8=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

        String c1_pub = "<RSAKeyValue><Modulus>xVgbo2zYYWeF2XrfKTJG3f7wul5SmiXs9egTA6S76M3wiUw5YwyhUTMVw69hRBvPKzODKU+HbGE6luEhTPTdUL0+uZGpr++UYx3MSnbM1w5Y2wDui8rTOaSCjl/F/W3oEYDBojdwUdl7b3DlQ9HgmvP3n75a35dHw4oXakB6hE8=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        String c2_pub = "<RSAKeyValue><Modulus>2b//kAeWjocoxhX8kKzKvZ+Dlwbnp832Fj/f+05ePhfi/NhnR6EZar7LQCUztDD9pY/jGwNnH8ZROm5JEF8+BUwYWuMX6sm721YccD4yew3wT/fOpZHp91Iobf37Qnd22sDLmdl3n9qonxUlT5iZ6Bg8dMPcgiy+JySyViiD7Mc=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        String c3_pub = "<RSAKeyValue><Modulus>5D+J6tsUM/0cy+jzCE8ltPq/lFNJNieofd5Vq+MEnP3VY0ANa0a7IHNCJSw1nxNFK+flbCyy/rYiyfPXCUXx1TyFmIwmAOUgtC+z221diSX/8r07/97earmtkKwvB/Q/J/iGbPy37K4Km9FaXyw3YNOTtgVrfOiWSfOPovZuq38=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        String c4_pub = "<RSAKeyValue><Modulus>ur6gCKlY0jMrj5d4hEuFR4G3ZXZZ9HjSiA8AXt9uWh/3l/rlzOnChzGJ4/6vI1c+fWZdo1FVLfW+zcjMKv+xpvP4gvXYyUaoNU0lnwEmLSVIjXJiR/bZIZa2fEgKe3U21WjsfQKQjo8/T1oWVmbXgt1mhVJflAOqqlSmQIDDgbM=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        String c5_pub = "<RSAKeyValue><Modulus>z920HZ8KaS+oedG7JREFe+DtC86wSUc4BUohYozNldkWPvuTo73ynQ7AMR0hdG2xs6200XHppndSBFM8J19MbpmwR08WwoMfPjl3Xh4E5nhwagJ7FTN55Ygx1RHw+MZ0ilSZlDdB8CafYKypElGx+SFlQf2C8ObwGa1fwKL2m70=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        String c6_pub = "<RSAKeyValue><Modulus>n9FJWocsROsScR6QpyDAJGRFE14U/vycTDovPRuwgQt9xzh06PpikJ4g0RM7N5TiXgsPq6Z2iI6Z6cF0E8SKEn3M5gMa5cFxQd3TAmOeUW5rZt7Zcx1iaDBHKyoNMJh/erQV4QZqv9l/NazZxHjRVQlcSyoJKAjhE8yUYgyRePc=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        String c7_pub = "<RSAKeyValue><Modulus>xH3uUHrZKaqbcXUt8AjbkK1WtiWP+bshXZoQBYkbtlLvz/iW5PtioFNgkXt/LNZhOLhtLvZLDtLgPUEYqjyZKnMJ1QERQu7iW5H8SijtpSbx/z8JkgMOG+bAsyq7JRJqVjrCcqPRqZbo43rsh8pRlOcAAXkNdZjcg1DGEWdrlFc=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        String c8_pub = "<RSAKeyValue><Modulus>rwhrg/MWxi8Dtx7vtj7O8QQX3GySuCBrcNNhr/i21GyBhb0mcDx4XmEdF2ycbAHl/Qqu2eSmny/PuNVZEcOirkJD/+LFPVGQWfyqg82soqHbXgSLYjS4e6rq4+xymJwRWw94yHziE6i1ErHMr4PDFln9G6xIDK3ofoWMpzq8qMk=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        String c9_pub = "<RSAKeyValue><Modulus>v7k/KQf3IHgYX5jmmTQw80n0zP2yflqoUR+IDdKlZnCfMv0nHGuhKMWhpD3B3IIwUYZGJ4iGVruaZlnWAvQBTuz+WHGnEaPu9JwANxjLBxdNndCCdVm/kSI01W0xFOBAikTgoHGH31s+9bb2HNV1bufJLk0xghSsxoxWin+VfZs=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

        String enc_c1_pub_prv = "7F0C64295BB2DD4762B16FE89CBE3CF947A7021C134D0D353831754CADD16F74A4711E7A05891FA54475918A955809750AE3A95CE5E60124F0C4FD92CE2C2D7531118ED488307B86C1644A43FD71F94542E23F068F342094AF3FACF0B08BFC479AED126AD87B685028527E26798A0C314A36CF2EEDB092016C650FA2E6E3140F81753DAE059138B47409FD25849B3D32F4FDBFCEC595309EC87E839C1E1D915B243733D91B1362622CF6CD51F0C7D0A41400A9E70A78BA4127824494A6A7ED9731256751695B7EC5761C51C26EDC969C5A8BD0E260F105BB95334F9F057451C23740BC4C973F4913A6528DB4BDEC45EE1F8692589EED7459F9E26F58C943344D6BDF37CBFAB7A71C54960BF65D0D397EFD37AC2C4820B885B83E9703446E851B0301E456CA0D14CB7E582E891FEC052B8DD7E6D52D0DD02F20CFA51E785218F9D9656CF16D30F173C2201AD8087B63BE8A34D650CCF1363F462B1E201892BC5896B563E6972F90F179AF70DBFDE6F70C73ED8FC6970B8172C1C4D919905E09DD9F349A8C9C90F34BA386531B5075DA4A4B14EBAC27F8782EC35DA1945C1425409C8ABAF0476501262FCAAE8ED55A06F9A44BB5A53AA99E2F2646D095A54C561FB46A069C14ECA4AD3C9A83A087A894712F28ECD1ED419A323B5F8D7181FC7D94F30934295923E6C6500B3266D1FDE4029EC701BAF81519CC2A8519939F7110D38C0F6BCED901554099BE6968D3B7D7167874CC31BD1308686DD5E8EE1DC99B971565BF0F970AD5888FC291EE567B71BCACFEA1A2DB6AE739330B3092582A92C280CB3CC24D6C5734B5C7EB13C5E780470D2F8B46D8D4A29BDA8D43B2D9A09C07DD4C62DD63C156644601457719B57C064BB734AB0611A7A4086C5A6A805278E51D7028BBC1CBF618A5BC802F2C65A0BE89FED084A2C992AA64307FEF2F6FADF82E0406F5C8BEABA88709457E156F1453771085AC028215C10D87C2D83CFC98FE988ACBC2BFE3189E3C782FFAB0CADF276761727081469A8567FBFD8632333C6CAACE8DD8EC6A31B4E6DA5E8F3DA01889167062E234432BA9C93CF305CCB180B3E3350A055FF28A2C621140CFB3FD6BB9955128CCA63ED423A83F8525B4FB98E2E8DCA6D7F08D68739024CE40E99FECC0F91C600B117B1BF49E60202D0A2C6E4D6391E96A6B35BF0A0C6943E6461B2C18BAAF91B6934F9EA573B245D717F9C722F870BF125CF27AAFDB4910BBC8EE3F24276C75F5AD7E29B3B2E696097EA3DE6E92D531E5D42E4A5463A0ED0EEA2AB8A0D6B29C132175014C64685E9D10FF8E48";
        String enc_c2_pub_prv = "2F94653CC51E681D5867EB822B72B6F5EAED9B3D2B91C0B190364072BF09D99D63F144854F9FBD67FCE8B772916AD1E24FEC9562C0ED617F9C7A42C9044073310CFBCA12BA8BA1F24D25BB5192290B34025F9585CE956A9105B3CA77B0790D03C6CE305959B2DD1304122CBF2440BE8E8D952F70E5853C2A063BDA92FC8BD90AC0AD06468CD42218A86C9C002E8C4431F859AD4885DBC7DD3F90B95BCFC435F3CF409520B2051AA48F74709049F971D7A1C743A57E2D215FFC51986437F9C8A9EDE11AC358A5FDFC5B729B6202D2D537B8CE29FA6FC26319CFA7D0FFAA68B9AEFE62A1F4E84D4924BD6153B0D4CBAD9068DDA0AFBDD1D61E0D057CF64372627FA94B9092F5B339DC5C609BAF55DC24BF9E33EFDECD40B07BBE4E3F1FC8D0723CF0E31EDD9C59DCC6E26594247DFCFC7A3760F5A986C6C3A513E8AB776E389ACEFE8BB956550D18818409CC73DFA722556AA16B00BCFBEF35457174BF93DBEFED97EC369D70A0F5FEC364EC1E1FE4CE8CEDB31BBF479EA80254AE74DDF2201F039A0729EA3996ECF573FBF767848B1A641B847A2355CE57846258CB2794299B0607D7C74BDD71B246BB90246CF1F9025BF1A886CAD1A505E57E4C4E099CCADA660A460494C08AED0E2BBC8734BBE494FA9ADF0EDC1229C4DEC8F386C1190E2722C8455EF3892203D6876FCB14557815A9DB799CDF6AACD3C405B13A1B96EEE957CC1AC287BA46D77F3466B2C3E0AE9CCB8A99F4FB426CFFBAD2F2CC349254603E50E50A8EBD46F0B56FDB44A4DDD7756134D47A91D3D2BCA593CE2E07734915328AAC4514602132C463DDB1379CF8F0B16C2F426D60B1CC818DD0A7AC006C62E2BE7244A4A65D4B1EB33D90918AB0BBB365FC99DF2C9C668F268EDD5DA78893F798072143EA9580F012DA0D1DCA5A99AB53668D3660F530D0ADA74741646D46A17CCE91E7DD7BE9B9B68A066721E8394A3EA4C36363D58FF99EAF7517EF5CE3EC7A7B490FF7EF5E6F9FF36C5FDFEF893C81ED79740093948C32E19F0748BB85A3BC371825AE874CC6FAFC105010E60E402EF2F8C69B33D2DBF90C50D9E1A0B00C95DA2CC5E8981FA81A580E8505E39E8876C5A5176CFC1DD448B5D3481EC74C58BC8C424876ED9A5D160F6F1C22CD7843A74E3A5ED458EE69346F1DAD7D5D960D3EDDB8BDB5922E0065C0767DD27E877EFD187BA19C3D67DE102ECB46399BB06C7F99F957F4EDB82E63510660ACAF673E937416A7447431A652B55640DD3BB5849A9B4C117ACCD233FD8D5FEAA60661E79AA01FFA952DD2E7C2A999600E81FF97";
        String enc_c3_pub_prv = "F6A1D6F3F41D4DD8865369CABAF3CD5403B4C5DB8BB8BC28DBB425E90585F20C6C2659FE893B679E791676E55520BBA98A5FC62DE0367EB1F1E330972E0C012FD2D66A2582AA69E5DB8D8A1A21CC954AAAE20FA0154473507CFA358DA41A53BB0E10D2C2E377FED3B35B731200CD1357EEC66EF7864BCB661439A304613862C784D9D3074C6CC7A9EA87ED9EFC7D1254EB38820EF1F3677FE5EAD94A0D0DAD8EEC477260747EB715E5916A0B8D8651ADDCE5763AAD623B2BD1653F3ADFEF94B49AF97331F09B4379A8CFA0EB792E15DA0F6FEDF1396C5FCFE673559543D3D2E2B24076BFCD32A3F764A4B81AFA9E7DA04308E2AA8AE0AA4EE1A8D4BBC82B157775CE8B538EA37A50951F65674983EC0CAE95909E81846C1B4492067693F6D42842F6385A177466B6D5D663DD56DEE3FE0A116C725A6F4881EC8A8FE8138C4B4A745FAA2182112BB9015E22E7FE5EBCCADF76027BB9E9905B7D5ED2169B9FEE859009A72FF10BA86FB970C8F48B4959CE8F4942385080274636C2DB48BB6B0FFB9C97283724D1560E20F4715E513A09C9AEB13CA0EE57353C89CE75C175FBD2BFFE35C2A85E447E03BD9AD259167E01AADAFC7449487A6EA6C326CC89F611685C7167AECD153929E3FEAB99E76701CFB07B89DF47E29C2C07CCF98503336ABF7B578CE7D6E6F0E3ED89C1E95368319FCC40ACC44049804EABCC999CDBC57877321085151255F3DE4D21CB3E3DBA7CE83BFCC71C62F774CD41D6BD83817EEEAB5C80BCA824FECABD92EE8927AFFDAE5431076199DA4AE28E8204391BFBB882B86E41CE9A1AAA901C84A47D033F670CE907E61F55A5492B1150D4F85BE9BBF14DB63356E237881F1E57C76A764012C3F20B26689BFF653645F472A687E7D6554D9F6EC53E7E3512F9D0132BCE31EE844B7CC906B3D66A10B319423B0EFBB038D090E1D60120BBBA29CB288040237E8427D6DF4E0DFF73DC70A79B287F8B167B2187F7251D959A98E99D1DD6EEBD67BCBD2FAA9E039875864B09B039C0B93A9D483EA0027662EF8AB49F14E4C0F2667DE35EDC9EBCAC1E00E7EDC5364B635966551F4B1570A8FC24104313C4F76F0B32D353417E0B17ED50A98EBC4381AE24EA7367CBEC606FBFAA007C8B514D11D500FE2CDF9F7346F9DC7F2D09A1766ACC5C048D52DC1B75224F44F1568ADAE8AD4817CC61583AA3A2FE2DBCB70D20F57D5287F8622C6A7C74C788A95A04DDA4AFC9DD06C77604C42E04DA613678F761E024656D4CD2A9E29AA8A5939456F88AE5F14CC5466CCA6A03754E463608ADD00C192DC8";
        String enc_c4_pub_prv = "561BD6890BEE38A4A9ED65E41E7D857780279720A82D37F284CF2BB6123C206110804520B9962FE103099941FF1A56B4F32635F08FFB461E97532CB33331965DFA6790D3EDC17F4FC7B58DC1C966742E58BA1937B1C2D25C58FCD2E9265C5A5BFBC78395884C79270AB38E0C6F8D5E1279AFEA5CD4252F6B76BAACB3F1EE797AD9C39558B43D1198C1A867B6E96629F97A9BDA37F6956C4C65AEB5AEB86CC856B1BDCC11D28DF958C3F44D4E59B5FB875BB5EDDA58E55FA693533944753ED13A81EB4145E7723799609F278DBE52858ADF86947A681A009637F3BFA478E5E6E84848BE10EAF8E9CB0C8BA1BA8A49F800EDF65A827A81EF2A688A403B4AC0604F5F230891A38D9D2A6F66D75124DA033E5E2A220C01F90E4A88DCA93F55BEE52F0AE0B8A64C36A0FE7BAEBE60E4A3BF239E7417979A8FE6BBF83499996222BB6EBB1E9181F7AA4AEDDFF5FC798B57AEF7CE4EC4B6F694EB09BDEE2E08F1D660B4CD1B4A009FB881C014D1BFF34FA53FCD6B46D01F22F28232FF06BA11266053709957570BCC99C6B6FE33452452F3B0D83C6110E21ECBEB8F1EF1D108F405577B57B7FAD1421CC3A9BDD01E100AB563E59D352C3C0A5B7F35B1E129F0E7CDDAEBEED6DF931D2292B25533E08579100D7528151B4317B7FD60064F3D474451BBA31C4A863CD1DF224C03A7D55D67E1AADD79C4BF6E4780A92CCB8CED1671621031191D60D0489FDCA9FD10AF54BBE0C4BC0E0895FBCF87ED023D4381468870754E80AD70E6E671D0835BCCBD86723074247CD79BEF71330F25AD8F99451C0E218590A6F826B11D3CDAA17E235D0BCC9A6A06565788FF473831D365F814D6E43BA148A5802AC83BC10E7252EBF416D63742C99B538FFBEA4D04D4FC56A56347309BD2A3DC04B73C917D9EA7C1DB17BA5B739DBCAE3AB19763EE12A81171250F58A8693F4873A8B01FB1B25B7D7BA7705A9405325CC7A84E407060CFC035001679E840273FB2DF33CC75302908FF5F69382D1D45F330D724CA73A2F57074A8BF1D98CE480052D65D57BD634A2D6A5566DCCA91D379EC814528357E38C6AD86F6BDF76C839D113465A1955CCA0C58FD7A7FB6332E93126877FE0F6B93C75C4459055F5BE70E0B58E9A0EE025CA1D54518984DBB3E0F0576BDFEBD2978D0725F8E395F24118E220AB511161F35240C5295A966FF2DC1279084161CC54D812B6B1FC1DD9B70EFAE8C93EECD691F50C10B7278870C416525242F2977FECACA0FED9E048162F0A5CA04237696B1431D8293FDB158F567D6EB53A5BDD6AE762716FCBDF20E";
        String enc_c5_pub_prv = "72EE0A1865B07D1E35538D5FF73992C2D6C32FCBE1E7759064D9F7A3D2AEE73A37D82D0DE44BEC46FB41673ECD2BB566836AF91834EF6E45713BF33AE6B9977026956E378495F12FD68E4D22C3A49ED0E54BFC0252BB525CF250C6B4350A90EFF765858292D5DCE5294DF49AAC28F980DB217BB20D46A007171D489D06AD0740EE3F97106C4F1FE5D0FF03C2826CEB25366AC2375444B44368532067B8C7EA27EC998BFFADB7B25CE1F39A74B6BB0258D804DEB67C633FD50C7587CDAFA1262DB6C31ACB2EF449C7C9D220A5CBE701426738E4EAF9E8649DB6F6EF21D19A69AF2D792DBC4132FF1525E68496DF61AB77718DEE8F518A76508D399F5786E61DB1A85CCCFC27FE2971AC69BB0340EABCAC5867EA5737F3D90AA117C9366078B641E03886709D0017640E685BD709658EBA2B562105FC763BEA8D7F9F74E99F01B17BC67DA62B30239EA224C375690BD41B38AED525B150BF78F925A9B99012E8E880B25D643730EA976ACC4BEEBE36F51F92B3ECF85C15DCBF5A7D336F70593AD95342EC0D7083FDD978717A22524C9D153356D4F2CB4FA09B87556376EB4934ED8A501EFED8DA0804225EB247B0E90F60E1FFA1F466AC4CEB351140CE20729B8F35738C2B636BC824288D892B7A5A098EAD38AB3222B6757747BEC34C3FC91B09B9B28FEF04078A3623E09589259A827080FCBE903DC5D04C942192266735171B7799AA71CBF5BCFADB193CBF365AA41567CDD2D5069751A0E15A31754643496EB9E590B7BCE47E5B382EE61122EA3C492E80F22B1F5A516BC179C7F6589C62AB3D97B93EB3CD48C1CEB47218B396DB7C8C5CA96A919946BA3E3E7C30A28DC85F42EF97BA00EE9C1DC5C87672FBF04DE11B811B6B5527709A416D9F1ECDF10A72F5081C6AFA71DE6091CC3537C5668EA96B80DAB44B179AAD056D70DC14FB544251A00B340F1A73F4FD8B4F9D8A62DF6CC6EEB327488DE1A7664B9FF08879D0820BD60B086824B22FEBCADF1601487F8D3A00F9CD7D45F39EDAC90B54259897A540ACE9028B5805EB7AE9E830A01021A1EF57B9E159EEA9B1C2948809A852B26EA7FB2340BBA75AD486DC8CFFC83FA91CAEA3C57E98F240FFDA507EBED942FF30760AC5EECC8B413DD0B10DE5A72EF9EB25A336A29BD76CAA4BD21FBFB5D8323C50A82CA517C3E482E6322DA63A973E3D065F3A4B6B03A73F182B15D84F5DCBD5333D06DB21363B30AC4F25D250945BE6E5FBB38F77B1B36B688F20D5F970AEF3DDE1E71ADDD2126EEF5D9DDB82B033D41987B19128D865423035D48C91E7791E";
        String enc_c6_pub_prv = "BD2986E4E81C7B9AC715F299659E1F4B73A0BC7ED0B6B9A2DCAA15DE98B511398117C3209F27242636527C38A7B2C365107B9A7D657B0384BE680B5B037A350FD9F920154298C17FDC64EC6A1ECEB6DF788E6BB45FBE4CEC8C3B8DBBBBADF398E41C70FAAB89A8E7027FD9872DCA27A1884A705AEAFF2A9238888682BEA9E591178794EDDC45CA19E19B267F8415F2A1FDB6D02E538E5424886D5A597FDE2F09D91481B37448DDFC0893C0DE80812AF6B66C360F58A4F687A7F7555CFB2C56CBC891D778F43C67134AA64E4E121E3CD14FB0FCB35ECB0CC256A01AA5A17DBB0AB9D1DDE72EBBD41C640491699BFD30AFD62EF8CA35024B36F2C8E657CBA293A2749FEB354A48CB63397AD37F37A0FA7B8FCAC315ABECE8914404E4D49B70121F1A0DAB663BD7B1DEA8C147C8D7CF352C09DE3C28A935B4B41486AFBC613F24A0793255E3E39D932631B74166925417576E76A0A9B38473D7B461637DC51C5F6A2625362265893C3849542D7C61EFE321238FD3B327151FF93DC491358C8FD7D9AF1160D9252735459608486061E407AE590117CFBF72553358AF5CDE8D3392F0623A3D42CA2781AB56D84B27B8692D31B7F474C19B092F07622F2C5459859C0BAD39F65F3CDC43F28808FC5DA8C3FA231349BAE2526553F7F151E148A30AC99111E321E3DB7CFFA37F334A442B85849CD85BE223490486EFE50CF9EEDD6C7E2B59E85B7AA8BB9FE79300C986EC8D5FD6888FE52B786AE3E5343640BE5553485FCC4D20E4D218E4DC876853CB9EA30CA2244E335C98B0522A9782D84E7AB5BCB3A3781C366FDDBEC1A88521226576D80FFFDBDE4140757248EF2A73D02F7828EFF531ADA7DEAEAC0FBBD9952C61D4D073DEDA3651D6C12EB7DDAEFE511794FCE1EE41337517124C908A07F95F3E82BB2D05E7DBF57AF0537D8FCCAC87041E6BD35E3D2438542D4B2294DE9FD1BAE687AF20BEE66BCC1F3E0570549E0CC64DB3C9642DE6B047095AAA2122DFBFD1DA5CB5AF297DCFC36066799AAE123256C49D65C18780D6C1C0C36D10CC2B31ABBF1DB598BA6704280D448EEF72278E610E0ACF18FFBE65C9777D2573D9494DCC56639455FD2BAF53179991E4F61DBD4A35E5335FB74727C335C70E415FFFD5E014BB97111AB1AFD626F88E0194C6733A9F2863BAD63D935EDAC5E588B28C035B414C78E3EFB76F9B1999911CC3FC26EC27E65E0E4B83A8A3F1E1E0E996B1E05F13C9B80F5034DD9C4F8150B397100134BA9B5953ED5953BA6979BC35E99CD90FBC51A03506A0212AEC7AE3CA752ECEA11170FB";
        String enc_c7_pub_prv = "9D54200BEDBA22B873C8F960B5C1ED7AC3EC3DA387749190184E6F7C5CE6959FA0AB77DA79C929DDE4A3EF6B28CB28CAFC5BACEF1C98E6CFBB6D609967AC48B3931E78E7916DF361D3157FD6A98D975A3053D33A1FF79C92A5A5AE6FE87A9BB8C7473990E7F18FD8E1F678EB56864D3772D7B275D9E861587D5DC98409A0BC5E9F00D4DC4BC78B4A68B2E5B948E3ED75C63ED083894C4D28AC4798E0DD5AA7D7574876E037572F371D1EA8133B6B9B0D87BE392BB62350B39EB0B8BAEAE59456ACE04591F3621ED4801498FECFA6084A30E69A6CB415957043C23E44E30CACE119B7FF80C819E985124C1DA83D1BF179CA0C5CD7E4FB70F1A073F2022F31EBDD55C971C101FF51D5F40022855833189B1D26EBC88EE3C5F89FE27D7EE7307DED528DB14EA3EB1A84CB1C1A0EBEB8C0151285000C967A832987891EFE57FCFC44D956D764DB81B3B57B167D41624EE03431364CEEB03D12DDF92FA2A70E537858ABCD1B4A663E7A7C0C0667C27223473A6997F819457BCA1544F3DDF2245E14F01E1E7015AB673C53474F2F0DB0BF2A0E76BD2C22F33F963B82379B34ACB30634CF2D29D8AAE8085980D72323DA6A9015DE3E197C3EB7AB68D5C80816ACBBC4C0B13867C4574FD4FE16178BDA1FD61A48E04E3656E15D58B224182CEA93B0EE8CCF45825246207DD0DC117FC3BCFEFE77851A1F667B95096B49E69453B9A14AA14DDE1298608090CEBDD9D2205AB7CFF976B136950F7125B3C0320C264F901F449D1B5EE781DBA93ED34BBDDAA91307200095C6162FEE148CB839793D7D0B46FEBE4C6BEEA8227269A6CB5CD9FB9F39D8B72B6A2E2DCF1AC808854CC76799CF42E65B8683D0760EAFEAFD50A75331C4F40E9407BB8ABE49A96B93F0B7FF34CAB1C3BB5EF6294B29FB702B595BE890E500AFBE1F11AA7FA22CA55E67B7F5778FE6BA13F5161F52DEA0FF41F16CB516205A5B75FDEF5E0DB7E22F3117A2400945A4950E3ECDA4CA0F8ADE7294DB743E3787DBD510ACB57CC2B3C0581DD2CFBE7A397244BDA02C62173B9830F6A85AFA7A599A9135FDBDE21C234225DF1A470B0D94509A0182FF74E52E69791B8FBC3E43901E914DEFA0F942300E8891D80686DF62A18AFACECE45475C46A93E06D6C37011360EF83E9F9E3A679115E774B018ED76E73B201429C0BE9627517EA6DF4B0BA2ADF5F4FAF70D8C2DBAEB7545FD0E59E2D1741616A609B1F3E3A5AF25F0BD20800AC0352F2DA2EB3CB48EA300035B9EBEBE82BE60FD3A570AC0E189F64DDB07B5C3C77A8C351C369488DBCAD10426216C";
        String enc_c8_pub_prv = "9CC53C5CF475F0E85076E94886FEA90580BFF83454FCC756780A1227F9AB0C327864A7A91D4BB93DAB1E8666AA76F7ECEC2ECA0D7691BD79620D3965D6F7EB85248F5C12ACEC7398506BDE2456E68440F73F4DCA975C1113CD778E01ECB839B9B63FA31D57AE8FE763A8D04010E69295AB8FBD35D1F5FA19892BE319802AE47CCB90483733A196EE5E0FE83A3D6D6460E32A2FD31AFF9B96F1815B5C00B4C938250FD9DD11B1477E82BCFE885352A1AAF04A8477CB8B46DF1F10F18D59BB0E541E0ECF70599B96E1F6AC69C6AA39A5520CC045C1DBFF548C9B0981E4272D9E666FC93FB99973A066785E59B9BCF91856D9FBA393F001664A9F21C053418F2173050D8FF2D9D9ECF780EB22411BC77E767AC7511AB363B4127B1FD1DC63D1D6386628CB78A0BF365440BD746A0CDD2B66F3625A562B2B2F3F4C51621979A69EFE60C72E8E14D210DD8541FB7B130A38E0EAD3C92520EE6E0E73F428B4616630553D3BC4D89B22AF1EA755AB81053AF321947DDC1FC5AA4A1C401E87F3BB7AE36415E556E663397CBD5B807594C05D59B0450AEED13AEB23117FD62009169245866353685963103EDB06987FC238A805DBD3E1AFDD5BB60D508A4E1BE32352B7827336F1ED898AEFDCC7919B5EEF209E0195DD3823186B3B787438732FACC2060E4F5ED1F1C0FD862DD2E7584DEFAB934997966E4A017511BB6A599A6AAAB2DF3169AD223B29A199953D5227E3EA76E9ABCDA8B7881EF8210E3817564C8D328E5189D62EA91A1FF3DE4C8454C6149386533E072BF18491C92638B3A7EFD5E5B03239E8CD660001D4EA62CD3703B79664388484D785EA3BC709B9DC8906E46D09E577FDF9AFAEFE4757B6D0866826F796569B3C6CB5A51B95D9C02A37391E752B8CB4700A9A575012F9A071691DA5402F04EB9E38030BB063DCCA73AF95941CB93E11B7160B8FB48EA93A13B0362C1BDAD7490D24A6ACF18FEB1AF1035AFED9C6C981377E56E0AE98165E805694454716321CCD7F1C3C16F25D5C1466B90E0D521662626E552CA3A31AA3A7ED29286D0B07CDA5B35FD0C94D312D8AB456F237D2D3743FDBC55BFD5532F769936E876BE98A31D0276CAE96DA4E77F85529FE8F50A5D46937673E673C4DF4D5E204151CE6C15343B58D305959808268E7DBB40D1D7544970F22E14A6E992AD83F8546463FE32F80E20DBE556D8DA9AB56F9972A4694387B2450CF5F3AEB49E63B68C49E98E460ADCF71F4072C6010CD8987DC942E3DCC41549784B691256F780F28E20072B3623ECA5D72BBC30D7915E78743EAE1C0";
        String enc_c9_pub_prv = "2FF78D30CFD2DFCFA77694F82CD5F18CD5FE9196603F694ED3466C07F4C08C6FCDC5521D6444E701B38C12009E1E2E6B224284195257C2EFDB4DB43CB735D1B5B5FA1A6D34F4E53DF9CB491B1B380E96B8EE0AC7973B41F03FC39785011E4C6C4E01CCDAC42F139B0C603C4B3B00FCE035110165C15E5710FBBFC181FDE9C9D9679B2DB03D22DB426AE7F69C42A087DC048AA5518BB30DB924517252562456811FE7BFC3271DABD0B831BE0AC707806091212A62D8C33CAAF3A74E9999D99ECE93A6E5D5B896E8A69C539A19B5AE65BABA9406F38A0D0CB90FBAFB7320F950BF889FD3044397F2F14AFB594A174323BA5ACDA5A4B534BF4AD4BD7C8D97E199D2319876EE12C16E1D71516F1FF0A0BD10D450A4808FB00C229DD671DB5B6D771B5254F7AB49050CB883C8E37FD48A6D2C8983B4F247D5B174FC42AB82D1688B07226B6862C7CB38402EAEE32FB43D79F103BF0F9C1EA4B4EE379D34F416A7E67B86F6BED89940FF60D4EF9E3A4489C4DF40CA83557AA5461B53ABAA23F744228231CE078883B5D9B5F41AAE4CC975193E8613F674A6954C7E27A6FE4D9815E65E6FD26200C69C523CB3F7323A6ED33D9FDE6F1B0B361312687222CF672C3B45E4EFB12B7CB8C964CEFCBC275F068501CC51BD6556E8AD37E32A8DA5DF842B411BEF1FE81FF025777F4C17D9BBE2D8BBCDBBC95905484F5107C20E7152985A16A485EF973E40A6369C37C849BBEF77DDC532EA16867BFEF311BE7A61470BF8FC596FB3881914F55444129098ED5F6979CDD2FDD1DEF9DAD5313F42013C4F84E09E5E1D3AEE21499764A3554957B45FAD2ACF8D849C049F66034DEB9DDC2FA07438FACFA7E10F977697C750B0F85C4B1209E0E811EAC1616E80E6DD15DB00DEF604CF7982316F1B8B5822C5E252B742988FF4150004AB8C66D449420BF333442C5CFB59FD605B3FB9860E4F0F50A0AC83D9131819EA48615BA216692C3B873B20D0BCBA42DC7CBAF31E97F86F87289BF9F5384A85C44C17967AEBD88620402B2948AAAEE7D6AE5CB229B610D9A2D3736D5491091C0798F08C1E146FFED0298526560EA4FFF375D5F40C1ED73AEDB6D3592420F7FB70954D2BD83830E9549BE0F3EC7EDD7172741AE8BB7E9871A32AB5A7B8E72FC40E1BA29A0B17D30215ABD351E60EB2768D263956D63F58FCEE5AC923A6CFBAA1CDB0D1174A21C6308B7AE3F5B9C59CED9453A89DD0FACF729FC058BFEA9DDED5D7C81505A68DD751879476359E107DC511C5DB05DE026241625713BA8E11E52CECD4FC8C320E2D3A4F1A0413DB";

        bool terminating = false;
        bool connected = false;

        Socket clientSocket;
        
        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            String pass = passwordTextBox.Text;
            byte[] hashedPass = hashWithSHA256(pass);

            byte[] key = new byte[16];
            byte[] IV = new byte[16];
            Array.Copy(hashedPass, 0, key, 0, 16);
            Array.Copy(hashedPass, 16, IV, 0, 16);
            byte[] decryptedVal = decryptWithAES128(enc_c3_pub_prv, key, IV);

            //textLog.AppendText(pass);

            /*
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            String IP = textIP.Text;
            int port;

            if (Int32.TryParse(textPort.Text, out port))
            {
                try
                {
                    clientSocket.Connect(IP, port);
                    connected = true;
                    buttonConnect.Enabled = false;
                    Thread receiveThread;
                    receiveThread = new Thread(new ThreadStart(Receive));
                    receiveThread.Start();
                    textLog.AppendText("Connected to server.\n");
                }
                catch
                {
                    textLog.AppendText("Could not connect.\n");
                }
            }
            else
            {
                textLog.AppendText("Check port.");
            }
            */
        }

        private void Receive()
        {
            while (connected)
            {
                try
                {
                    Byte[] buffer = new Byte[64];
                    clientSocket.Receive(buffer);

                    String incomingMessage = Encoding.Default.GetString(buffer);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf('\0'));
                    textLog.AppendText(incomingMessage + "\n");
                }
                catch
                {
                    if (!terminating)
                    {
                        textLog.AppendText("Lost connection to server.\n");
                        buttonConnect.Enabled = true;
                    }
                    connected = false;
                    clientSocket.Close();
                    clientSocket = null;
                }
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            String message = textMessage.Text;

            if (message != "" && message.Length < 63)
            {
                Byte[] buffer = new Byte[64];
                buffer = Encoding.Default.GetBytes(message);
                clientSocket.Send(buffer);
            }
        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?", "Client",
                MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                connected = false;
                terminating = true;
                Environment.Exit(0);
            }
        }

        private void textIP_TextChanged(object sender, EventArgs e)
        {

        }

        private void textPort_TextChanged(object sender, EventArgs e)
        {

        }

     
        private void disconnectBtn_Click(object sender, EventArgs e)
        {
            //clientSocket.Close();
            //clientSocket = null;
            connected = false;
            buttonConnect.Enabled = true;
            textLog.AppendText("Disconnected from server.\n");
        }

        private void clearLogBtn_Click(object sender, EventArgs e)
        {
            textLog.Clear();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {

        }


        //take sha-256 of pass, decrypt private key of user etc


        // hash function: SHA-256
        static byte[] hashWithSHA256(string input)
        {
            // convert input string to byte array
            byte[] byteInput = Encoding.Default.GetBytes(input);
            // create a hasher object from System.Security.Cryptography
            SHA256CryptoServiceProvider sha256Hasher = new SHA256CryptoServiceProvider();
            // hash and save the resulting byte array
            byte[] result = sha256Hasher.ComputeHash(byteInput);

            return result;
        }

        // decryption with AES-128
        static byte[] decryptWithAES128(string input, byte[] key, byte[] IV)
        {
            // convert input string to byte array
            byte[] byteInput = Encoding.Default.GetBytes(input);

            // create AES object from System.Security.Cryptography
            RijndaelManaged aesObject = new RijndaelManaged();
            // since we want to use AES-128
            aesObject.KeySize = 128;
            // block size of AES is 128 bits
            aesObject.BlockSize = 128;
            // mode -> CipherMode.*
            aesObject.Mode = CipherMode.CFB;
            // feedback size should be equal to block size
            aesObject.FeedbackSize = 128;
            // set the key
            aesObject.Key = key;
            // set the IV
            aesObject.IV = IV;
            // create an encryptor with the settings provided
            ICryptoTransform decryptor = aesObject.CreateDecryptor();
            byte[] result = null;

            try
            {
                result = decryptor.TransformFinalBlock(byteInput, 0, byteInput.Length);
            }
            catch (Exception e) // if encryption fails
            {
                Console.WriteLine(e.Message); // display the cause
            }

            return result;
        }













        // encryption with AES-128
        static byte[] encryptWithAES128(string input, byte[] key, byte[] IV)
        {
            // convert input string to byte array
            byte[] byteInput = Encoding.Default.GetBytes(input);

            // create AES object from System.Security.Cryptography
            RijndaelManaged aesObject = new RijndaelManaged();
            // since we want to use AES-128
            aesObject.KeySize = 128;
            // block size of AES is 128 bits
            aesObject.BlockSize = 128;
            // mode -> CipherMode.*
            aesObject.Mode = CipherMode.CFB;
            // feedback size should be equal to block size
            aesObject.FeedbackSize = 128;
            // set the key
            aesObject.Key = key;
            // set the IV
            aesObject.IV = IV;
            // create an encryptor with the settings provided
            ICryptoTransform encryptor = aesObject.CreateEncryptor();
            byte[] result = null;

            try
            {
                result = encryptor.TransformFinalBlock(byteInput, 0, byteInput.Length);
            }
            catch (Exception e) // if encryption fails
            {
                Console.WriteLine(e.Message); // display the cause
            }

            return result;
        }


    }
}
