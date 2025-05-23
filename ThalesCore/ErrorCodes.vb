''
'' This program is free software; you can redistribute it and/or modify
'' it under the terms of the GNU General Public License as published by
'' the Free Software Foundation; either version 2 of the License, or
'' (at your option) any later version.
''
'' This program is distributed in the hope that it will be useful,
'' but WITHOUT ANY WARRANTY; without even the implied warranty of
'' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'' GNU General Public License for more details.
''
'' You should have received a copy of the GNU General Public License
'' along with this program; if not, write to the Free Software
'' Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
'' 

'===============================================================================
' Thales Error Codes Reference (payShield 9000 Host Command Reference Manual)
'===============================================================================
'Code  Description
'----  ------------------------------------------------------------------------
'00    No error
'01    Verification failure or warning of imported key parity error
'02    Key inappropriate length for algorithm
'04    Invalid key type code
'05    Invalid key length flag
'10    Source key parity error
'11    Destination key parity error or key all zeros
'12    Contents of user storage not available. Reset, power-down or overwrite
'13    Invalid LMK Identifier
'14    PIN encrypted under LMK pair 02-03 is invalid
'15    Invalid input data (invalid format, invalid characters, or not enough data provided)
'16    Console or printer not ready or not connected
'17    HSM not authorized, or operation prohibited by security settings
'18    Document format definition not loaded
'19    Specified Diebold Table is invalid
'20    PIN block does not contain valid values
'21    Invalid index value, or index/block count would cause an overflow condition
'22    Invalid account number
'23    Invalid PIN block format code (PCI HSM limitation or disallowed format)
'24    PIN is fewer than 4 or more than 12 digits in length
'25    Decimalization Table error
'26    Invalid key scheme
'27    Incompatible key length
'28    Invalid key type
'29    Key function not permitted
'30    Invalid reference number
'31    Insufficient solicitation entries for batch
'32    LIC007 (AES) not installed
'33    LMK key change storage is corrupted
'39    Fraud detection
'40    Invalid checksum
'41    Internal hardware/software error: bad RAM, invalid error codes, etc.
'42    DES failure
'43    RSA Key Generation Failure
'46    Invalid tag for encrypted PIN
'47    Algorithm not licensed
'49    Private key error, report to supervisor
'51    Invalid message header
'65    Transaction Key Scheme set to None
'67    Command not licensed
'68    Command has been disabled
'69    PIN block format has been disabled
'74    Invalid digest info syntax (no hash mode only)
'75    Single length key masquerading as double or triple length key
'76    RSA public key length error or RSA encrypted data length error
'77    Clear data block error
'78    Private key length error
'79    Hash algorithm object identifier error
'80    Data length error. The amount of MAC data (or other data) is greater than or less than the expected amount.
'81    Invalid certificate header
'82    Invalid check value length
'83    Key block format error
'84    Key block check value error
'85    Invalid OAEP Mask Generation Function
'86    Invalid OAEP MGF Hash Function
'87    OAEP Parameter Error
'90    Data parity error in the request message received by the HSM
'91    Longitudinal Redundancy Check (LRC) character does not match the value computed over the input data
'92    The Count value is not between limits, or is not correct
'A1    Incompatible LMK schemes
'A2    Incompatible LMK identifiers
'A3    Incompatible key block LMK identifiers
'A4    Key block authentication failure
'A5    Incompatible key length
'A6    Invalid key usage
'A7    Invalid algorithm
'A8    Invalid mode of use
'A9    Invalid key version number
'AA    Invalid export field
'AB    Invalid number of optional blocks
'AC    Optional header block error
'AD    Key status optional block error
'AE    Invalid start date/time
'AF    Invalid end date/time
'B0    Invalid encryption mode
'B1    Invalid authentication mode
'B2    Miscellaneous key block error
'B3    Invalid number of optional blocks
'B4    Optional block data error
'B5    Incompatible components
'B6    Incompatible key status optional blocks
'B7    Invalid change field
'B8    Invalid old value
'B9    Invalid new value
'BA    No key status block in the key block
'BB    Invalid wrapping key
'BC    Repeated optional block
'BD    Incompatible key types
'BE    Invalid key block header ID
'===============================================================================

