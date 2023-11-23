; ModuleID = 'obj\Debug\130\android\marshal_methods.x86.ll'
source_filename = "obj\Debug\130\android\marshal_methods.x86.ll"
target datalayout = "e-m:e-p:32:32-p270:32:32-p271:32:32-p272:64:64-f64:32:64-f80:32-n8:16:32-S128"
target triple = "i686-unknown-linux-android"


%struct.MonoImage = type opaque

%struct.MonoClass = type opaque

%struct.MarshalMethodsManagedClass = type {
	i32,; uint32_t token
	%struct.MonoClass*; MonoClass* klass
}

%struct.MarshalMethodName = type {
	i64,; uint64_t id
	i8*; char* name
}

%class._JNIEnv = type opaque

%class._jobject = type {
	i8; uint8_t b
}

%class._jclass = type {
	i8; uint8_t b
}

%class._jstring = type {
	i8; uint8_t b
}

%class._jthrowable = type {
	i8; uint8_t b
}

%class._jarray = type {
	i8; uint8_t b
}

%class._jobjectArray = type {
	i8; uint8_t b
}

%class._jbooleanArray = type {
	i8; uint8_t b
}

%class._jbyteArray = type {
	i8; uint8_t b
}

%class._jcharArray = type {
	i8; uint8_t b
}

%class._jshortArray = type {
	i8; uint8_t b
}

%class._jintArray = type {
	i8; uint8_t b
}

%class._jlongArray = type {
	i8; uint8_t b
}

%class._jfloatArray = type {
	i8; uint8_t b
}

%class._jdoubleArray = type {
	i8; uint8_t b
}

