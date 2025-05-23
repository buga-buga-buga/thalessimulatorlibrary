/*
 This program is free software; you can redistribute it and/or modify
 it under the terms of the GNU General Public License as published by
 the Free Software Foundation; either version 2 of the License, or
 (at your option) any later version.

 This program is distributed in the hope that it will be useful,
 but WITHOUT ANY WARRANTY; without even the implied warranty of
 MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 GNU General Public License for more details.

 You should have received a copy of the GNU General Public License
 along with this program; if not, write to the Free Software
 Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
*/

/*
===============================================================================
 Thales Error Codes Reference (payShield 9000 Host Command Reference Manual)
===============================================================================
Code  Description
----  ------------------------------------------------------------------------
00    No error
01    Verification failure or warning of imported key parity error
02    Key inappropriate length for algorithm
04    Invalid key type code
05    Invalid key length flag
10    Source key parity error
11    Destination key parity error or key all zeros
12    Contents of user storage not available. Reset, power-down or overwrite
13    Invalid LMK Identifier
14    PIN encrypted under LMK pair 02-03 is invalid
15    Invalid input data (invalid format, invalid characters, or not enough data provided)
16    Console or printer not ready or not connected
17    HSM not authorized, or operation prohibited by security settings
18    Document format definition not loaded
19    Specified Diebold Table is invalid
20    PIN block does not contain valid values
21    Invalid index value, or index/block count would cause an overflow condition
22    Invalid account number
23    Invalid PIN block format code (PCI HSM limitation or disallowed format)
24    PIN is fewer than 4 or more than 12 digits in length
25    Decimalization Table error
26    Invalid key scheme
27    Incompatible key length
28    Invalid key type
29    Key function not permitted
30    Invalid reference number
31    Insufficient solicitation entries for batch
32    LIC007 (AES) not installed
33    LMK key change storage is corrupted
39    Fraud detection
40    Invalid checksum
41    Internal hardware/software error: bad RAM, invalid error codes, etc.
42    DES failure
43    RSA Key Generation Failure
46    Invalid tag for encrypted PIN
47    Algorithm not licensed
49    Private key error, report to supervisor
51    Invalid message header
65    Transaction Key Scheme set to None
67    Command not licensed
68    Command has been disabled
69    PIN block format has been disabled
74    Invalid digest info syntax (no hash mode only)
75    Single length key masquerading as double or triple length key
76    RSA public key length error or RSA encrypted data length error
77    Clear data block error
78    Private key length error
79    Hash algorithm object identifier error
80    Data length error. The amount of MAC data (or other data) is greater than or less than the expected amount.
81    Invalid certificate header
82    Invalid check value length
83    Key block format error
84    Key block check value error
85    Invalid OAEP Mask Generation Function
86    Invalid OAEP MGF Hash Function
87    OAEP Parameter Error
90    Data parity error in the request message received by the HSM
91    Longitudinal Redundancy Check (LRC) character does not match the value computed over the input data
92    The Count value is not between limits, or is not correct
A1    Incompatible LMK schemes
A2    Incompatible LMK identifiers
A3    Incompatible key block LMK identifiers
A4    Key block authentication failure
A5    Incompatible key length
A6    Invalid key usage
A7    Invalid algorithm
A8    Invalid mode of use
A9    Invalid key version number
AA    Invalid export field
AB    Invalid number of optional blocks
AC    Optional header block error
AD    Key status optional block error
AE    Invalid start date/time
AF    Invalid end date/time
B0    Invalid encryption mode
B1    Invalid authentication mode
B2    Miscellaneous key block error
B3    Invalid number of optional blocks
B4    Optional block data error
B5    Incompatible components
B6    Incompatible key status optional blocks
B7    Invalid change field
B8    Invalid old value
B9    Invalid new value
BA    No key status block in the key block
BB    Invalid wrapping key
BC    Repeated optional block
BD    Incompatible key types
BE    Invalid key block header ID
===============================================================================
*/

