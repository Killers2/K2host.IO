/*
' /====================================================\
'| Developed Tony N. Hyde (www.k2host.co.uk)            |
'| Projected Started: 2019-11-01                        | 
'| Use: General                                         |
' \====================================================/
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Microsoft.Win32;

using K2host.IO.Classes;
using System.Drawing;
using System.Runtime.InteropServices;

namespace K2host.IO
{

    public static class OHelpers
    {


        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA2101:Specify marshaling for P/Invoke string arguments", Justification = "<Pending>")]
        private static extern int ExtractIconEx(string lpszFile, int nIconIndex, IntPtr[] phIconLarge, IntPtr[] phIconSmall, int nIcons);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int DestroyIcon(IntPtr hIcon);

        #region Constants

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2211:Non-constant fields should not be visible", Justification = "<Pending>")]
        public static IDictionary<string, string> Mappings = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase) {
            {".323", "text/h323"},
            {".3g2", "video/3gpp2"},
            {".3gp", "video/3gpp"},
            {".3gp2", "video/3gpp2"},
            {".3gpp", "video/3gpp"},
            {".7z", "application/x-7z-compressed"},
            {".aa", "audio/audible"},
            {".AAC", "audio/aac"},
            {".aaf", "application/octet-stream"},
            {".aax", "audio/vnd.audible.aax"},
            {".ac3", "audio/ac3"},
            {".aca", "application/octet-stream"},
            {".accda", "application/msaccess.addin"},
            {".accdb", "application/msaccess"},
            {".accdc", "application/msaccess.cab"},
            {".accde", "application/msaccess"},
            {".accdr", "application/msaccess.runtime"},
            {".accdt", "application/msaccess"},
            {".accdw", "application/msaccess.webapplication"},
            {".accft", "application/msaccess.ftemplate"},
            {".acx", "application/internet-property-stream"},
            {".AddIn", "text/xml"},
            {".ade", "application/msaccess"},
            {".adobebridge", "application/x-bridge-url"},
            {".adp", "application/msaccess"},
            {".ADT", "audio/vnd.dlna.adts"},
            {".ADTS", "audio/aac"},
            {".afm", "application/octet-stream"},
            {".ai", "application/postscript"},
            {".aif", "audio/x-aiff"},
            {".aifc", "audio/aiff"},
            {".aiff", "audio/aiff"},
            {".air", "application/vnd.adobe.air-application-installer-package+zip"},
            {".amc", "application/x-mpeg"},
            {".application", "application/x-ms-application"},
            {".art", "image/x-jg"},
            {".asa", "application/xml"},
            {".asax", "application/xml"},
            {".ascx", "application/xml"},
            {".asd", "application/octet-stream"},
            {".asf", "video/x-ms-asf"},
            {".ashx", "application/xml"},
            {".asi", "application/octet-stream"},
            {".asm", "text/plain"},
            {".asmx", "application/xml"},
            {".aspx", "application/xml"},
            {".asr", "video/x-ms-asf"},
            {".asx", "video/x-ms-asf"},
            {".atom", "application/atom+xml"},
            {".au", "audio/basic"},
            {".avi", "video/x-msvideo"},
            {".axs", "application/olescript"},
            {".bas", "text/plain"},
            {".bcpio", "application/x-bcpio"},
            {".bin", "application/octet-stream"},
            {".bmp", "image/bmp"},
            {".c", "text/plain"},
            {".cab", "application/octet-stream"},
            {".caf", "audio/x-caf"},
            {".calx", "application/vnd.ms-office.calx"},
            {".cat", "application/vnd.ms-pki.seccat"},
            {".cc", "text/plain"},
            {".cd", "text/plain"},
            {".cdda", "audio/aiff"},
            {".cdf", "application/x-cdf"},
            {".cer", "application/x-x509-ca-cert"},
            {".chm", "application/octet-stream"},
            {".class", "application/x-java-applet"},
            {".clp", "application/x-msclip"},
            {".cmx", "image/x-cmx"},
            {".cnf", "text/plain"},
            {".cod", "image/cis-cod"},
            {".config", "application/xml"},
            {".contact", "text/x-ms-contact"},
            {".coverage", "application/xml"},
            {".cpio", "application/x-cpio"},
            {".cpp", "text/plain"},
            {".crd", "application/x-mscardfile"},
            {".crl", "application/pkix-crl"},
            {".crt", "application/x-x509-ca-cert"},
            {".cs", "text/plain"},
            {".csdproj", "text/plain"},
            {".csh", "application/x-csh"},
            {".csproj", "text/plain"},
            {".css", "text/css"},
            {".csv", "text/csv"},
            {".cur", "application/octet-stream"},
            {".cxx", "text/plain"},
            {".dat", "application/octet-stream"},
            {".datasource", "application/xml"},
            {".dbproj", "text/plain"},
            {".dcr", "application/x-director"},
            {".def", "text/plain"},
            {".deploy", "application/octet-stream"},
            {".der", "application/x-x509-ca-cert"},
            {".dgml", "application/xml"},
            {".dib", "image/bmp"},
            {".dif", "video/x-dv"},
            {".dir", "application/x-director"},
            {".disco", "text/xml"},
            {".dll", "application/x-msdownload"},
            {".dll.config", "text/xml"},
            {".dlm", "text/dlm"},
            {".doc", "application/msword"},
            {".docm", "application/vnd.ms-word.document.macroEnabled.12"},
            {".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document"},
            {".dot", "application/msword"},
            {".dotm", "application/vnd.ms-word.template.macroEnabled.12"},
            {".dotx", "application/vnd.openxmlformats-officedocument.wordprocessingml.template"},
            {".dsp", "application/octet-stream"},
            {".dsw", "text/plain"},
            {".dtd", "text/xml"},
            {".dtsConfig", "text/xml"},
            {".dv", "video/x-dv"},
            {".dvi", "application/x-dvi"},
            {".dwf", "drawing/x-dwf"},
            {".dwp", "application/octet-stream"},
            {".dxr", "application/x-director"},
            {".eml", "message/rfc822"},
            {".emz", "application/octet-stream"},
            {".eot", "application/octet-stream"},
            {".eps", "application/postscript"},
            {".etl", "application/etl"},
            {".etx", "text/x-setext"},
            {".evy", "application/envoy"},
            {".exe", "application/octet-stream"},
            {".exe.config", "text/xml"},
            {".fdf", "application/vnd.fdf"},
            {".fif", "application/fractals"},
            {".filters", "Application/xml"},
            {".fla", "application/octet-stream"},
            {".flr", "x-world/x-vrml"},
            {".flv", "video/x-flv"},
            {".fsscript", "application/fsharp-script"},
            {".fsx", "application/fsharp-script"},
            {".generictest", "application/xml"},
            {".gif", "image/gif"},
            {".group", "text/x-ms-group"},
            {".gsm", "audio/x-gsm"},
            {".gtar", "application/x-gtar"},
            {".gz", "application/x-gzip"},
            {".h", "text/plain"},
            {".hdf", "application/x-hdf"},
            {".hdml", "text/x-hdml"},
            {".hhc", "application/x-oleobject"},
            {".hhk", "application/octet-stream"},
            {".hhp", "application/octet-stream"},
            {".hlp", "application/winhlp"},
            {".hpp", "text/plain"},
            {".hqx", "application/mac-binhex40"},
            {".hta", "application/hta"},
            {".htc", "text/x-component"},
            {".htm", "text/html"},
            {".html", "text/html"},
            {".htt", "text/webviewhtml"},
            {".hxa", "application/xml"},
            {".hxc", "application/xml"},
            {".hxd", "application/octet-stream"},
            {".hxe", "application/xml"},
            {".hxf", "application/xml"},
            {".hxh", "application/octet-stream"},
            {".hxi", "application/octet-stream"},
            {".hxk", "application/xml"},
            {".hxq", "application/octet-stream"},
            {".hxr", "application/octet-stream"},
            {".hxs", "application/octet-stream"},
            {".hxt", "text/html"},
            {".hxv", "application/xml"},
            {".hxw", "application/octet-stream"},
            {".hxx", "text/plain"},
            {".i", "text/plain"},
            {".ico", "image/x-icon"},
            {".ics", "application/octet-stream"},
            {".idl", "text/plain"},
            {".ief", "image/ief"},
            {".iii", "application/x-iphone"},
            {".inc", "text/plain"},
            {".inf", "application/octet-stream"},
            {".inl", "text/plain"},
            {".ins", "application/x-internet-signup"},
            {".ipa", "application/x-itunes-ipa"},
            {".ipg", "application/x-itunes-ipg"},
            {".ipproj", "text/plain"},
            {".ipsw", "application/x-itunes-ipsw"},
            {".iqy", "text/x-ms-iqy"},
            {".isp", "application/x-internet-signup"},
            {".ite", "application/x-itunes-ite"},
            {".itlp", "application/x-itunes-itlp"},
            {".itms", "application/x-itunes-itms"},
            {".itpc", "application/x-itunes-itpc"},
            {".IVF", "video/x-ivf"},
            {".jar", "application/java-archive"},
            {".java", "application/octet-stream"},
            {".jck", "application/liquidmotion"},
            {".jcz", "application/liquidmotion"},
            {".jfif", "image/pjpeg"},
            {".jnlp", "application/x-java-jnlp-file"},
            {".jpb", "application/octet-stream"},
            {".jpe", "image/jpeg"},
            {".jpeg", "image/jpeg"},
            {".jpg", "image/jpeg"},
            {".js", "application/x-javascript"},
            {".json", "application/json"},
            {".jsx", "text/jscript"},
            {".jsxbin", "text/plain"},
            {".latex", "application/x-latex"},
            {".library-ms", "application/windows-library+xml"},
            {".lit", "application/x-ms-reader"},
            {".loadtest", "application/xml"},
            {".lpk", "application/octet-stream"},
            {".lsf", "video/x-la-asf"},
            {".lst", "text/plain"},
            {".lsx", "video/x-la-asf"},
            {".lzh", "application/octet-stream"},
            {".m13", "application/x-msmediaview"},
            {".m14", "application/x-msmediaview"},
            {".m1v", "video/mpeg"},
            {".m2t", "video/vnd.dlna.mpeg-tts"},
            {".m2ts", "video/vnd.dlna.mpeg-tts"},
            {".m2v", "video/mpeg"},
            {".m3u", "audio/x-mpegurl"},
            {".m3u8", "audio/x-mpegurl"},
            {".m4a", "audio/m4a"},
            {".m4b", "audio/m4b"},
            {".m4p", "audio/m4p"},
            {".m4r", "audio/x-m4r"},
            {".m4v", "video/x-m4v"},
            {".mac", "image/x-macpaint"},
            {".mak", "text/plain"},
            {".man", "application/x-troff-man"},
            {".manifest", "application/x-ms-manifest"},
            {".map", "text/plain"},
            {".master", "application/xml"},
            {".mda", "application/msaccess"},
            {".mdb", "application/x-msaccess"},
            {".mde", "application/msaccess"},
            {".mdp", "application/octet-stream"},
            {".me", "application/x-troff-me"},
            {".mfp", "application/x-shockwave-flash"},
            {".mht", "message/rfc822"},
            {".mhtml", "message/rfc822"},
            {".mid", "audio/mid"},
            {".midi", "audio/mid"},
            {".mix", "application/octet-stream"},
            {".mk", "text/plain"},
            {".mmf", "application/x-smaf"},
            {".mno", "text/xml"},
            {".mny", "application/x-msmoney"},
            {".mod", "video/mpeg"},
            {".mov", "video/quicktime"},
            {".movie", "video/x-sgi-movie"},
            {".mp2", "video/mpeg"},
            {".mp2v", "video/mpeg"},
            {".mp3", "audio/mpeg"},
            {".mp4", "video/mp4"},
            {".mp4v", "video/mp4"},
            {".mpa", "video/mpeg"},
            {".mpe", "video/mpeg"},
            {".mpeg", "video/mpeg"},
            {".mpf", "application/vnd.ms-mediapackage"},
            {".mpg", "video/mpeg"},
            {".mpp", "application/vnd.ms-project"},
            {".mpv2", "video/mpeg"},
            {".mqv", "video/quicktime"},
            {".ms", "application/x-troff-ms"},
            {".msi", "application/octet-stream"},
            {".mso", "application/octet-stream"},
            {".mts", "video/vnd.dlna.mpeg-tts"},
            {".mtx", "application/xml"},
            {".mvb", "application/x-msmediaview"},
            {".mvc", "application/x-miva-compiled"},
            {".mxp", "application/x-mmxp"},
            {".nc", "application/x-netcdf"},
            {".nsc", "video/x-ms-asf"},
            {".nws", "message/rfc822"},
            {".ocx", "application/octet-stream"},
            {".oda", "application/oda"},
            {".odc", "text/x-ms-odc"},
            {".odh", "text/plain"},
            {".odl", "text/plain"},
            {".odp", "application/vnd.oasis.opendocument.presentation"},
            {".ods", "application/oleobject"},
            {".odt", "application/vnd.oasis.opendocument.text"},
            {".one", "application/onenote"},
            {".onea", "application/onenote"},
            {".onepkg", "application/onenote"},
            {".onetmp", "application/onenote"},
            {".onetoc", "application/onenote"},
            {".onetoc2", "application/onenote"},
            {".orderedtest", "application/xml"},
            {".osdx", "application/opensearchdescription+xml"},
            {".p10", "application/pkcs10"},
            {".p12", "application/x-pkcs12"},
            {".p7b", "application/x-pkcs7-certificates"},
            {".p7c", "application/pkcs7-mime"},
            {".p7m", "application/pkcs7-mime"},
            {".p7r", "application/x-pkcs7-certreqresp"},
            {".p7s", "application/pkcs7-signature"},
            {".pbm", "image/x-portable-bitmap"},
            {".pcast", "application/x-podcast"},
            {".pct", "image/pict"},
            {".pcx", "application/octet-stream"},
            {".pcz", "application/octet-stream"},
            {".pdf", "application/pdf"},
            {".pfb", "application/octet-stream"},
            {".pfm", "application/octet-stream"},
            {".pfx", "application/x-pkcs12"},
            {".pgm", "image/x-portable-graymap"},
            {".pic", "image/pict"},
            {".pict", "image/pict"},
            {".pkgdef", "text/plain"},
            {".pkgundef", "text/plain"},
            {".pko", "application/vnd.ms-pki.pko"},
            {".pls", "audio/scpls"},
            {".pma", "application/x-perfmon"},
            {".pmc", "application/x-perfmon"},
            {".pml", "application/x-perfmon"},
            {".pmr", "application/x-perfmon"},
            {".pmw", "application/x-perfmon"},
            {".png", "image/png"},
            {".pnm", "image/x-portable-anymap"},
            {".pnt", "image/x-macpaint"},
            {".pntg", "image/x-macpaint"},
            {".pnz", "image/png"},
            {".pot", "application/vnd.ms-powerpoint"},
            {".potm", "application/vnd.ms-powerpoint.template.macroEnabled.12"},
            {".potx", "application/vnd.openxmlformats-officedocument.presentationml.template"},
            {".ppa", "application/vnd.ms-powerpoint"},
            {".ppam", "application/vnd.ms-powerpoint.addin.macroEnabled.12"},
            {".ppm", "image/x-portable-pixmap"},
            {".pps", "application/vnd.ms-powerpoint"},
            {".ppsm", "application/vnd.ms-powerpoint.slideshow.macroEnabled.12"},
            {".ppsx", "application/vnd.openxmlformats-officedocument.presentationml.slideshow"},
            {".ppt", "application/vnd.ms-powerpoint"},
            {".pptm", "application/vnd.ms-powerpoint.presentation.macroEnabled.12"},
            {".pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation"},
            {".prf", "application/pics-rules"},
            {".prm", "application/octet-stream"},
            {".prx", "application/octet-stream"},
            {".ps", "application/postscript"},
            {".psc1", "application/PowerShell"},
            {".psd", "application/octet-stream"},
            {".psess", "application/xml"},
            {".psm", "application/octet-stream"},
            {".psp", "application/octet-stream"},
            {".pub", "application/x-mspublisher"},
            {".pwz", "application/vnd.ms-powerpoint"},
            {".qht", "text/x-html-insertion"},
            {".qhtm", "text/x-html-insertion"},
            {".qt", "video/quicktime"},
            {".qti", "image/x-quicktime"},
            {".qtif", "image/x-quicktime"},
            {".qtl", "application/x-quicktimeplayer"},
            {".qxd", "application/octet-stream"},
            {".ra", "audio/x-pn-realaudio"},
            {".ram", "audio/x-pn-realaudio"},
            {".rar", "application/octet-stream"},
            {".ras", "image/x-cmu-raster"},
            {".rat", "application/rat-file"},
            {".rc", "text/plain"},
            {".rc2", "text/plain"},
            {".rct", "text/plain"},
            {".rdlc", "application/xml"},
            {".resx", "application/xml"},
            {".rf", "image/vnd.rn-realflash"},
            {".rgb", "image/x-rgb"},
            {".rgs", "text/plain"},
            {".rm", "application/vnd.rn-realmedia"},
            {".rmi", "audio/mid"},
            {".rmp", "application/vnd.rn-rn_music_package"},
            {".roff", "application/x-troff"},
            {".rpm", "audio/x-pn-realaudio-plugin"},
            {".rqy", "text/x-ms-rqy"},
            {".rtf", "application/rtf"},
            {".rtx", "text/richtext"},
            {".ruleset", "application/xml"},
            {".s", "text/plain"},
            {".safariextz", "application/x-safari-safariextz"},
            {".scd", "application/x-msschedule"},
            {".sct", "text/scriptlet"},
            {".sd2", "audio/x-sd2"},
            {".sdp", "application/sdp"},
            {".sea", "application/octet-stream"},
            {".searchConnector-ms", "application/windows-search-connector+xml"},
            {".setpay", "application/set-payment-initiation"},
            {".setreg", "application/set-registration-initiation"},
            {".settings", "application/xml"},
            {".sgimb", "application/x-sgimb"},
            {".sgml", "text/sgml"},
            {".sh", "application/x-sh"},
            {".shar", "application/x-shar"},
            {".shtml", "text/html"},
            {".sit", "application/x-stuffit"},
            {".sitemap", "application/xml"},
            {".skin", "application/xml"},
            {".sldm", "application/vnd.ms-powerpoint.slide.macroEnabled.12"},
            {".sldx", "application/vnd.openxmlformats-officedocument.presentationml.slide"},
            {".slk", "application/vnd.ms-excel"},
            {".sln", "text/plain"},
            {".slupkg-ms", "application/x-ms-license"},
            {".smd", "audio/x-smd"},
            {".smi", "application/octet-stream"},
            {".smx", "audio/x-smd"},
            {".smz", "audio/x-smd"},
            {".snd", "audio/basic"},
            {".snippet", "application/xml"},
            {".snp", "application/octet-stream"},
            {".sol", "text/plain"},
            {".sor", "text/plain"},
            {".spc", "application/x-pkcs7-certificates"},
            {".spl", "application/futuresplash"},
            {".src", "application/x-wais-source"},
            {".srf", "text/plain"},
            {".SSISDeploymentManifest", "text/xml"},
            {".ssm", "application/streamingmedia"},
            {".sst", "application/vnd.ms-pki.certstore"},
            {".stl", "application/vnd.ms-pki.stl"},
            {".sv4cpio", "application/x-sv4cpio"},
            {".sv4crc", "application/x-sv4crc"},
            {".svc", "application/xml"},
            {".swf", "application/x-shockwave-flash"},
            {".t", "application/x-troff"},
            {".tar", "application/x-tar"},
            {".tcl", "application/x-tcl"},
            {".testrunconfig", "application/xml"},
            {".testsettings", "application/xml"},
            {".tex", "application/x-tex"},
            {".texi", "application/x-texinfo"},
            {".texinfo", "application/x-texinfo"},
            {".tgz", "application/x-compressed"},
            {".thmx", "application/vnd.ms-officetheme"},
            {".thn", "application/octet-stream"},
            {".tif", "image/tiff"},
            {".tiff", "image/tiff"},
            {".tlh", "text/plain"},
            {".tli", "text/plain"},
            {".toc", "application/octet-stream"},
            {".tr", "application/x-troff"},
            {".trm", "application/x-msterminal"},
            {".trx", "application/xml"},
            {".ts", "video/vnd.dlna.mpeg-tts"},
            {".tsv", "text/tab-separated-values"},
            {".ttf", "application/octet-stream"},
            {".tts", "video/vnd.dlna.mpeg-tts"},
            {".txt", "text/plain"},
            {".u32", "application/octet-stream"},
            {".uls", "text/iuls"},
            {".user", "text/plain"},
            {".ustar", "application/x-ustar"},
            {".vb", "text/plain"},
            {".vbdproj", "text/plain"},
            {".vbk", "video/mpeg"},
            {".vbproj", "text/plain"},
            {".vbs", "text/vbscript"},
            {".vcf", "text/x-vcard"},
            {".vcproj", "Application/xml"},
            {".vcs", "text/plain"},
            {".vcxproj", "Application/xml"},
            {".vddproj", "text/plain"},
            {".vdp", "text/plain"},
            {".vdproj", "text/plain"},
            {".vdx", "application/vnd.ms-visio.viewer"},
            {".vml", "text/xml"},
            {".vscontent", "application/xml"},
            {".vsct", "text/xml"},
            {".vsd", "application/vnd.visio"},
            {".vsi", "application/ms-vsi"},
            {".vsix", "application/vsix"},
            {".vsixlangpack", "text/xml"},
            {".vsixmanifest", "text/xml"},
            {".vsmdi", "application/xml"},
            {".vspscc", "text/plain"},
            {".vss", "application/vnd.visio"},
            {".vsscc", "text/plain"},
            {".vssettings", "text/xml"},
            {".vssscc", "text/plain"},
            {".vst", "application/vnd.visio"},
            {".vstemplate", "text/xml"},
            {".vsto", "application/x-ms-vsto"},
            {".vsw", "application/vnd.visio"},
            {".vsx", "application/vnd.visio"},
            {".vtx", "application/vnd.visio"},
            {".wav", "audio/wav"},
            {".wave", "audio/wav"},
            {".wax", "audio/x-ms-wax"},
            {".wbk", "application/msword"},
            {".wbmp", "image/vnd.wap.wbmp"},
            {".wcm", "application/vnd.ms-works"},
            {".wdb", "application/vnd.ms-works"},
            {".wdp", "image/vnd.ms-photo"},
            {".webarchive", "application/x-safari-webarchive"},
            {".webtest", "application/xml"},
            {".wiq", "application/xml"},
            {".wiz", "application/msword"},
            {".wks", "application/vnd.ms-works"},
            {".WLMP", "application/wlmoviemaker"},
            {".wlpginstall", "application/x-wlpg-detect"},
            {".wlpginstall3", "application/x-wlpg3-detect"},
            {".wm", "video/x-ms-wm"},
            {".wma", "audio/x-ms-wma"},
            {".wmd", "application/x-ms-wmd"},
            {".wmf", "application/x-msmetafile"},
            {".wml", "text/vnd.wap.wml"},
            {".wmlc", "application/vnd.wap.wmlc"},
            {".wmls", "text/vnd.wap.wmlscript"},
            {".wmlsc", "application/vnd.wap.wmlscriptc"},
            {".wmp", "video/x-ms-wmp"},
            {".wmv", "video/x-ms-wmv"},
            {".wmx", "video/x-ms-wmx"},
            {".wmz", "application/x-ms-wmz"},
            {".wpl", "application/vnd.ms-wpl"},
            {".wps", "application/vnd.ms-works"},
            {".wri", "application/x-mswrite"},
            {".wrl", "x-world/x-vrml"},
            {".wrz", "x-world/x-vrml"},
            {".wsc", "text/scriptlet"},
            {".wsdl", "text/xml"},
            {".wvx", "video/x-ms-wvx"},
            {".x", "application/directx"},
            {".xaf", "x-world/x-vrml"},
            {".xaml", "application/xaml+xml"},
            {".xap", "application/x-silverlight-app"},
            {".xbap", "application/x-ms-xbap"},
            {".xbm", "image/x-xbitmap"},
            {".xdr", "text/plain"},
            {".xht", "application/xhtml+xml"},
            {".xhtml", "application/xhtml+xml"},
            {".xla", "application/vnd.ms-excel"},
            {".xlam", "application/vnd.ms-excel.addin.macroEnabled.12"},
            {".xlc", "application/vnd.ms-excel"},
            {".xld", "application/vnd.ms-excel"},
            {".xlk", "application/vnd.ms-excel"},
            {".xll", "application/vnd.ms-excel"},
            {".xlm", "application/vnd.ms-excel"},
            {".xls", "application/vnd.ms-excel"},
            {".xlsb", "application/vnd.ms-excel.sheet.binary.macroEnabled.12"},
            {".xlsm", "application/vnd.ms-excel.sheet.macroEnabled.12"},
            {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
            {".xlt", "application/vnd.ms-excel"},
            {".xltm", "application/vnd.ms-excel.template.macroEnabled.12"},
            {".xltx", "application/vnd.openxmlformats-officedocument.spreadsheetml.template"},
            {".xlw", "application/vnd.ms-excel"},
            {".xml", "text/xml"},
            {".xmta", "application/xml"},
            {".xof", "x-world/x-vrml"},
            {".XOML", "text/plain"},
            {".xpm", "image/x-xpixmap"},
            {".xps", "application/vnd.ms-xpsdocument"},
            {".xrm-ms", "text/xml"},
            {".xsc", "application/xml"},
            {".xsd", "text/xml"},
            {".xsf", "text/xml"},
            {".xsl", "text/xml"},
            {".xslt", "text/xml"},
            {".xsn", "application/octet-stream"},
            {".xss", "application/xml"},
            {".xtp", "application/octet-stream"},
            {".xwd", "image/x-xwindowdump"},
            {".z", "application/x-compress"},
            {".zip", "application/x-zip-compressed"},
        };

        //file headers are taken from here:    http://www.garykessler.net/library/file_sigs.html
        //mime types are taken from here:      http://www.webmaster-toolkit.com/mime-types.shtml

        // MS Office files
        public readonly static OFileType DOC = new (new byte?[] { 0xEC, 0xA5, 0xC1, 0x00 }, 512, "doc", "application/msword");
        public readonly static OFileType XLS = new (new byte?[] { 0x09, 0x08, 0x10, 0x00, 0x00, 0x06, 0x05, 0x00 }, 512, "xls", "applapplicationication/excel");
        public readonly static OFileType PPT = new (new byte?[] { 0xFD, 0xFF, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00 }, 512, "ppt", "application/mspowerpoint");
        public readonly static OFileType PUB = new (new byte?[] { 0xFD, 0xFF, 0xFF, 0xFF, 0x02 }, 512, "pub", "application/octet-stream");
        public readonly static OFileType RTF = new (new byte?[] { 0x7B, 0x5C, 0x72, 0x74, 0x66, 0x31 }, "rtf", "application/rtf");
        public readonly static OFileType PDF = new (new byte?[] { 0x25, 0x50, 0x44, 0x46 }, "pdf", "application/pdf");
        public readonly static OFileType JPG = new (new byte?[] { 0xFF, 0xD8, 0xFF }, "jpg", "image/jpeg");
        public readonly static OFileType PNG = new (new byte?[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }, "png", "image/png");
        public readonly static OFileType GIF = new (new byte?[] { 0x47, 0x49, 0x46, 0x38, null, 0x61 }, "gif", "image/gif");
        public readonly static OFileType ZIP = new (new byte?[] { 0x50, 0x4B, 0x03, 0x04 }, "zip", "application/x-compressed");
        public readonly static OFileType RAR = new (new byte?[] { 0x52, 0x61, 0x72, 0x21 }, "rar", "application/x-compressed");
        public readonly static OFileType EXE = new (new byte?[] { 0x4D, 0x5A }, "exe", "application/octet-stream");
        public readonly static OFileType MOV1 = new (new byte?[] { 0x66, 0x74, 0x79, 0x70, 0x71, 0x74, 0x20, 0x20, }, 4, "mov", "application/octet-stream");
        public readonly static OFileType MOV2 = new (new byte?[] { 0x6D, 0x6F, 0x6F, 0x76 }, 4, "mov", "application/octet-stream");
        public readonly static OFileType M4V = new (new byte?[] { 0x6D, 0x70, 0x34, 0x32 }, "m4v", "application/octet-stream");
        public readonly static OFileType MP41 = new (new byte?[] { 0x4D, 0x53, 0x4E, 0x56 }, "mp4", "application/octet-stream");
        public readonly static OFileType MP42 = new (new byte?[] { 0x33, 0x67, 0x70, 0x35 }, "mp4", "application/octet-stream");
        public readonly static OFileType MP43 = new (new byte?[] { 0x69, 0x73, 0x6F, 0x6D }, "mp4", "application/octet-stream");
        public readonly static OFileType M4A = new (new byte?[] { 0x4D, 0x34, 0x41, 0x20 }, "m4a", "application/octet-stream");
        public readonly static OFileType FLAC = new (new byte?[] { 0x66, 0x4C, 0x61, 0x43, 0x00, 0x00, 0x00, 0x22 }, "flac", "application/octet-stream");
        public readonly static OFileType AVI = new (new byte?[] { 0x41, 0x56, 0x49, 0x20, 0x4C, 0x49, 0x53, 0x54 }, "avi", "application/octet-stream");
        public readonly static OFileType TIF1 = new (new byte?[] { 0x4D, 0x4D, 0x00, 0x2A }, "tif", "application/octet-stream");
        public readonly static OFileType TIF2 = new (new byte?[] { 0x4D, 0x4D, 0x00, 0x2B }, "tif", "application/octet-stream");
        public readonly static OFileType TIF3 = new (new byte?[] { 0x49, 0x20, 0x49 }, "tif", "application/octet-stream");
        public readonly static OFileType MKV1 = new (new byte?[] { 0x1A, 0x45, 0xDF, 0xA3, 0x93, 0x42, 0x82, 0x88 }, "mkv", "application/octet-stream");
        public readonly static OFileType MKV2 = new (new byte?[] { 0x6D, 0x61, 0x74, 0x72, 0x6F, 0x73, 0x6B, 0x61 }, "mkv", "application/octet-stream");
        public readonly static OFileType MP3 = new (new byte?[] { 0x49, 0x44, 0x33 }, "mp3", "application/octet-stream");
        public readonly static OFileType GGP1 = new (new byte?[] { 0x00, 0x00, 0x00, null, 0x66, 0x74, 0x79, 0x70 }, "3gp", "application/octet-stream");
        public readonly static OFileType GGP2 = new (new byte?[] { 0x33, 0x67, 0x70 }, "3gp", "application/octet-stream");
        public readonly static OFileType MDF = new (new byte?[] { 0x01, 0x0F, 0x00, 0x00 }, "mdf", "application/octet-stream");
        public readonly static OFileType EML = new (new byte?[] { 0x46, 0x72, 0x6F, 0x6D }, "eml", "application/octet-stream");
        public readonly static OFileType MSDOC = new (new byte?[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 }, "", "application/octet-stream");

        private readonly static List<OFileType> types = new () {
             PDF
            ,DOC
            ,XLS
            ,PUB
            ,JPG
            ,ZIP
            ,RAR
            ,RTF
            ,PNG
            ,PPT
            ,GIF
            ,EXE
            ,MOV1
            ,MOV2
            ,M4V
            ,MP41
            ,MP42
            ,MP43
            ,M4A
            ,FLAC
            ,AVI
            ,TIF1
            ,TIF2
            ,TIF3
            ,MKV1
            ,MKV2
            ,MP3
            ,GGP1
            ,GGP2
            ,MDF
            ,EML
            ,MSDOC
        };

        private const int MaxHeaderSize = 560;  // number of bytes we read from a file, some file formats have headers offset to 512 bytes

        #endregion

        #region Methods

        public static OFileType GetOFileType(this byte[] filedata)
        {

            byte[] fileHeader = ReadFileHeader(filedata, MaxHeaderSize);

            foreach (OFileType type in types)
            {
                int matchingCount = 0;

                for (int i = 0; i < type.Header.Length; i++)
                {
                    if (type.Header[i] != null && type.Header[i] != fileHeader[i + type.HeaderOffset])
                    {
                        matchingCount = 0;
                        break;
                    }
                    else
                    {
                        matchingCount++;
                    }
                }

                if (matchingCount == type.Header.Length)
                {
                    return type;
                }

            }

            return null;

        }

        private static byte[] ReadFileHeader(byte[] filedata, int MaxHeaderSize)
        {
            byte[] header = new byte[MaxHeaderSize];

            try
            {

                Array.Copy(filedata, header, header.Length);

            }
            catch (Exception e)
            {
                throw new ApplicationException("Could not read file : " + e.Message);
            }

            return header;
        }

        public static OFileType GetOFileType(this FileInfo file)
        {

            Byte[] fileHeader = ReadFileHeader(file, MaxHeaderSize);
            foreach (OFileType type in types)
            {

                int matchingCount = 0;

                for (int i = 0; i < type.Header.Length; i++)
                {
                    if (type.Header[i] != null && type.Header[i] != fileHeader[i + type.HeaderOffset])
                    {
                        matchingCount = 0;
                        break;
                    }
                    else
                    {
                        matchingCount++;
                    }
                }

                if (matchingCount == type.Header.Length)
                {
                    return type;
                }

            }
            return null;

        }

        private static byte[] ReadFileHeader(this FileInfo file, int MaxHeaderSize)
        {
            byte[] header = new byte[MaxHeaderSize];
            try
            {
                using FileStream fsSource = new(file.FullName, FileMode.Open, FileAccess.Read);
                fsSource.Read(header, 0, MaxHeaderSize);

            }
            catch (Exception e) // file could not be found/read
            {
                throw new ApplicationException("Could not read file : " + e.Message);
            }

            return header;
        }

        public static bool IsFileOfTypes(this FileInfo file, List<OFileType> requiredTypes)
        {
            OFileType currentType = file.GetOFileType();

            if (null == currentType)
                return false;

            return requiredTypes.Contains(currentType);
        }

        public static bool IsFileOfTypes(this FileInfo file, string CSV)
        {

            List<OFileType> providedTypes = GetOFileTypesByExtensions(CSV);

            return file.IsFileOfTypes(providedTypes);

        }

        private static List<OFileType> GetOFileTypesByExtensions(string CSV)
        {

            string[] extensions = CSV.ToUpper().Replace(" ", "").Split(',');

            List<OFileType> result = new();

            foreach (OFileType type in types)
            {
                if (extensions.Contains(type.Extension.ToUpper()))
                    result.Add(type);
            }

            return result;

        }
      
        public static string GetFileContentType(string fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException(fileName);

            RegistryKey registryKey = null;

            try
            {
                FileInfo fileInfo = new(fileName);

                if (string.IsNullOrEmpty(fileInfo.Extension))
                    return string.Empty;

                string extension = fileInfo.Extension.ToLowerInvariant();

                registryKey = Registry.ClassesRoot.OpenSubKey(extension);
                if (registryKey == null)
                    return string.Empty;

                var contentTypeObject = registryKey.GetValue("Content Type");
                if (!(contentTypeObject is string))
                    return string.Empty;

                string contentType = (string)contentTypeObject;

                return contentType;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (registryKey != null)
                    registryKey.Close();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
        public static string GetFileContentType(this FileInfo fileInfo)
        {
            if (fileInfo == null)
                throw new ArgumentNullException(fileInfo.FullName);

            RegistryKey registryKey = null;

            try
            {

                if (string.IsNullOrEmpty(fileInfo.Extension))
                    return string.Empty;

                string extension = fileInfo.Extension.ToLowerInvariant();

                registryKey = Registry.ClassesRoot.OpenSubKey(extension);
                if (registryKey == null)
                    return string.Empty;

                var contentTypeObject = registryKey.GetValue("Content Type");
                if (!(contentTypeObject is string))
                    return string.Empty;

                string contentType = (string)contentTypeObject;

                return contentType;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (registryKey != null)
                    registryKey.Close();
            }
        }

        public static string GetFileDescription(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException(fileName);
            }

            RegistryKey registryKey1 = null;
            RegistryKey registryKey2 = null;
            try
            {
                FileInfo fileInfo = new(fileName);

                if (string.IsNullOrEmpty(fileInfo.Extension))
                {
                    return string.Empty;
                }

                string extension = fileInfo.Extension.ToLowerInvariant();

                registryKey1 = Registry.ClassesRoot.OpenSubKey(extension);
                if (registryKey1 == null)
                {
                    return string.Empty;
                }

                object extensionDefaultObject = registryKey1.GetValue(null);
                if (!(extensionDefaultObject is string))
                {
                    return string.Empty;
                }

                string extensionDefaultValue = (string)extensionDefaultObject;

                registryKey2 = Registry.ClassesRoot.OpenSubKey(extensionDefaultValue);
                if (registryKey2 == null)
                {
                    return string.Empty;
                }

                object fileDescriptionObject = registryKey2.GetValue(null);
                if (!(fileDescriptionObject is string))
                {
                    return string.Empty;
                }

                string fileDescription = (string)fileDescriptionObject;
                return fileDescription;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (registryKey2 != null)
                {
                    registryKey2.Close();
                }

                if (registryKey1 != null)
                {
                    registryKey1.Close();
                }
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
        public static void GetFileIcons(string fileName, out Icon smallIcon, out Icon largeIcon)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException(fileName);
            }

            smallIcon = null;
            largeIcon = null;

            RegistryKey registryKey1 = null;
            RegistryKey registryKey2 = null;
            try
            {
                FileInfo fileInfo = new(fileName);

                if (string.IsNullOrEmpty(fileInfo.Extension))
                {
                    return;
                }

                string extension = fileInfo.Extension.ToLowerInvariant();

                registryKey1 = Registry.ClassesRoot.OpenSubKey(extension);
                if (registryKey1 == null)
                {
                    return;
                }

                object extensionDefaultObject = registryKey1.GetValue(null);
                if (!(extensionDefaultObject is string))
                {
                    return;
                }

                string defaultIconKeyName = string.Format("{0}\\DefaultIcon", extensionDefaultObject);

                registryKey2 = Registry.ClassesRoot.OpenSubKey(defaultIconKeyName);
                if (registryKey2 == null)
                {
                    return;
                }

                object defaultIconPathObject = registryKey2.GetValue(null);
                if (!(defaultIconPathObject is string))
                {
                    return;
                }

                string defaultIconPath = (string)defaultIconPathObject;
                if (string.IsNullOrWhiteSpace(defaultIconPath))
                {
                    return;
                }

                string iconfileName = null;
                int iconIndex = 0;

                int commaIndex = defaultIconPath.IndexOf(",");
                if (commaIndex > 0)
                {
                    iconfileName = defaultIconPath.Substring(0, commaIndex);
                    string iconIndexString = defaultIconPath[(commaIndex + 1)..];

                    if (!int.TryParse(iconIndexString, out iconIndex))
                    {
                        iconIndex = 0;
                    }
                }
                else
                {
                    iconfileName = defaultIconPath;
                    iconIndex = 0;
                }

                IntPtr[] phiconSmall = new IntPtr[1] { IntPtr.Zero };
                IntPtr[] phiconLarge = new IntPtr[1] { IntPtr.Zero };

                int readIconCount = ExtractIconEx(iconfileName, iconIndex, phiconLarge, phiconSmall, 1);

                if (readIconCount < 0)
                {
                    return;
                }

                if (phiconSmall[0] != IntPtr.Zero)
                {
                    smallIcon = (Icon)Icon.FromHandle(phiconSmall[0]).Clone();
                    _ = DestroyIcon(phiconSmall[0]);
                }

                if (phiconLarge[0] != IntPtr.Zero)
                {
                    largeIcon = (Icon)Icon.FromHandle(phiconLarge[0]).Clone();
                    _ = DestroyIcon(phiconLarge[0]);
                }

                return;
            }
            finally
            {
                if (registryKey2 != null)
                {
                    registryKey2.Close();
                }

                if (registryKey1 != null)
                {
                    registryKey1.Close();
                }
            }
        }

        #endregion

        #region Functions

        public static bool IsType(this FileInfo file, OFileType type)
        {
            OFileType actualType = GetOFileType(file);

            if (null == actualType)
                return false;

            return (actualType.Equals(type));
        }

        public static bool IsPdf(this FileInfo file)
        {
            return file.IsType(PDF);
        }

        public static bool IsWord(this FileInfo fileInfo)
        {
            return fileInfo.IsType(DOC);
        }

        public static bool IsZip(this FileInfo fileInfo)
        {
            return fileInfo.IsType(ZIP);
        }

        public static bool IsExcel(this FileInfo fileInfo)
        {
            return fileInfo.IsType(XLS);
        }

        public static bool IsJpeg(this FileInfo fileInfo)
        {
            return fileInfo.IsType(JPG);
        }

        public static bool IsRar(this FileInfo fileInfo)
        {
            return fileInfo.IsType(RAR);
        }

        public static bool IsRtf(this FileInfo fileInfo)
        {
            return fileInfo.IsType(RTF);
        }

        public static bool IsPng(this FileInfo fileInfo)
        {
            return fileInfo.IsType(PNG);
        }

        public static bool IsPpt(this FileInfo fileInfo)
        {
            return fileInfo.IsType(PPT);
        }

        public static bool IsGif(this FileInfo fileInfo)
        {
            return fileInfo.IsType(GIF);
        }

        public static bool IsExe(this FileInfo fileInfo)
        {
            return fileInfo.IsType(EXE);
        }

        public static bool IsMsi(this FileInfo fileInfo)
        {
            return fileInfo.IsType(PPT) || fileInfo.IsType(MSDOC);
        }

        #endregion

    }


}