; assembly_image_cache
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 4
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [238 x i32] [
	i32 32687329, ; 0: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 62
	i32 34715100, ; 1: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 97
	i32 39109920, ; 2: Newtonsoft.Json.dll => 0x254c520 => 12
	i32 57263871, ; 3: Xamarin.Forms.Core.dll => 0x369c6ff => 89
	i32 101534019, ; 4: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 78
	i32 120558881, ; 5: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 78
	i32 134690465, ; 6: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x80736a1 => 105
	i32 165246403, ; 7: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 39
	i32 182336117, ; 8: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 80
	i32 209399409, ; 9: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 37
	i32 230216969, ; 10: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 56
	i32 232815796, ; 11: System.Web.Services => 0xde07cb4 => 116
	i32 261689757, ; 12: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 42
	i32 278686392, ; 13: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 60
	i32 280482487, ; 14: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 54
	i32 318968648, ; 15: Xamarin.AndroidX.Activity.dll => 0x13031348 => 29
	i32 321597661, ; 16: System.Numerics => 0x132b30dd => 23
	i32 342366114, ; 17: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 58
	i32 385762202, ; 18: System.Memory.dll => 0x16fe439a => 21
	i32 441335492, ; 19: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 41
	i32 442521989, ; 20: Xamarin.Essentials => 0x1a605985 => 88
	i32 450948140, ; 21: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 53
	i32 465846621, ; 22: mscorlib => 0x1bc4415d => 10
	i32 469710990, ; 23: System.dll => 0x1bff388e => 20
	i32 476646585, ; 24: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 54
	i32 486930444, ; 25: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 66
	i32 525008092, ; 26: SkiaSharp.dll => 0x1f4afcdc => 14
	i32 526420162, ; 27: System.Transactions.dll => 0x1f6088c2 => 110
	i32 527452488, ; 28: Xamarin.Kotlin.StdLib.Jdk7 => 0x1f704948 => 105
	i32 605376203, ; 29: System.IO.Compression.FileSystem => 0x24154ecb => 114
	i32 627609679, ; 30: Xamarin.AndroidX.CustomView => 0x2568904f => 47
	i32 639843206, ; 31: Xamarin.AndroidX.Emoji2.ViewsHelper.dll => 0x26233b86 => 52
	i32 663517072, ; 32: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 85
	i32 666292255, ; 33: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 34
	i32 690569205, ; 34: System.Xml.Linq.dll => 0x29293ff5 => 28
	i32 691348768, ; 35: Xamarin.KotlinX.Coroutines.Android.dll => 0x29352520 => 107
	i32 700284507, ; 36: Xamarin.Jetbrains.Annotations => 0x29bd7e5b => 102
	i32 720511267, ; 37: Xamarin.Kotlin.StdLib.Jdk8 => 0x2af22123 => 106
	i32 775507847, ; 38: System.IO.Compression => 0x2e394f87 => 113
	i32 803245650, ; 39: PetLifeApp.Android => 0x2fe08e52 => 0
	i32 809851609, ; 40: System.Drawing.Common.dll => 0x30455ad9 => 112
	i32 843511501, ; 41: Xamarin.AndroidX.Print => 0x3246f6cd => 73
	i32 886248193, ; 42: Microcharts.Droid => 0x34d31301 => 6
	i32 928116545, ; 43: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 97
	i32 955402788, ; 44: Newtonsoft.Json => 0x38f24a24 => 12
	i32 956575887, ; 45: Xamarin.Kotlin.StdLib.Jdk8.dll => 0x3904308f => 106
	i32 967690846, ; 46: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 58
	i32 974778368, ; 47: FormsViewGroup.dll => 0x3a19f000 => 3
	i32 1012816738, ; 48: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 77
	i32 1035644815, ; 49: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 33
	i32 1042160112, ; 50: Xamarin.Forms.Platform.dll => 0x3e1e19f0 => 94
	i32 1052210849, ; 51: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 63
	i32 1084122840, ; 52: Xamarin.Kotlin.StdLib => 0x409e66d8 => 104
	i32 1098259244, ; 53: System => 0x41761b2c => 20
	i32 1127312645, ; 54: PetLifeApp.dll => 0x43316d05 => 13
	i32 1175144683, ; 55: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 83
	i32 1178241025, ; 56: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 70
	i32 1204270330, ; 57: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 34
	i32 1264511973, ; 58: Xamarin.AndroidX.Startup.StartupRuntime.dll => 0x4b5eebe5 => 79
	i32 1267360935, ; 59: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 84
	i32 1275534314, ; 60: Xamarin.KotlinX.Coroutines.Android => 0x4c071bea => 107
	i32 1293217323, ; 61: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 49
	i32 1354490624, ; 62: Xamarin.Forms.GoogleMaps.dll => 0x50bbe300 => 91
	i32 1365406463, ; 63: System.ServiceModel.Internals.dll => 0x516272ff => 117
	i32 1371845985, ; 64: Xamarin.Forms.GoogleMaps.Android => 0x51c4b561 => 90
	i32 1376866003, ; 65: Xamarin.AndroidX.SavedState => 0x52114ed3 => 77
	i32 1395857551, ; 66: Xamarin.AndroidX.Media.dll => 0x5333188f => 67
	i32 1406073936, ; 67: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 43
	i32 1411638395, ; 68: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 25
	i32 1460219004, ; 69: Xamarin.Forms.Xaml => 0x57092c7c => 95
	i32 1462112819, ; 70: System.IO.Compression.dll => 0x57261233 => 113
	i32 1469204771, ; 71: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 32
	i32 1511525525, ; 72: MySqlConnector => 0x5a180c95 => 11
	i32 1582372066, ; 73: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 48
	i32 1582526884, ; 74: Microcharts.Forms.dll => 0x5e5371a4 => 7
	i32 1592978981, ; 75: System.Runtime.Serialization.dll => 0x5ef2ee25 => 2
	i32 1622152042, ; 76: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 65
	i32 1624863272, ; 77: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 87
	i32 1635184631, ; 78: Xamarin.AndroidX.Emoji2.ViewsHelper => 0x6176eff7 => 52
	i32 1636350590, ; 79: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 46
	i32 1639515021, ; 80: System.Net.Http.dll => 0x61b9038d => 22
	i32 1657153582, ; 81: System.Runtime => 0x62c6282e => 26
	i32 1658241508, ; 82: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 81
	i32 1658251792, ; 83: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 96
	i32 1670060433, ; 84: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 42
	i32 1698840827, ; 85: Xamarin.Kotlin.StdLib.Common => 0x654240fb => 103
	i32 1722051300, ; 86: SkiaSharp.Views.Forms => 0x66a46ae4 => 16
	i32 1729485958, ; 87: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 38
	i32 1766324549, ; 88: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 80
	i32 1776026572, ; 89: System.Core.dll => 0x69dc03cc => 18
	i32 1788241197, ; 90: Xamarin.AndroidX.Fragment => 0x6a96652d => 53
	i32 1808609942, ; 91: Xamarin.AndroidX.Loader => 0x6bcd3296 => 65
	i32 1813058853, ; 92: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 104
	i32 1813201214, ; 93: Xamarin.Google.Android.Material => 0x6c13413e => 96
	i32 1818569960, ; 94: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 71
	i32 1828688058, ; 95: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 8
	i32 1867746548, ; 96: Xamarin.Essentials.dll => 0x6f538cf4 => 88
	i32 1878053835, ; 97: Xamarin.Forms.Xaml.dll => 0x6ff0d3cb => 95
	i32 1885316902, ; 98: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 35
	i32 1908813208, ; 99: Xamarin.GooglePlayServices.Basement => 0x71c62d98 => 99
	i32 1919157823, ; 100: Xamarin.AndroidX.MultiDex.dll => 0x7264063f => 68
	i32 1983156543, ; 101: Xamarin.Kotlin.StdLib.Common.dll => 0x7634913f => 103
	i32 2011961780, ; 102: System.Buffers.dll => 0x77ec19b4 => 17
	i32 2019465201, ; 103: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 63
	i32 2055257422, ; 104: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 59
	i32 2079903147, ; 105: System.Runtime.dll => 0x7bf8cdab => 26
	i32 2090596640, ; 106: System.Numerics.Vectors => 0x7c9bf920 => 24
	i32 2097448633, ; 107: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 55
	i32 2113902067, ; 108: Xamarin.Forms.PancakeView.dll => 0x7dff95f3 => 92
	i32 2126786730, ; 109: Xamarin.Forms.Platform.Android => 0x7ec430aa => 93
	i32 2129483829, ; 110: Xamarin.GooglePlayServices.Base.dll => 0x7eed5835 => 98
	i32 2192057212, ; 111: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 8
	i32 2201107256, ; 112: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 108
	i32 2201231467, ; 113: System.Net.Http => 0x8334206b => 22
	i32 2217644978, ; 114: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 83
	i32 2244775296, ; 115: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 66
	i32 2256548716, ; 116: Xamarin.AndroidX.MultiDex => 0x8680336c => 68
	i32 2261435625, ; 117: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x86cac4e9 => 57
	i32 2279755925, ; 118: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 75
	i32 2315684594, ; 119: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 30
	i32 2397082276, ; 120: Xamarin.Forms.PancakeView => 0x8ee092a4 => 92
	i32 2403452196, ; 121: Xamarin.AndroidX.Emoji2.dll => 0x8f41c524 => 51
	i32 2409053734, ; 122: Xamarin.AndroidX.Preference.dll => 0x8f973e26 => 72
	i32 2445024337, ; 123: Xamarin.Forms.GoogleMaps.Android.dll => 0x91bc1c51 => 90
	i32 2465532216, ; 124: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 41
	i32 2471841756, ; 125: netstandard.dll => 0x93554fdc => 1
	i32 2475788418, ; 126: Java.Interop.dll => 0x93918882 => 4
	i32 2501346920, ; 127: System.Data.DataSetExtensions => 0x95178668 => 111
	i32 2505896520, ; 128: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 62
	i32 2581819634, ; 129: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 84
	i32 2605712449, ; 130: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 108
	i32 2620871830, ; 131: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 46
	i32 2624644809, ; 132: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 50
	i32 2633051222, ; 133: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 60
	i32 2701096212, ; 134: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 81
	i32 2732417538, ; 135: PetLifeApp => 0xa2dd6202 => 13
	i32 2732626843, ; 136: Xamarin.AndroidX.Activity => 0xa2e0939b => 29
	i32 2737747696, ; 137: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 32
	i32 2766581644, ; 138: Xamarin.Forms.Core => 0xa4e6af8c => 89
	i32 2770495804, ; 139: Xamarin.Jetbrains.Annotations.dll => 0xa522693c => 102
	i32 2778768386, ; 140: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 86
	i32 2779977773, ; 141: Xamarin.AndroidX.ResourceInspection.Annotation.dll => 0xa5b3182d => 76
	i32 2795602088, ; 142: SkiaSharp.Views.Android.dll => 0xa6a180a8 => 15
	i32 2810250172, ; 143: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 43
	i32 2819470561, ; 144: System.Xml.dll => 0xa80db4e1 => 27
	i32 2821294376, ; 145: Xamarin.AndroidX.ResourceInspection.Annotation => 0xa8298928 => 76
	i32 2847418871, ; 146: Xamarin.GooglePlayServices.Base => 0xa9b829f7 => 98
	i32 2853208004, ; 147: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 86
	i32 2855708567, ; 148: Xamarin.AndroidX.Transition => 0xaa36a797 => 82
	i32 2903344695, ; 149: System.ComponentModel.Composition => 0xad0d8637 => 115
	i32 2905242038, ; 150: mscorlib.dll => 0xad2a79b6 => 10
	i32 2912489636, ; 151: SkiaSharp.Views.Android => 0xad9910a4 => 15
	i32 2916838712, ; 152: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 87
	i32 2919462931, ; 153: System.Numerics.Vectors.dll => 0xae037813 => 24
	i32 2921128767, ; 154: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 31
	i32 2974793899, ; 155: SkiaSharp.Views.Forms.dll => 0xb14fc0ab => 16
	i32 2978675010, ; 156: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 49
	i32 2996846495, ; 157: Xamarin.AndroidX.Lifecycle.Process.dll => 0xb2a03f9f => 61
	i32 3016983068, ; 158: Xamarin.AndroidX.Startup.StartupRuntime => 0xb3d3821c => 79
	i32 3017076677, ; 159: Xamarin.GooglePlayServices.Maps => 0xb3d4efc5 => 100
	i32 3024354802, ; 160: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 56
	i32 3036068679, ; 161: Microcharts.Droid.dll => 0xb4f6bb47 => 6
	i32 3044182254, ; 162: FormsViewGroup => 0xb57288ee => 3
	i32 3057625584, ; 163: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 69
	i32 3058099980, ; 164: Xamarin.GooglePlayServices.Tasks => 0xb646e70c => 101
	i32 3111772706, ; 165: System.Runtime.Serialization => 0xb979e222 => 2
	i32 3204380047, ; 166: System.Data.dll => 0xbefef58f => 109
	i32 3211777861, ; 167: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 48
	i32 3230466174, ; 168: Xamarin.GooglePlayServices.Basement.dll => 0xc08d007e => 99
	i32 3247949154, ; 169: Mono.Security => 0xc197c562 => 118
	i32 3258312781, ; 170: Xamarin.AndroidX.CardView => 0xc235e84d => 38
	i32 3267021929, ; 171: Xamarin.AndroidX.AsyncLayoutInflater => 0xc2bacc69 => 36
	i32 3317135071, ; 172: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 47
	i32 3317144872, ; 173: System.Data => 0xc5b79d28 => 109
	i32 3340387945, ; 174: SkiaSharp => 0xc71a4669 => 14
	i32 3340431453, ; 175: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 35
	i32 3345895724, ; 176: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller.dll => 0xc76e512c => 74
	i32 3346324047, ; 177: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 70
	i32 3353484488, ; 178: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 55
	i32 3362522851, ; 179: Xamarin.AndroidX.Core => 0xc86c06e3 => 45
	i32 3366347497, ; 180: Java.Interop => 0xc8a662e9 => 4
	i32 3374999561, ; 181: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 75
	i32 3395150330, ; 182: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 25
	i32 3404865022, ; 183: System.ServiceModel.Internals => 0xcaf21dfe => 117
	i32 3424488959, ; 184: PetLifeApp.Android.dll => 0xcc1d8dff => 0
	i32 3429136800, ; 185: System.Xml => 0xcc6479a0 => 27
	i32 3430777524, ; 186: netstandard => 0xcc7d82b4 => 1
	i32 3441283291, ; 187: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 50
	i32 3455791806, ; 188: Microcharts => 0xcdfb32be => 5
	i32 3459516321, ; 189: Xamarin.Forms.GoogleMaps => 0xce3407a1 => 91
	i32 3476120550, ; 190: Mono.Android => 0xcf3163e6 => 9
	i32 3486566296, ; 191: System.Transactions => 0xcfd0c798 => 110
	i32 3493954962, ; 192: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 40
	i32 3501239056, ; 193: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0xd0b0ab10 => 36
	i32 3509114376, ; 194: System.Xml.Linq => 0xd128d608 => 28
	i32 3536029504, ; 195: Xamarin.Forms.Platform.Android.dll => 0xd2c38740 => 93
	i32 3567349600, ; 196: System.ComponentModel.Composition.dll => 0xd4a16f60 => 115
	i32 3618140916, ; 197: Xamarin.AndroidX.Preference => 0xd7a872f4 => 72
	i32 3627220390, ; 198: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 73
	i32 3632359727, ; 199: Xamarin.Forms.Platform => 0xd881692f => 94
	i32 3633644679, ; 200: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 31
	i32 3641597786, ; 201: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 59
	i32 3668042751, ; 202: Microcharts.dll => 0xdaa1e3ff => 5
	i32 3672681054, ; 203: Mono.Android.dll => 0xdae8aa5e => 9
	i32 3676310014, ; 204: System.Web.Services.dll => 0xdb2009fe => 116
	i32 3682565725, ; 205: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 37
	i32 3684561358, ; 206: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 40
	i32 3689375977, ; 207: System.Drawing.Common => 0xdbe768e9 => 112
	i32 3706696989, ; 208: Xamarin.AndroidX.Core.Core.Ktx.dll => 0xdcefb51d => 44
	i32 3718780102, ; 209: Xamarin.AndroidX.Annotation => 0xdda814c6 => 30
	i32 3724971120, ; 210: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 69
	i32 3748608112, ; 211: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 19
	i32 3758932259, ; 212: Xamarin.AndroidX.Legacy.Support.V4 => 0xe00cc123 => 57
	i32 3786282454, ; 213: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 39
	i32 3822602673, ; 214: Xamarin.AndroidX.Media => 0xe3d849b1 => 67
	i32 3829621856, ; 215: System.Numerics.dll => 0xe4436460 => 23
	i32 3885922214, ; 216: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 82
	i32 3888767677, ; 217: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller => 0xe7c9e2bd => 74
	i32 3896760992, ; 218: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 45
	i32 3903721208, ; 219: Microcharts.Forms => 0xe8ae0ef8 => 7
	i32 3920810846, ; 220: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 114
	i32 3921031405, ; 221: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 85
	i32 3931092270, ; 222: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 71
	i32 3945713374, ; 223: System.Data.DataSetExtensions.dll => 0xeb2ecede => 111
	i32 3955647286, ; 224: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 33
	i32 3959773229, ; 225: Xamarin.AndroidX.Lifecycle.Process => 0xec05582d => 61
	i32 3970018735, ; 226: Xamarin.GooglePlayServices.Tasks.dll => 0xeca1adaf => 101
	i32 4025784931, ; 227: System.Memory => 0xeff49a63 => 21
	i32 4079385022, ; 228: MySqlConnector.dll => 0xf32679be => 11
	i32 4101593132, ; 229: Xamarin.AndroidX.Emoji2 => 0xf479582c => 51
	i32 4105002889, ; 230: Mono.Security.dll => 0xf4ad5f89 => 118
	i32 4151237749, ; 231: System.Core => 0xf76edc75 => 18
	i32 4182413190, ; 232: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 64
	i32 4213026141, ; 233: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 19
	i32 4256097574, ; 234: Xamarin.AndroidX.Core.Core.Ktx => 0xfdaee526 => 44
	i32 4260525087, ; 235: System.Buffers => 0xfdf2741f => 17
	i32 4278134329, ; 236: Xamarin.GooglePlayServices.Maps.dll => 0xfeff2639 => 100
	i32 4292120959 ; 237: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 64
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [238 x i32] [
	i32 62, i32 97, i32 12, i32 89, i32 78, i32 78, i32 105, i32 39, ; 0..7
	i32 80, i32 37, i32 56, i32 116, i32 42, i32 60, i32 54, i32 29, ; 8..15
	i32 23, i32 58, i32 21, i32 41, i32 88, i32 53, i32 10, i32 20, ; 16..23
	i32 54, i32 66, i32 14, i32 110, i32 105, i32 114, i32 47, i32 52, ; 24..31
	i32 85, i32 34, i32 28, i32 107, i32 102, i32 106, i32 113, i32 0, ; 32..39
	i32 112, i32 73, i32 6, i32 97, i32 12, i32 106, i32 58, i32 3, ; 40..47
	i32 77, i32 33, i32 94, i32 63, i32 104, i32 20, i32 13, i32 83, ; 48..55
	i32 70, i32 34, i32 79, i32 84, i32 107, i32 49, i32 91, i32 117, ; 56..63
	i32 90, i32 77, i32 67, i32 43, i32 25, i32 95, i32 113, i32 32, ; 64..71
	i32 11, i32 48, i32 7, i32 2, i32 65, i32 87, i32 52, i32 46, ; 72..79
	i32 22, i32 26, i32 81, i32 96, i32 42, i32 103, i32 16, i32 38, ; 80..87
	i32 80, i32 18, i32 53, i32 65, i32 104, i32 96, i32 71, i32 8, ; 88..95
	i32 88, i32 95, i32 35, i32 99, i32 68, i32 103, i32 17, i32 63, ; 96..103
	i32 59, i32 26, i32 24, i32 55, i32 92, i32 93, i32 98, i32 8, ; 104..111
	i32 108, i32 22, i32 83, i32 66, i32 68, i32 57, i32 75, i32 30, ; 112..119
	i32 92, i32 51, i32 72, i32 90, i32 41, i32 1, i32 4, i32 111, ; 120..127
	i32 62, i32 84, i32 108, i32 46, i32 50, i32 60, i32 81, i32 13, ; 128..135
	i32 29, i32 32, i32 89, i32 102, i32 86, i32 76, i32 15, i32 43, ; 136..143
	i32 27, i32 76, i32 98, i32 86, i32 82, i32 115, i32 10, i32 15, ; 144..151
	i32 87, i32 24, i32 31, i32 16, i32 49, i32 61, i32 79, i32 100, ; 152..159
	i32 56, i32 6, i32 3, i32 69, i32 101, i32 2, i32 109, i32 48, ; 160..167
	i32 99, i32 118, i32 38, i32 36, i32 47, i32 109, i32 14, i32 35, ; 168..175
	i32 74, i32 70, i32 55, i32 45, i32 4, i32 75, i32 25, i32 117, ; 176..183
	i32 0, i32 27, i32 1, i32 50, i32 5, i32 91, i32 9, i32 110, ; 184..191
	i32 40, i32 36, i32 28, i32 93, i32 115, i32 72, i32 73, i32 94, ; 192..199
	i32 31, i32 59, i32 5, i32 9, i32 116, i32 37, i32 40, i32 112, ; 200..207
	i32 44, i32 30, i32 69, i32 19, i32 57, i32 39, i32 67, i32 23, ; 208..215
	i32 82, i32 74, i32 45, i32 7, i32 114, i32 85, i32 71, i32 111, ; 216..223
	i32 33, i32 61, i32 101, i32 21, i32 11, i32 51, i32 118, i32 18, ; 224..231
	i32 64, i32 19, i32 44, i32 17, i32 100, i32 64 ; 232..237
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 4; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 4

; Function attributes: "frame-pointer"="none" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 4
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 4
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="none" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" "stackrealign" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="none" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" "stackrealign" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"NumRegisterParameters", i32 0}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ 797e2e13d1706ace607da43703769c5a55c4de60"}
!llvm.linker.options = !{}