namespace ThalesSim.Core.Resources
{
    /// <summary>
    /// Constants with the Thales error codes.
    /// </summary>
    public class ErrorCodes
    {
        /// <summary>
        /// Thales error code 00.
        /// </summary>
        /// <remarks>No error.</remarks>    
        public const string ER_00_NO_ERROR = "00";

        /// <summary>
        /// Thales error code 01.
        /// </summary>
        /// <remarks>
        /// Verification failure.
        /// </remarks>
        public const string ER_01_VERIFICATION_FAILURE = "01";

        /// <summary>
        /// Thales error code 02.
        /// </summary>
        /// <remarks>
        /// Inappropriate key length for algorithm.
        /// </remarks>
        public const string ER_02_INAPPROPRIATE_KEY_LENGTH_FOR_ALGORITHM = "02";

        /// <summary>
        /// Thales error code 03.
        /// </summary>
        /// <remarks>
        /// Invalid number of components.
        /// </remarks>
        public const string ER_03_INVALID_NUMBER_OF_COMPONENTS = "03";

        /// <summary>
        /// Thales error code 04.
        /// </summary>
        /// <remarks>
        /// Invalid key type code.
        /// </remarks>
        public const string ER_04_INVALID_KEY_TYPE_CODE = "04";

        /// <summary>
        /// Thales error code 05.
        /// </summary>
        /// <remarks>
        /// Invalid key length flag.
        /// </remarks>
        public const string ER_05_INVALID_KEY_LENGTH_FLAG = "05";

        /// <summary>
        /// Thales error code 05.
        /// </summary>
        /// <remarks>
        /// Invalid hash identifier.
        /// </remarks>
        public const string ER_05_INVALID_HASH_IDENTIFIER = "05";

        /// <summary>
        /// Thales error code 10.
        /// </summary>
        /// <remarks>
        /// Source key parity error.
        /// </remarks>
        public const string ER_10_SOURCE_KEY_PARITY_ERROR = "10";

        /// <summary>
        /// Thales error code 11.
        /// </summary>
        /// <remarks>
        /// Destination key parity error.
        /// </remarks>
        public const string ER_11_DESTINATION_KEY_PARITY_ERROR = "11";

        /// <summary>
        /// Thales error code 12.
        /// </summary>
        /// <remarks>
        /// Contents of user storage not available.
        /// </remarks>
        public const string ER_12_CONTENTS_OF_USER_STORAGE_NOT_AVAILABLE = "12";

        /// <summary>
        /// Thales error code 13.
        /// </summary>
        /// <remarks>
        /// Master key parity error.
        /// </remarks>
        public const string ER_13_MASTER_KEY_PARITY_ERROR = "13";

        /// <summary>
        /// Thales error code 14.
        /// </summary>
        /// <remarks>
        /// PIN encrypted under LMK pair 02-03 is invalid.
        /// </remarks>
        public const string ER_14_PIN_ENCRYPTED_UNDER_LMK_PAIR_02_03_IS_INVALID = "14";

        /// <summary>
        /// Thales error code 15.
        /// </summary>
        /// <remarks>
        /// Invalid input data.
        /// </remarks>
        public const string ER_15_INVALID_INPUT_DATA = "15";

        /// <summary>
        /// Thales error code 16.
        /// </summary>
        /// <remarks>
        /// Console or printer not ready/not connected.
        /// </remarks>
        public const string ER_16_CONSOLE_OR_PRINTER_NOT_READY_NOT_CONNECTED = "16";

        /// <summary>
        /// Thales error code 17.
        /// </summary>
        /// <remarks>
        /// HSM is not in the authorized state.
        /// </remarks>
        public const string ER_17_HSM_IS_NOT_IN_THE_AUTHORIZED_STATE = "17";