''' <summary>
''' This class abstracts the Racal returned error codes.
''' </summary>
''' <remarks>Most Racal error codes are declared as constants in this class.</remarks>
Public Class ErrorCodes

    ''' <summary>
    ''' Racal error code 00.
    ''' </summary>
    ''' <remarks>No error.</remarks>
    Public Const ER_00_NO_ERROR As String = "00"

    ''' <summary>
    ''' Racal error code 01.
    ''' </summary>
    ''' <remarks>
    ''' Verification failure.
    ''' </remarks>
    Public Const ER_01_VERIFICATION_FAILURE As String = "01"

    ''' <summary>
    ''' Racal error code 02.
    ''' </summary>
    ''' <remarks>
    ''' Inappropriate key length for algorithm.
    ''' </remarks>
    Public Const ER_02_INAPPROPRIATE_KEY_LENGTH_FOR_ALGORITHM As String = "02"

    ''' <summary>
    ''' Racal error code 03.
    ''' </summary>
    ''' <remarks>
    ''' Invalid number of components.
    ''' </remarks>
    Public Const ER_03_INVALID_NUMBER_OF_COMPONENTS As String = "03"

    ''' <summary>
    ''' Racal error code 04.
    ''' </summary>
    ''' <remarks>
    ''' Invalid key type code.
    ''' </remarks>
    Public Const ER_04_INVALID_KEY_TYPE_CODE As String = "04"

    ''' <summary>
    ''' Racal error code 05.
    ''' </summary>
    ''' <remarks>
    ''' Invalid key length flag.
    ''' </remarks>
    Public Const ER_05_INVALID_KEY_LENGTH_FLAG As String = "05"

    ''' <summary>
    ''' Racal error code 05.
    ''' </summary>
    ''' <remarks>
    ''' Invalid hash identifier.
    ''' </remarks>
    Public Const ER_05_INVALID_HASH_IDENTIFIER As String = "05"

    ''' <summary>
    ''' Racal error code 10.
    ''' </summary>
    ''' <remarks>
    ''' Source key parity error.
    ''' </remarks>
    Public Const ER_10_SOURCE_KEY_PARITY_ERROR As String = "10"

    ''' <summary>
    ''' Racal error code 11.
    ''' </summary>
    ''' <remarks>
    ''' Destination key parity error.
    ''' </remarks>
    Public Const ER_11_DESTINATION_KEY_PARITY_ERROR As String = "11"

    ''' <summary>
    ''' Racal error code 12.
    ''' </summary>
    ''' <remarks>
    ''' Contents of user storage not available.
    ''' </remarks>
    Public Const ER_12_CONTENTS_OF_USER_STORAGE_NOT_AVAILABLE As String = "12"

    ''' <summary>
    ''' Racal error code 13.
    ''' </summary>
    ''' <remarks>
    ''' Master key parity error.
    ''' </remarks>
    Public Const ER_13_MASTER_KEY_PARITY_ERROR As String = "13"

    ''' <summary>
    ''' Racal error code 14.
    ''' </summary>
    ''' <remarks>
    ''' PIN encrypted under LMK pair 02-03 is invalid.
    ''' </remarks>
    Public Const ER_14_PIN_ENCRYPTED_UNDER_LMK_PAIR_02_03_IS_INVALID As String = "14"

    ''' <summary>
    ''' Racal error code 15.
    ''' </summary>
    ''' <remarks>
    ''' Invalid input data.
    ''' </remarks>
    Public Const ER_15_INVALID_INPUT_DATA As String = "15"

    ''' <summary>
    ''' Racal error code 16.
    ''' </summary>
    ''' <remarks>
    ''' Console or printer not ready/not connected.
    ''' </remarks>
    Public Const ER_16_CONSOLE_OR_PRINTER_NOT_READY_NOT_CONNECTED As String = "16"

    ''' <summary>
    ''' Racal error code 17.
    ''' </summary>
    ''' <remarks>
    ''' HSM is not in the authorized state.
    ''' </remarks>
    Public Const ER_17_HSM_IS_NOT_IN_THE_AUTHORIZED_STATE As String = "17"

    ''' <summary>
    ''' Racal error code 18.
    ''' </summary>
    ''' <remarks>
    ''' Document definition not loaded.
    ''' </remarks>
    Public Const ER_18_DOCUMENT_DEFINITION_NOT_LOADED As String = "18"

    ''' <summary>
    ''' Racal error code 19.
    ''' </summary>
    ''' <remarks>
    ''' Specified Diebold table is invalid.
    ''' </remarks>
    Public Const ER_19_SPECIFIED_DIEBOLD_TABLE_IS_INVALID As String = "19"

    ''' <summary>
    ''' Racal error code 20.
    ''' </summary>
    ''' <remarks>
    ''' PIN block does not contain valid values.
    ''' </remarks>
    Public Const ER_20_PIN_BLOCK_DOES_NOT_CONTAIN_VALID_VALUES As String = "20"

    ''' <summary>
    ''' Racal error code 21.
    ''' </summary>
    ''' <remarks>
    ''' Invalid index value.
    ''' </remarks>
    Public Const ER_21_INVALID_INDEX_VALUE As String = "21"

    ''' <summary>
    ''' Racal error code 22.
    ''' </summary>
    ''' <remarks>
    ''' Invalid account number.
    ''' </remarks>
    Public Const ER_22_INVALID_ACCOUNT_NUMBER As String = "22"

    ''' <summary>
    ''' Racal error code 23.
    ''' </summary>
    ''' <remarks>
    ''' Invalid PIN block format code.
    ''' </remarks>
    Public Const ER_23_INVALID_PIN_BLOCK_FORMAT_CODE As String = "23"

    ''' <summary>
    ''' Racal error code 24.
    ''' </summary>
    ''' <remarks>
    ''' PIN is fewer than 4 or more than 12 digits long.
    ''' </remarks>
    Public Const ER_24_PIN_IS_FEWER_THAN_4_OR_MORE_THAN_12_DIGITS_LONG As String = "24"

    ''' <summary>
    ''' Racal error code 25.
    ''' </summary>
    ''' <remarks>
    ''' Decimalization table error.
    ''' </remarks>
    Public Const ER_25_DECIMALIZATION_TABLE_ERROR As String = "25"

    ''' <summary>
    ''' Racal error code 26.
    ''' </summary>
    ''' <remarks>
    ''' Invalid key scheme.
    ''' </remarks>
    Public Const ER_26_INVALID_KEY_SCHEME As String = "26"

    ''' <summary>
    ''' Racal error code 27.
    ''' </summary>
    ''' <remarks>
    ''' Incompatible key length.
    ''' </remarks>
    Public Const ER_27_INCOMPATIBLE_KEY_LENGTH As String = "27"

    ''' <summary>
    ''' Racal error code 28.
    ''' </summary>
    ''' <remarks>
    ''' Invalid key type.
    ''' </remarks>
    Public Const ER_28_INVALID_KEY_TYPE As String = "28"

    ''' <summary>
    ''' Racal error code 29.
    ''' </summary>
    ''' <remarks>
    ''' Function not permitted.
    ''' </remarks>
    Public Const ER_29_FUNCTION_NOT_PERMITTED As String = "29"

    ''' <summary>
    ''' Racal error code 30.
    ''' </summary>
    ''' <remarks>
    ''' Invalid reference number.
    ''' </remarks>
    Public Const ER_30_INVALID_REFERENCE_NUMBER As String = "30"

    ''' <summary>
    ''' Racal error code 31.
    ''' </summary>
    ''' <remarks>
    ''' Insuficcient solicitation entries for batch.
    ''' </remarks>
    Public Const ER_31_INSUFICCIENT_SOLICITATION_ENTRIES_FOR_BATCH As String = "31"

    ''' <summary>
    ''' Racal error code 33.
    ''' </summary>
    ''' <remarks>
    ''' LMK key change storage is corrupted.
    ''' </remarks>
    Public Const ER_33_LMK_KEY_CHANGE_STORAGE_IS_CORRUPTED As String = "33"

    ''' <summary>
    ''' Racal error code 40.
    ''' </summary>
    ''' <remarks>
    ''' Invalid firmware checksum.
    ''' </remarks>
    Public Const ER_40_INVALID_FIRMWARE_CHECKSUM As String = "40"

    ''' <summary>
    ''' Racal error code 41.
    ''' </summary>
    ''' <remarks>
    ''' Internal hardware/software error.
    ''' </remarks>
    Public Const ER_41_INTERNAL_HARDWARE_SOFTWARE_ERROR As String = "41"

    ''' <summary>
    ''' Racal error code 42.
    ''' </summary>
    ''' <remarks>
    ''' DES failure.
    ''' </remarks>
    Public Const ER_42_DES_FAILURE As String = "42"

    ''' <summary>
    ''' Error code 51 
    ''' </summary>
    ''' <remarks>Invalid message header</remarks>
    Public Const ER_51_INVALID_MESSAGE_HEADER As String = "51"

    ''' <summary>
    ''' Error code 52.
    ''' </summary>
    ''' <remarks>Invalid Number of Commands field.</remarks>
    Public Const ER_52_INVALID_NUMBER_OF_COMMANDS As String = "52"

    ''' <summary>
    ''' Racal error code 80.
    ''' </summary>
    ''' <remarks>
    ''' Data length error.
    ''' </remarks>
    Public Const ER_80_DATA_LENGTH_ERROR As String = "80"

    ''' <summary>
    ''' Racal error code 90.
    ''' </summary>
    ''' <remarks>
    ''' Data parity error.
    ''' </remarks>
    Public Const ER_90_DATA_PARITY_ERROR As String = "90"

    ''' <summary>
    ''' Racal error code 91.
    ''' </summary>
    ''' <remarks>
    ''' LRC error.
    ''' </remarks>
    Public Const ER_91_LRC_ERROR As String = "91"

    ''' <summary>
    ''' Racal error code 92.
    ''' </summary>
    ''' <remarks>
    ''' Count value not between limits.
    ''' </remarks>
    Public Const ER_92_COUNT_VALUE_NOT_BETWEEN_LIMITS As String = "92"

    ''' <summary>
    ''' Racal error code ZZ.
    ''' </summary>
    ''' <remarks>
    ''' This error code may be internally used.
    ''' </remarks>
    Public Const ER_ZZ_UNKNOWN_ERROR As String = "ZZ"

    ''' <summary>
    ''' LIC007 (AES) not installed.
    ''' </summary>
    Public Const ER_32_LIC007_AES_NOT_INSTALLED As String = "32"

    ''' <summary>
    ''' Fraud detection.
    ''' </summary>
    Public Const ER_39_FRAUD_DETECTION As String = "39"

    ''' <summary>
    ''' RSA Key Generation Failure.
    ''' </summary>
    Public Const ER_43_RSA_KEY_GENERATION_FAILURE As String = "43"

    ''' <summary>
    ''' Invalid tag for encrypted PIN.
    ''' </summary>
    Public Const ER_46_INVALID_TAG_FOR_ENCRYPTED_PIN As String = "46"

    ''' <summary>
    ''' Algorithm not licensed.
    ''' </summary>
    Public Const ER_47_ALGORITHM_NOT_LICENSED As String = "47"

    ''' <summary>
    ''' Private key error, report to supervisor.
    ''' </summary>
    Public Const ER_49_PRIVATE_KEY_ERROR As String = "49"

    ''' <summary>
    ''' Command not licensed.
    ''' </summary>
    Public Const ER_67_COMMAND_NOT_LICENSED As String = "67"

    ''' <summary>
    ''' Command has been disabled.
    ''' </summary>
    Public Const ER_68_COMMAND_DISABLED As String = "68"

    ''' <summary>
    ''' PIN block format has been disabled.
    ''' </summary>
    Public Const ER_69_PIN_BLOCK_FORMAT_DISABLED As String = "69"

    ''' <summary>
    ''' Invalid digest info syntax (no hash mode only).
    ''' </summary>
    Public Const ER_74_INVALID_DIGEST_INFO_SYNTAX As String = "74"

    ''' <summary>
    ''' Single length key masquerading as double or triple length key.
    ''' </summary>
    Public Const ER_75_SINGLE_LENGTH_KEY_MASQUERADING As String = "75"

    ''' <summary>
    ''' RSA public key length error or RSA encrypted data length error.
    ''' </summary>
    Public Const ER_76_RSA_KEY_LENGTH_ERROR As String = "76"

    ''' <summary>
    ''' Clear data block error.
    ''' </summary>
    Public Const ER_77_CLEAR_DATA_BLOCK_ERROR As String = "77"

    ''' <summary>
    ''' Private key length error.
    ''' </summary>
    Public Const ER_78_PRIVATE_KEY_LENGTH_ERROR As String = "78"

    ''' <summary>
    ''' Hash algorithm object identifier error.
    ''' </summary>
    Public Const ER_79_HASH_ALGORITHM_OID_ERROR As String = "79"

    ''' <summary>
    ''' Invalid certificate header.
    ''' </summary>
    Public Const ER_81_INVALID_CERTIFICATE_HEADER As String = "81"

    ''' <summary>
    ''' Invalid check value length.
    ''' </summary>
    Public Const ER_82_INVALID_CHECK_VALUE_LENGTH As String = "82"

    ''' <summary>
    ''' Key block format error.
    ''' </summary>
    Public Const ER_83_KEY_BLOCK_FORMAT_ERROR As String = "83"

    ''' <summary>
    ''' Key block check value error.
    ''' </summary>
    Public Const ER_84_KEY_BLOCK_CHECK_VALUE_ERROR As String = "84"

    ''' <summary>
    ''' Invalid OAEP Mask Generation Function.
    ''' </summary>
    Public Const ER_85_INVALID_OAEP_MGF As String = "85"

    ''' <summary>
    ''' Invalid OAEP MGF Hash Function.
    ''' </summary>
    Public Const ER_86_INVALID_OAEP_MGF_HASH_FUNCTION As String = "86"

    ''' <summary>
    ''' OAEP Parameter Error.
    ''' </summary>
    Public Const ER_87_OAEP_PARAMETER_ERROR As String = "87"

    ''' <summary>
    ''' Incompatible LMK schemes.
    ''' </summary>
    Public Const ER_A1_INCOMPATIBLE_LMK_SCHEMES As String = "A1"

    ''' <summary>
    ''' Incompatible LMK identifiers.
    ''' </summary>
    Public Const ER_A2_INCOMPATIBLE_LMK_IDENTIFIERS As String = "A2"

    ''' <summary>
    ''' Incompatible key block LMK identifiers.
    ''' </summary>
    Public Const ER_A3_INCOMPATIBLE_KEY_BLOCK_LMK_IDENTIFIERS As String = "A3"

    ''' <summary>
    ''' Key block authentication failure.
    ''' </summary>
    Public Const ER_A4_KEY_BLOCK_AUTHENTICATION_FAILURE As String = "A4"

    ''' <summary>
    ''' Incompatible key length.
    ''' </summary>
    Public Const ER_A5_INCOMPATIBLE_KEY_LENGTH As String = "A5"

    ''' <summary>
    ''' Invalid key usage.
    ''' </summary>
    Public Const ER_A6_INVALID_KEY_USAGE As String = "A6"

    ''' <summary>
    ''' Invalid algorithm.
    ''' </summary>
    Public Const ER_A7_INVALID_ALGORITHM As String = "A7"

    ''' <summary>
    ''' Invalid mode of use.
    ''' </summary>
    Public Const ER_A8_INVALID_MODE_OF_USE As String = "A8"

    ''' <summary>
    ''' Invalid key version number.
    ''' </summary>
    Public Const ER_A9_INVALID_KEY_VERSION_NUMBER As String = "A9"

    ''' <summary>
    ''' Invalid export field.
    ''' </summary>
    Public Const ER_AA_INVALID_EXPORT_FIELD As String = "AA"

    ''' <summary>
    ''' Invalid number of optional blocks.
    ''' </summary>
    Public Const ER_AB_INVALID_NUMBER_OF_OPTIONAL_BLOCKS As String = "AB"

    ''' <summary>
    ''' Optional header block error.
    ''' </summary>
    Public Const ER_AC_OPTIONAL_HEADER_BLOCK_ERROR As String = "AC"

    ''' <summary>
    ''' Key status optional block error.
    ''' </summary>
    Public Const ER_AD_KEY_STATUS_OPTIONAL_BLOCK_ERROR As String = "AD"

    ''' <summary>
    ''' Invalid start date/time.
    ''' </summary>
    Public Const ER_AE_INVALID_START_DATE_TIME As String = "AE"

    ''' <summary>
    ''' Invalid end date/time.
    ''' </summary>
    Public Const ER_AF_INVALID_END_DATE_TIME As String = "AF"

    ''' <summary>
    ''' Invalid encryption mode.
    ''' </summary>
    Public Const ER_B0_INVALID_ENCRYPTION_MODE As String = "B0"

    ''' <summary>
    ''' Invalid authentication mode.
    ''' </summary>
    Public Const ER_B1_INVALID_AUTHENTICATION_MODE As String = "B1"

    ''' <summary>
    ''' Miscellaneous key block error.
    ''' </summary>
    Public Const ER_B2_MISCELLANEOUS_KEY_BLOCK_ERROR As String = "B2"

    ''' <summary>
    ''' Invalid number of optional blocks.
    ''' </summary>
    Public Const ER_B3_INVALID_NUMBER_OF_OPTIONAL_BLOCKS As String = "B3"

    ''' <summary>
    ''' Optional block data error.
    ''' </summary>
    Public Const ER_B4_OPTIONAL_BLOCK_DATA_ERROR As String = "B4"

    ''' <summary>
    ''' Incompatible components.
    ''' </summary>
    Public Const ER_B5_INCOMPATIBLE_COMPONENTS As String = "B5"

    ''' <summary>
    ''' Incompatible key status optional blocks.
    ''' </summary>
    Public Const ER_B6_INCOMPATIBLE_KEY_STATUS_OPTIONAL_BLOCKS As String = "B6"

    ''' <summary>
    ''' Invalid change field.
    ''' </summary>
    Public Const ER_B7_INVALID_CHANGE_FIELD As String = "B7"

    ''' <summary>
    ''' Invalid old value.
    ''' </summary>
    Public Const ER_B8_INVALID_OLD_VALUE As String = "B8"

    ''' <summary>
    ''' Invalid new value.
    ''' </summary>
    Public Const ER_B9_INVALID_NEW_VALUE As String = "B9"

    ''' <summary>
    ''' No key status block in the key block.
    ''' </summary>
    Public Const ER_BA_NO_KEY_STATUS_BLOCK As String = "BA"

    ''' <summary>
    ''' Invalid wrapping key.
    ''' </summary>
    Public Const ER_BB_INVALID_WRAPPING_KEY As String = "BB"

    ''' <summary>
    ''' Repeated optional block.
    ''' </summary>
    Public Const ER_BC_REPEATED_OPTIONAL_BLOCK As String = "BC"

    ''' <summary>
    ''' Incompatible key types.
    ''' </summary>
    Public Const ER_BD_INCOMPATIBLE_KEY_TYPES As String = "BD"

    ''' <summary>
    ''' Invalid key block header ID.
    ''' </summary>
    Public Const ER_BE_INVALID_KEY_BLOCK_HEADER_ID As String = "BE"

    Private Shared _errors() As ThalesError = {New ThalesError("00", "No error"),
                                               New ThalesError("01", "Verification failure"),
                                               New ThalesError("02", "Inappropriate key length for algorithm"),
                                               New ThalesError("03", "Invalid number of components"),
                                               New ThalesError("04", "Invalid key type code"),
                                               New ThalesError("05", "Invalid key length flag"),
                                               New ThalesError("10", "Source key parity error"),
                                               New ThalesError("11", "Destination key parity error"),
                                               New ThalesError("12", "Contents of user storage not available"),
                                               New ThalesError("13", "Master key parity error"),
                                               New ThalesError("14", "PIN encrypted under LMK pair 02-03 is invalid"),
                                               New ThalesError("15", "Invalid input data"),
                                               New ThalesError("16", "Console or printer not ready/not connected"),
                                               New ThalesError("17", "HSM is not in the authorized state"),
                                               New ThalesError("18", "Document definition not loaded"),
                                               New ThalesError("19", "Specified Diebold table is invalid"),
                                               New ThalesError("20", "PIN block does not contain valid values"),
                                               New ThalesError("21", "Invalid index value"),
                                               New ThalesError("22", "Invalid account number"),
                                               New ThalesError("23", "Invalid PIN block format code"),
                                               New ThalesError("24", "PIN is fewer than 4 or more than 12 digits long"),
                                               New ThalesError("25", "Decimalization table error"),
                                               New ThalesError("26", "Invalid key scheme"),
                                               New ThalesError("27", "Incompatible key length"),
                                               New ThalesError("28", "Invalid key type"),
                                               New ThalesError("29", "Function not permitted"),
                                               New ThalesError("30", "Invalid reference number"),
                                               New ThalesError("31", "Insuficcient solicitation entries for batch"),
                                               New ThalesError("33", "LMK key change storage is corrupted"),
                                               New ThalesError("40", "Invalid firmware checksum"),
                                               New ThalesError("41", "Internal hardware/software error"),
                                               New ThalesError("42", "DES failure"),
                                               New ThalesError("51", "Invalid message header"),
                                               New ThalesError("52", "Invalid number of command fields"),
                                               New ThalesError("80", "Data length error"),
                                               New ThalesError("90", "Data parity error"),
                                               New ThalesError("91", "LRC error"),
                                               New ThalesError("92", "Count value not between limits"),
                                               New ThalesError("ZZ", "UNKNOWN ERROR"),
                                               New ThalesError("32", "LIC007 (AES) not installed"),
                                               New ThalesError("39", "Fraud detection"),
                                               New ThalesError("43", "RSA Key Generation Failure"),
                                               New ThalesError("46", "Invalid tag for encrypted PIN"),
                                               New ThalesError("47", "Algorithm not licensed"),
                                               New ThalesError("49", "Private key error, report to supervisor"),
                                               New ThalesError("67", "Command not licensed"),
                                               New ThalesError("68", "Command has been disabled"),
                                               New ThalesError("69", "PIN block format has been disabled"),
                                               New ThalesError("74", "Invalid digest info syntax (no hash mode only)"),
                                               New ThalesError("75", "Single length key masquerading as double or triple length key"),
                                               New ThalesError("76", "RSA public key length error or RSA encrypted data length error"),
                                               New ThalesError("77", "Clear data block error"),
                                               New ThalesError("78", "Private key length error"),
                                               New ThalesError("79", "Hash algorithm object identifier error"),
                                               New ThalesError("81", "Invalid certificate header"),
                                               New ThalesError("82", "Invalid check value length"),
                                               New ThalesError("83", "Key block format error"),
                                               New ThalesError("84", "Key block check value error"),
                                               New ThalesError("85", "Invalid OAEP Mask Generation Function"),
                                               New ThalesError("86", "Invalid OAEP MGF Hash Function"),
                                               New ThalesError("87", "OAEP Parameter Error"),
                                               New ThalesError("A1", "Incompatible LMK schemes"),
                                               New ThalesError("A2", "Incompatible LMK identifiers"),
                                               New ThalesError("A3", "Incompatible key block LMK identifiers"),
                                               New ThalesError("A4", "Key block authentication failure"),
                                               New ThalesError("A5", "Incompatible key length"),
                                               New ThalesError("A6", "Invalid key usage"),
                                               New ThalesError("A7", "Invalid algorithm"),
                                               New ThalesError("A8", "Invalid mode of use"),
                                               New ThalesError("A9", "Invalid key version number"),
                                               New ThalesError("AA", "Invalid export field"),
                                               New ThalesError("AB", "Invalid number of optional blocks"),
                                               New ThalesError("AC", "Optional header block error"),
                                               New ThalesError("AD", "Key status optional block error"),
                                               New ThalesError("AE", "Invalid start date/time"),
                                               New ThalesError("AF", "Invalid end date/time"),
                                               New ThalesError("B0", "Invalid encryption mode"),
                                               New ThalesError("B1", "Invalid authentication mode"),
                                               New ThalesError("B2", "Miscellaneous key block error"),
                                               New ThalesError("B3", "Invalid number of optional blocks"),
                                               New ThalesError("B4", "Optional block data error"),
                                               New ThalesError("B5", "Incompatible components"),
                                               New ThalesError("B6", "Incompatible key status optional blocks"),
                                               New ThalesError("B7", "Invalid change field"),
                                               New ThalesError("B8", "Invalid old value"),
                                               New ThalesError("B9", "Invalid new value"),
                                               New ThalesError("BA", "No key status block in the key block"),
                                               New ThalesError("BB", "Invalid wrapping key"),
                                               New ThalesError("BC", "Repeated optional block"),
                                               New ThalesError("BD", "Incompatible key types"),
                                               New ThalesError("BE", "Invalid key block header ID")}

    ''' <summary>
    ''' Returns error help.
    ''' </summary>
    ''' <remarks>
    ''' This method returns a <see cref="ThalesError"/> object that contains
    ''' help for the specific error code.
    ''' </remarks>
    Public Shared Function GetError(ByVal errorCode As String) As ThalesError
        For i As Integer = 0 To _errors.GetUpperBound(0)
            If _errors(i).ErrorCode = errorCode Then
                Return _errors(i)
            End If
        Next
        Return Nothing
    End Function

End Class