        /// <summary>
        /// Thales error code 18.
        /// </summary>
        /// <remarks>
        /// Document definition not loaded.
        /// </remarks>
        public const string ER_18_DOCUMENT_DEFINITION_NOT_LOADED = "18";

        /// <summary>
        /// Thales error code 19.
        /// </summary>
        /// <remarks>
        /// Specified Diebold table is invalid.
        /// </remarks>
        public const string ER_19_SPECIFIED_DIEBOLD_TABLE_IS_INVALID = "19";

        /// <summary>
        /// Thales error code 20.
        /// </summary>
        /// <remarks>
        /// PIN block does not contain valid values.
        /// </remarks>
        public const string ER_20_PIN_BLOCK_DOES_NOT_CONTAIN_VALID_VALUES = "20";

        /// <summary>
        /// Thales error code 21.
        /// </summary>
        /// <remarks>
        /// Invalid index value.
        /// </remarks>
        public const string ER_21_INVALID_INDEX_VALUE = "21";

        /// <summary>
        /// Thales error code 22.
        /// </summary>
        /// <remarks>
        /// Invalid account number.
        /// </remarks>
        public const string ER_22_INVALID_ACCOUNT_NUMBER = "22";

        /// <summary>
        /// Thales error code 23.
        /// </summary>
        /// <remarks>
        /// Invalid PIN block format code.
        /// </remarks>
        public const string ER_23_INVALID_PIN_BLOCK_FORMAT_CODE = "23";

        /// <summary>
        /// Thales error code 24.
        /// </summary>
        /// <remarks>
        /// PIN is fewer than 4 or more than 12 digits long.
        /// </remarks>
        public const string ER_24_PIN_IS_FEWER_THAN_4_OR_MORE_THAN_12_DIGITS_LONG = "24";

        /// <summary>
        /// Thales error code 25.
        /// </summary>
        /// <remarks>
        /// Decimalization table error.
        /// </remarks>
        public const string ER_25_DECIMALIZATION_TABLE_ERROR = "25";

        /// <summary>
        /// Thales error code 26.
        /// </summary>
        /// <remarks>
        /// Invalid key scheme.
        /// </remarks>
        public const string ER_26_INVALID_KEY_SCHEME = "26";

        /// <summary>
        /// Thales error code 27.
        /// </summary>
        /// <remarks>
        /// Incompatible key length.
        /// </remarks>
        public const string ER_27_INCOMPATIBLE_KEY_LENGTH = "27";

        /// <summary>
        /// Thales error code 28.
        /// </summary>
        /// <remarks>
        /// Invalid key type.
        /// </remarks>
        public const string ER_28_INVALID_KEY_TYPE = "28";

        /// <summary>
        /// Thales error code 29.
        /// </summary>
        /// <remarks>
        /// Function not permitted.
        /// </remarks>
        public const string ER_29_FUNCTION_NOT_PERMITTED = "29";

        /// <summary>
        /// Thales error code 30.
        /// </summary>
        /// <remarks>
        /// Invalid reference number.
        /// </remarks>
        public const string ER_30_INVALID_REFERENCE_NUMBER = "30";

        /// <summary>
        /// Thales error code 31.
        /// </summary>
        /// <remarks>
        /// Insuficcient solicitation entries for batch.
        /// </remarks>
        public const string ER_31_INSUFICCIENT_SOLICITATION_ENTRIES_FOR_BATCH = "31";

        /// <summary>
        /// Thales error code 32. LIC007 (AES) not installed.
        /// </summary>
        public const string ER_32_LIC007_AES_NOT_INSTALLED = "32";

        /// <summary>
        /// Thales error code 33.
        /// </summary>
        /// <remarks>
        /// LMK key change storage is corrupted.
        /// </remarks>
        public const string ER_33_LMK_KEY_CHANGE_STORAGE_IS_CORRUPTED = "33";

        /// <summary>
        /// Thales error code 39. Fraud detection.
        /// </summary>
        public const string ER_39_FRAUD_DETECTION = "39";

        /// <summary>
        /// Thales error code 40.
        /// </summary>
        /// <remarks>
        /// Invalid firmware checksum.
        /// </remarks>
        public const string ER_40_INVALID_FIRMWARE_CHECKSUM = "40";

        /// <summary>
        /// Thales error code 41.
        /// </summary>
        /// <remarks>
        /// Internal hardware/software error.
        /// </remarks>
        public const string ER_41_INTERNAL_HARDWARE_SOFTWARE_ERROR = "41";

        /// <summary>
        /// Thales error code 42.
        /// </summary>
        /// <remarks>
        /// DES failure.
        /// </remarks>
        public const string ER_42_DES_FAILURE = "42";

        /// <summary>
        /// Thales error code 43. RSA Key Generation Failure.
        /// </summary>
        public const string ER_43_RSA_KEY_GENERATION_FAILURE = "43";

        /// <summary>
        /// Thales error code 46. Invalid tag for encrypted PIN.
        /// </summary>
        public const string ER_46_INVALID_TAG_FOR_ENCRYPTED_PIN = "46";

        /// <summary>
        /// Thales error code 47. Algorithm not licensed.
        /// </summary>
        public const string ER_47_ALGORITHM_NOT_LICENSED = "47";

        /// <summary>
        /// Thales error code 49. Private key error, report to supervisor.
        /// </summary>
        public const string ER_49_PRIVATE_KEY_ERROR = "49";

        /// <summary>
        /// Error code 51 
        /// </summary>
        /// <remarks>Invalid message header</remarks>
        public const string ER_51_INVALID_MESSAGE_HEADER = "51";

        /// <summary>
        /// Error code 52.
        /// </summary>
        /// <remarks>Invalid Number of Commands field.</remarks>
        public const string ER_52_INVALID_NUMBER_OF_COMMANDS = "52";

        /// <summary>
        /// Thales error code 65. Transaction Key Scheme set to None.
        /// </summary>
        public const string ER_65_TRANSACTION_KEY_SCHEME_NONE = "65";

        /// <summary>
        /// Thales error code 67. Command not licensed.
        /// </summary>
        public const string ER_67_COMMAND_NOT_LICENSED = "67";

        /// <summary>
        /// Thales error code 68. Command has been disabled.
        /// </summary>
        public const string ER_68_COMMAND_DISABLED = "68";

        /// <summary>
        /// Thales error code 69. PIN block format has been disabled.
        /// </summary>
        public const string ER_69_PIN_BLOCK_FORMAT_DISABLED = "69";

        /// <summary>
        /// Thales error code 74. Invalid digest info syntax (no hash mode only).
        /// </summary>
        public const string ER_74_INVALID_DIGEST_INFO_SYNTAX = "74";

        /// <summary>
        /// Thales error code 75. Single length key masquerading as double or triple length key.
        /// </summary>
        public const string ER_75_SINGLE_LENGTH_KEY_MASQUERADING = "75";

        /// <summary>
        /// Thales error code 76. RSA public key length error or RSA encrypted data length error.
        /// </summary>
        public const string ER_76_RSA_KEY_LENGTH_ERROR = "76";

        /// <summary>
        /// Thales error code 77. Clear data block error.
        /// </summary>
        public const string ER_77_CLEAR_DATA_BLOCK_ERROR = "77";

        /// <summary>
        /// Thales error code 78. Private key length error.
        /// </summary>
        public const string ER_78_PRIVATE_KEY_LENGTH_ERROR = "78";

        /// <summary>
        /// Thales error code 79. Hash algorithm object identifier error.
        /// </summary>
        public const string ER_79_HASH_ALGORITHM_OID_ERROR = "79";

        /// <summary>
        /// Thales error code 80.
        /// </summary>
        /// <remarks>
        /// Data length error.
        /// </remarks>
        public const string ER_80_DATA_LENGTH_ERROR = "80";

        /// <summary>
        /// Thales error code 81. Invalid certificate header.
        /// </summary>
        public const string ER_81_INVALID_CERTIFICATE_HEADER = "81";

        /// <summary>
        /// Thales error code 82. Invalid check value length.
        /// </summary>
        public const string ER_82_INVALID_CHECK_VALUE_LENGTH = "82";

        /// <summary>
        /// Thales error code 83. Key block format error.
        /// </summary>
        public const string ER_83_KEY_BLOCK_FORMAT_ERROR = "83";

        /// <summary>
        /// Thales error code 84. Key block check value error.
        /// </summary>
        public const string ER_84_KEY_BLOCK_CHECK_VALUE_ERROR = "84";

        /// <summary>
        /// Thales error code 85. Invalid OAEP Mask Generation Function.
        /// </summary>
        public const string ER_85_INVALID_OAEP_MGF = "85";

        /// <summary>
        /// Thales error code 86. Invalid OAEP MGF Hash Function.
        /// </summary>
        public const string ER_86_INVALID_OAEP_MGF_HASH_FUNCTION = "86";

        /// <summary>
        /// Thales error code 87. OAEP Parameter Error.
        /// </summary>
        public const string ER_87_OAEP_PARAMETER_ERROR = "87";

        /// <summary>
        /// Thales error code 90.
        /// </summary>
        /// <remarks>
        /// Data parity error.
        /// </remarks>
        public const string ER_90_DATA_PARITY_ERROR = "90";

        /// <summary>
        /// Thales error code 91.
        /// </summary>
        /// <remarks>
        /// LRC error.
        /// </remarks>
        public const string ER_91_LRC_ERROR = "91";

        /// <summary>
        /// Thales error code 92.
        /// </summary>
        /// <remarks>
        /// Count value not between limits.
        /// </remarks>
        public const string ER_92_COUNT_VALUE_NOT_BETWEEN_LIMITS = "92";

        /// <summary>
        /// Thales error code A1. Incompatible LMK schemes.
        /// </summary>
        public const string ER_A1_INCOMPATIBLE_LMK_SCHEMES = "A1";

        /// <summary>
        /// Thales error code A2. Incompatible LMK identifiers.
        /// </summary>
        public const string ER_A2_INCOMPATIBLE_LMK_IDENTIFIERS = "A2";

        /// <summary>
        /// Thales error code A3. Incompatible key block LMK identifiers.
        /// </summary>
        public const string ER_A3_INCOMPATIBLE_KEY_BLOCK_LMK_IDENTIFIERS = "A3";

        /// <summary>
        /// Thales error code A4. Key block authentication failure.
        /// </summary>
        public const string ER_A4_KEY_BLOCK_AUTHENTICATION_FAILURE = "A4";

        /// <summary>
        /// Thales error code A5. Incompatible key length.
        /// </summary>
        public const string ER_A5_INCOMPATIBLE_KEY_LENGTH = "A5";

        /// <summary>
        /// Thales error code A6. Invalid key usage.
        /// </summary>
        public const string ER_A6_INVALID_KEY_USAGE = "A6";

        /// <summary>
        /// Thales error code A7. Invalid algorithm.
        /// </summary>
        public const string ER_A7_INVALID_ALGORITHM = "A7";

        /// <summary>
        /// Thales error code A8. Invalid mode of use.
        /// </summary>
        public const string ER_A8_INVALID_MODE_OF_USE = "A8";

        /// <summary>
        /// Thales error code A9. Invalid key version number.
        /// </summary>
        public const string ER_A9_INVALID_KEY_VERSION_NUMBER = "A9";

        /// <summary>
        /// Thales error code AA. Invalid export field.
        /// </summary>
        public const string ER_AA_INVALID_EXPORT_FIELD = "AA";

        /// <summary>
        /// Thales error code AB. Invalid number of optional blocks.
        /// </summary>
        public const string ER_AB_INVALID_NUMBER_OF_OPTIONAL_BLOCKS = "AB";

        /// <summary>
        /// Thales error code AC. Optional header block error.
        /// </summary>
        public const string ER_AC_OPTIONAL_HEADER_BLOCK_ERROR = "AC";

        /// <summary>
        /// Thales error code AD. Key status optional block error.
        /// </summary>
        public const string ER_AD_KEY_STATUS_OPTIONAL_BLOCK_ERROR = "AD";

        /// <summary>
        /// Thales error code AE. Invalid start date/time.
        /// </summary>
        public const string ER_AE_INVALID_START_DATE_TIME = "AE";

        /// <summary>
        /// Thales error code AF. Invalid end date/time.
        /// </summary>
        public const string ER_AF_INVALID_END_DATE_TIME = "AF";

        /// <summary>
        /// Thales error code B0. Invalid encryption mode.
        /// </summary>
        public const string ER_B0_INVALID_ENCRYPTION_MODE = "B0";

        /// <summary>
        /// Thales error code B1. Invalid authentication mode.
        /// </summary>
        public const string ER_B1_INVALID_AUTHENTICATION_MODE = "B1";

        /// <summary>
        /// Thales error code B2. Miscellaneous key block error.
        /// </summary>
        public const string ER_B2_MISCELLANEOUS_KEY_BLOCK_ERROR = "B2";

        /// <summary>
        /// Thales error code B3. Invalid number of optional blocks.
        /// </summary>
        public const string ER_B3_INVALID_NUMBER_OF_OPTIONAL_BLOCKS = "B3";

        /// <summary>
        /// Thales error code B4. Optional block data error.
        /// </summary>
        public const string ER_B4_OPTIONAL_BLOCK_DATA_ERROR = "B4";

        /// <summary>
        /// Thales error code B5. Incompatible components.
        /// </summary>
        public const string ER_B5_INCOMPATIBLE_COMPONENTS = "B5";

        /// <summary>
        /// Thales error code B6. Incompatible key status optional blocks.
        /// </summary>
        public const string ER_B6_INCOMPATIBLE_KEY_STATUS_OPTIONAL_BLOCKS = "B6";

        /// <summary>
        /// Thales error code B7. Invalid change field.
        /// </summary>
        public const string ER_B7_INVALID_CHANGE_FIELD = "B7";

        /// <summary>
        /// Thales error code B8. Invalid old value.
        /// </summary>
        public const string ER_B8_INVALID_OLD_VALUE = "B8";

        /// <summary>
        /// Thales error code B9. Invalid new value.
        /// </summary>
        public const string ER_B9_INVALID_NEW_VALUE = "B9";

        /// <summary>
        /// Thales error code BA. No key status block in the key block.
        /// </summary>
        public const string ER_BA_NO_KEY_STATUS_BLOCK = "BA";

        /// <summary>
        /// Thales error code BB. Invalid wrapping key.
        /// </summary>
        public const string ER_BB_INVALID_WRAPPING_KEY = "BB";

        /// <summary>
        /// Thales error code BC. Repeated optional block.
        /// </summary>
        public const string ER_BC_REPEATED_OPTIONAL_BLOCK = "BC";

        /// <summary>
        /// Thales error code BD. Incompatible key types.
        /// </summary>
        public const string ER_BD_INCOMPATIBLE_KEY_TYPES = "BD";

        /// <summary>
        /// Thales error code BE. Invalid key block header ID.
        /// </summary>
        public const string ER_BE_INVALID_KEY_BLOCK_HEADER_ID = "BE";

        /// <summary>
        /// Thales error code ZZ.
        /// </summary>
        /// <remarks>
        /// This error code may be internally used.
        /// </remarks>
        public const string ER_ZZ_UNKNOWN_ERROR = "ZZ";
    }
}
