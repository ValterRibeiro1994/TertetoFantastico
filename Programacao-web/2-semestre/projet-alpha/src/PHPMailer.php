<?php

/**
 * PHPMailer - PHP email creation and transport class.
 * PHP Version 5.5.
 *
 * @see https://github.com/PHPMailer/PHPMailer/ The PHPMailer GitHub project
 *
 * @author    Marcus Bointon (Synchro/coolbru) <phpmailer@synchromedia.co.uk>
 * @author    Jim Jagielski (jimjag) <jimjag@gmail.com>
 * @author    Andy Prevost (codeworxtech) <codeworxtech@users.sourceforge.net>
 * @author    Brent R. Matzelle (original founder)
 * @copyright 2012 - 2020 Marcus Bointon
 * @copyright 2010 - 2012 Jim Jagielski
 * @copyright 2004 - 2009 Andy Prevost
 * @license   https://www.gnu.org/licenses/old-licenses/lgpl-2.1.html GNU Lesser General Public License
 * @note      This program is distributed in the hope that it will be useful - WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
 * FITNESS FOR A PARTICULAR PURPOSE.
 */

namespace PHPMailer\PHPMailer;

/**
 * PHPMailer - PHP email creation and transport class.
 *
 * @author Marcus Bointon (Synchro/coolbru) <phpmailer@synchromedia.co.uk>
 * @author Jim Jagielski (jimjag) <jimjag@gmail.com>
 * @author Andy Prevost (codeworxtech) <codeworxtech@users.sourceforge.net>
 * @author Brent R. Matzelle (original founder)
 */
class PHPMailer
{
    const CHARSET_ASCII = 'us-ascii';
    const CHARSET_ISO88591 = 'iso-8859-1';
    const CHARSET_UTF8 = 'utf-8';

    const CONTENT_TYPE_PLAINTEXT = 'text/plain';
    const CONTENT_TYPE_TEXT_CALENDAR = 'text/calendar';
    const CONTENT_TYPE_TEXT_HTML = 'text/html';
    const CONTENT_TYPE_MULTIPART_ALTERNATIVE = 'multipart/alternative';
    const CONTENT_TYPE_MULTIPART_MIXED = 'multipart/mixed';
    const CONTENT_TYPE_MULTIPART_RELATED = 'multipart/related';

    const ENCODING_7BIT = '7bit';
    const ENCODING_8BIT = '8bit';
    const ENCODING_BASE64 = 'base64';
    const ENCODING_BINARY = 'binary';
    const ENCODING_QUOTED_PRINTABLE = 'quoted-printable';

    const ENCRYPTION_STARTTLS = 'tls';
    const ENCRYPTION_SMTPS = 'ssl';

    const ICAL_METHOD_REQUEST = 'REQUEST';
    const ICAL_METHOD_PUBLISH = 'PUBLISH';
    const ICAL_METHOD_REPLY = 'REPLY';
    const ICAL_METHOD_ADD = 'ADD';
    const ICAL_METHOD_CANCEL = 'CANCEL';
    const ICAL_METHOD_REFRESH = 'REFRESH';
    const ICAL_METHOD_COUNTER = 'COUNTER';
    const ICAL_METHOD_DECLINECOUNTER = 'DECLINECOUNTER';
    const RFC822_DATE_FORMAT = 'D, j M Y H:i:s O';

    /**
     * Email priority.
     * Options: null (default), 1 = High, 3 = Normal, 5 = low.
     * When null, the header is not set at all.
     *
     * @var int|null
     */
    public $Priority;

    /**
     * The character set of the message.
     *
     * @var string
     */
    public $CharSet = self::CHARSET_ISO88591;

    /**
     * The MIME Content-Type of the message.
     *
     * @var string
     */
    public $ContentType = self::CONTENT_TYPE_PLAINTEXT;

    /**
     * The message encoding.
     * Options: "8bit", "7bit", "binary", "base64", and "quoted-printable".
     *
     * @var string
     */
    public $Encoding = self::ENCODING_8BIT;

    /**
     * Holds the most recent mailer error message.
     *
     * @var string
     */
    public $ErrorInfo = '';

    /**
     * The From email address for the message.
     *
     * @var string
     */
    public $From = '';

    /**
     * The From name of the message.
     *
     * @var string
     */
    public $FromName = '';

    /**
     * The envelope sender of the message.
     * This will usually be turned into a Return-Path header by the receiver,
     * and is the address that bounces will be sent to.
     * If not empty, will be passed via `-f` to sendmail or as the 'MAIL FROM' value over SMTP.
     *
     * @var string
     */
    public $Sender = '';

    /**
     * The Subject of the message.
     *
     * @var string
     */
    public $Subject = '';

    /**
     * An HTML or plain text message body.
     * If HTML then call isHTML(true).
     *
     * @var string
     */
    public $Body = '';

    /**
     * The plain-text message body.
     * This body can be read by mail clients that do not have HTML email
     * capability such as mutt & Eudora.
     * Clients that can read HTML will view the normal Body.
     *
     * @var string
     */
    public $AltBody = '';

    /**
     * An iCal message part body.
     * Only supported in simple alt or alt_inline message types
     * To generate iCal event structures, use classes like EasyPeasyICS or iCalcreator.
     *
     * @see https://kigkonsult.se/iCalcreator/
     *
     * @var string
     */
    public $Ical = '';

    /**
     * Value-array of "method" in Content-Type header "text/calendar"
     *
     * @var string[]
     */
    protected static $IcalMethods = [
        self::ICAL_METHOD_REQUEST,
        self::ICAL_METHOD_PUBLISH,
        self::ICAL_METHOD_REPLY,
        self::ICAL_METHOD_ADD,
        self::ICAL_METHOD_CANCEL,
        self::ICAL_METHOD_REFRESH,
        self::ICAL_METHOD_COUNTER,
        self::ICAL_METHOD_DECLINECOUNTER,
    ];

    /**
     * The complete compiled MIME message body.
     *
     * @var string
     */
    protected $MIMEBody = '';

    /**
     * The complete compiled MIME message headers.
     *
     * @var string
     */
    protected $MIMEHeader = '';

    /**
     * Extra headers that createHeader() doesn't fold in.
     *
     * @var string
     */
    protected $mailHeader = '';

    /**
     * Word-wrap the message body to this number of chars.
     * Set to 0 to not wrap. A useful value here is 78, for RFC2822 section 2.1.1 compliance.
     *
     * @see static::STD_LINE_LENGTH
     *
     * @var int
     */
    public $WordWrap = 0;

    /**
     * Which method to use to send mail.
     * Options: "mail", "sendmail", or "smtp".
     *
     * @var string
     */
    public $Mailer = 'mail';

    /**
     * The path to the sendmail program.
     *
     * @var string
     */
    public $Sendmail = '/usr/sbin/sendmail';

    /**
     * Whether mail() uses a fully sendmail-compatible MTA.
     * One which supports sendmail's "-oi -f" options.
     *
     * @var bool
     */
    public $UseSendmailOptions = true;

    /**
     * The email address that a reading confirmation should be sent to, also known as read receipt.
     *
     * @var string
     */
    public $ConfirmReadingTo = '';

    /**
     * The hostname to use in the Message-ID header and as default HELO string.
     * If empty, PHPMailer attempts to find one with, in order,
     * $_SERVER['SERVER_NAME'], gethostname(), php_uname('n'), or the value
     * 'localhost.localdomain'.
     *
     * @see PHPMailer::$Helo
     *
     * @var string
     */
    public $Hostname = '';

    /**
     * An ID to be used in the Message-ID header.
     * If empty, a unique id will be generated.
     * You can set your own, but it must be in the format "<id@domain>",
     * as defined in RFC5322 section 3.6.4 or it will be ignored.
     *
     * @see https://www.rfc-editor.org/rfc/rfc5322#section-3.6.4
     *
     * @var string
     */
    public $MessageID = '';

    /**
     * The message Date to be used in the Date header.
     * If empty, the current date will be added.
     *
     * @var string
     */
    public $MessageDate = '';

    /**
     * SMTP hosts.
     * Either a single hostname or multiple semicolon-delimited hostnames.
     * You can also specify a different port
     * for each host by using this format: [hostname:port]
     * (e.g. "smtp1.example.com:25;smtp2.example.com").
     * You can also specify encryption type, for example:
     * (e.g. "tls://smtp1.example.com:587;ssl://smtp2.example.com:465").
     * Hosts will be tried in order.
     *
     * @var string
     */
    public $Host = 'localhost';

    /**
     * The default SMTP server port.
     *
     * @var int
     */
    public $Port = 25;

    /**
     * The SMTP HELO/EHLO name used for the SMTP connection.
     * Default is $Hostname. If $Hostname is empty, PHPMailer attempts to find
     * one with the same method described above for $Hostname.
     *
     * @see PHPMailer::$Hostname
     *
     * @var string
     */
    public $Helo = '';

    /**
     * What kind of encryption to use on the SMTP connection.
     * Options: '', static::ENCRYPTION_STARTTLS, or static::ENCRYPTION_SMTPS.
     *
     * @var string
     */
    public $SMTPSecure = '';

    /**
     * Whether to enable TLS encryption automatically if a server supports it,
     * even if `SMTPSecure` is not set to 'tls'.
     * Be aware that in PHP >= 5.6 this requires that the server's certificates are valid.
     *
     * @var bool
     */
    public $SMTPAutoTLS = true;

    /**
     * Whether to use SMTP authentication.
     * Uses the Username and Password properties.
     *
     * @see PHPMailer::$Username
     * @see PHPMailer::$Password
     *
     * @var bool
     */
    public $SMTPAuth = false;

    /**
     * Options array passed to stream_context_create when connecting via SMTP.
     *
     * @var array
     */
    public $SMTPOptions = [];

    /**
     * SMTP username.
     *
     * @var string
     */
    public $Username = '';

    /**
     * SMTP password.
     *
     * @var string
     */
    public $Password = '';

    /**
     * SMTP authentication type. Options are CRAM-MD5, LOGIN, PLAIN, XOAUTH2.
     * If not specified, the first one from that list that the server supports will be selected.
     *
     * @var string
     */
    public $AuthType = '';

    /**
     * SMTP SMTPXClient command attributes
     *
     * @var array
     */
    protected $SMTPXClient = [];

    /**
     * An implementation of the PHPMailer OAuthTokenProvider interface.
     *
     * @var OAuthTokenProvider
     */
    protected $oauth;

    /**
     * The SMTP server timeout in seconds.
     * Default of 5 minutes (300sec) is from RFC2821 section 4.5.3.2.
     *
     * @var int
     */
    public $Timeout = 300;

    /**
     * Comma separated list of DSN notifications
     * 'NEVER' under no circumstances a DSN must be returned to the sender.
     *         If you use NEVER all other notifications will be ignored.
     * 'SUCCESS' will notify you when your mail has arrived at its destination.
     * 'FAILURE' will arrive if an error occurred during delivery.
     * 'DELAY'   will notify you if there is an unusual delay in delivery, but the actual
     *           delivery's outcome (success or failure) is not yet decided.
     *
     * @see https://www.rfc-editor.org/rfc/rfc3461.html#section-4.1 for more information about NOTIFY
     */
    public $dsn = '';

    /**
     * SMTP class debug output mode.
     * Debug output level.
     * Options:
     * @see SMTP::DEBUG_OFF: No output
     * @see SMTP::DEBUG_CLIENT: Client messages
     * @see SMTP::DEBUG_SERVER: Client and server messages
     * @see SMTP::DEBUG_CONNECTION: As SERVER plus connection status
     * @see SMTP::DEBUG_LOWLEVEL: Noisy, low-level data output, rarely needed
     *
     * @see SMTP::$do_debug
     *
     * @var int
     */
    public $SMTPDebug = 0;

    /**
     * How to handle debug output.
     * Options:
     * * `echo` Output plain-text as-is, appropriate for CLI
     * * `html` Output escaped, line breaks converted to `<br>`, appropriate for browser output
     * * `error_log` Output to error log as configured in php.ini
     * By default PHPMailer will use `echo` if run from a `cli` or `cli-server` SAPI, `html` otherwise.
     * Alternatively, you can provide a callable expecting two params: a message string and the debug level:
     *
     * ```php
     * $mail->Debugoutput = function($str, $level) {echo "debug level $level; message: $str";};
     * ```
     *
     * Alternatively, you can pass in an instance of a PSR-3 compatible logger, though only `debug`
     * level output is used:
     *
     * ```php
     * $mail->Debugoutput = new myPsr3Logger;
     * ```
     *
     * @see SMTP::$Debugoutput
     *
     * @var string|callable|\Psr\Log\LoggerInterface
     */
    public $Debugoutput = 'echo';

    /**
     * Whether to keep the SMTP connection open after each message.
     * If this is set to true then the connection will remain open after a send,
     * and closing the connection will require an explicit call to smtpClose().
     * It's a good idea to use this if you are sending multiple messages as it reduces overhead.
     * See the mailing list example for how to use it.
     *
     * @var bool
     */
    public $SMTPKeepAlive = false;

    /**
     * Whether to split multiple to addresses into multiple messages
     * or send them all in one message.
     * Only supported in `mail` and `sendmail` transports, not in SMTP.
     *
     * @var bool
     *
     * @deprecated 6.0.0 PHPMailer isn't a mailing list manager!
     */
    public $SingleTo = false;

    /**
     * Storage for addresses when SingleTo is enabled.
     *
     * @var array
     */
    protected $SingleToArray = [];

    /**
     * Whether to generate VERP addresses on send.
     * Only applicable when sending via SMTP.
     *
     * @see https://en.wikipedia.org/wiki/Variable_envelope_return_path
     * @see https://www.postfix.org/VERP_README.html Postfix VERP info
     *
     * @var bool
     */
    public $do_verp = false;

    /**
     * Whether to allow sending messages with an empty body.
     *
     * @var bool
     */
    public $AllowEmpty = false;

    /**
     * DKIM selector.
     *
     * @var string
     */
    public $DKIM_selector = '';

    /**
     * DKIM Identity.
     * Usually the email address used as the source of the email.
     *
     * @var string
     */
    public $DKIM_identity = '';

    /**
     * DKIM passphrase.
     * Used if your key is encrypted.
     *
     * @var string
     */
    public $DKIM_passphrase = '';

    /**
     * DKIM signing domain name.
     *
     * @example 'example.com'
     *
     * @var string
     */
    public $DKIM_domain = '';

    /**
     * DKIM Copy header field values for diagnostic use.
     *
     * @var bool
     */
    public $DKIM_copyHeaderFields = true;

    /**
     * DKIM Extra signing headers.
     *
     * @example ['List-Unsubscribe', 'List-Help']
     *
     * @var array
     */
    public $DKIM_extraHeaders = [];

    /**
     * DKIM private key file path.
     *
     * @var string
     */
    public $DKIM_private = '';

    /**
     * DKIM private key string.
     *
     * If set, takes precedence over `$DKIM_private`.
     *
     * @var string
     */
    public $DKIM_private_string = '';

    /**
     * Callback Action function name.
     *
     * The function that handles the result of the send email action.
     * It is called out by send() for each email sent.
     *
     * Value can be any php callable: https://www.php.net/is_callable
     *
     * Parameters:
     *   bool $result           result of the send action
     *   array   $to            email addresses of the recipients
     *   array   $cc            cc email addresses
     *   array   $bcc           bcc email addresses
     *   string  $subject       the subject
     *   string  $body          the email body
     *   string  $from          email address of sender
     *   string  $extra         extra information of possible use
     *                          'smtp_transaction_id' => last smtp transaction id
     *
     * @var callable|callable-string
     */
    public $action_function = '';

    /**
     * What to put in the X-Mailer header.
     * Options: An empty string for PHPMailer default, whitespace/null for none, or a string to use.
     *
     * @var string|null
     */
    public $XMailer = '';

    /**
     * Which validator to use by default when validating email addresses.
     * May be a callable to inject your own validator, but there are several built-in validators.
     * The default validator uses PHP's FILTER_VALIDATE_EMAIL filter_var option.
     *
     * If CharSet is UTF8, the validator is left at the default value,
     * and you send to addresses that use non-ASCII local parts, then
     * PHPMailer automatically changes to the 'eai' validator.
     *
     * @see PHPMailer::validateAddress()
     *
     * @var string|callable
     */
    public static $validator = 'php';

    /**
     * An instance of the SMTP sender class.
     *
     * @var SMTP
     */
    protected $smtp;

    /**
     * The array of 'to' names and addresses.
     *
     * @var array
     */
    protected $to = [];

    /**
     * The array of 'cc' names and addresses.
     *
     * @var array
     */
    protected $cc = [];

    /**
     * The array of 'bcc' names and addresses.
     *
     * @var array
     */
    protected $bcc = [];

    /**
     * The array of reply-to names and addresses.
     *
     * @var array
     */
    protected $ReplyTo = [];

    /**
     * An array of all kinds of addresses.
     * Includes all of $to, $cc, $bcc.
     *
     * @see PHPMailer::$to
     * @see PHPMailer::$cc
     * @see PHPMailer::$bcc
     *
     * @var array
     */
    protected $all_recipients = [];

    /**
     * An array of names and addresses queued for validation.
     * In send(), valid and non duplicate entries are moved to $all_recipients
     * and one of $to, $cc, or $bcc.
     * This array is used only for addresses with IDN.
     *
     * @see PHPMailer::$to
     * @see PHPMailer::$cc
     * @see PHPMailer::$bcc
     * @see PHPMailer::$all_recipients
     *
     * @var array
     */
    protected $RecipientsQueue = [];

    /**
     * An array of reply-to names and addresses queued for validation.
     * In send(), valid and non duplicate entries are moved to $ReplyTo.
     * This array is used only for addresses with IDN.
     *
     * @see PHPMailer::$ReplyTo
     *
     * @var array
     */
    protected $ReplyToQueue = [];

    /**
     * Whether the need for SMTPUTF8 has been detected. Set by
     * preSend() if necessary.
     *
     * @var bool
     */
    public $UseSMTPUTF8 = false;

    /**
     * The array of attachments.
     *
     * @var array
     */
    protected $attachment = [];

    /**
     * The array of custom headers.
     *
     * @var array
     */
    protected $CustomHeader = [];

    /**
     * The most recent Message-ID (including angular brackets).
     *
     * @var string
     */
    protected $lastMessageID = '';

    /**
     * The message's MIME type.
     *
     * @var string
     */
    protected $message_type = '';

    /**
     * The array of MIME boundary strings.
     *
     * @var array
     */
    protected $boundary = [];

    /**
     * The array of available text strings for the current language.
     *
     * @var array
     */
    protected static $language = [];

    /**
     * The number of errors encountered.
     *
     * @var int
     */
    protected $error_count = 0;

    /**
     * The S/MIME certificate file path.
     *
     * @var string
     */
    protected $sign_cert_file = '';

    /**
     * The S/MIME key file path.
     *
     * @var string
     */
    protected $sign_key_file = '';

    /**
     * The optional S/MIME extra certificates ("CA Chain") file path.
     *
     * @var string
     */
    protected $sign_extracerts_file = '';

    /**
     * The S/MIME password for the key.
     * Used only if the key is encrypted.
     *
     * @var string
     */
    protected $sign_key_pass = '';

    /**
     * Whether to throw exceptions for errors.
     *
     * @var bool
     */
    protected $exceptions = false;

    /**
     * Unique ID used for message ID and boundaries.
     *
     * @var string
     */
    protected $uniqueid = '';

    /**
     * The PHPMailer Version number.
     *
     * @var string
     */
    const VERSION = '7.1.1';

    /**
     * Error severity: message only, continue processing.
     *
     * @var int
     */
    const STOP_MESSAGE = 0;

    /**
     * Error severity: message, likely ok to continue processing.
     *
     * @var int
     */
    const STOP_CONTINUE = 1;

    /**
     * Error severity: message, plus full stop, critical error reached.
     *
     * @var int
     */
    const STOP_CRITICAL = 2;

    /**
     * The SMTP standard CRLF line break.
     * If you want to change line break format, change static::$LE, not this.
     */
    const CRLF = "\r\n";

    /**
     * "Folding White Space" a white space string used for line folding.
     */
    const FWS = ' ';

    /**
     * SMTP RFC standard line ending; Carriage Return, Line Feed.
     *
     * @var string
     */
    protected static $LE = self::CRLF;

    /**
     * The maximum line length supported by mail().
     *
     * Background: mail() will sometimes corrupt messages
     * with headers longer than 65 chars, see #818.
     *
     * @var int
     */
    const MAIL_MAX_LINE_LENGTH = 63;

    /**
     * The maximum line length allowed by RFC 2822 section 2.1.1.
     *
     * @var int
     */
    const MAX_LINE_LENGTH = 998;

    /**
     * The lower maximum line length allowed by RFC 2822 section 2.1.1.
     * This length does NOT include the line break
     * 76 means that lines will be 77 or 78 chars depending on whether
     * the line break format is LF or CRLF; both are valid.
     *
     * @var int
     */
    const STD_LINE_LENGTH = 76;

    /**
     * Constructor.
     *
     * @param bool $exceptions Should we throw external exceptions?
     */
    public function __construct($exceptions = null)
    {
        if (null !== $exceptions) {
            $this->exceptions = (bool) $exceptions;
        }
        //Pick an appropriate debug output format automatically
        $this->Debugoutput = (strpos(PHP_SAPI, 'cli') !== false ? 'echo' : 'html');
    }

    /**
     * Destructor.
     */
    public function __destruct()
    {
        //Close any open SMTP connection nicely
        $this->smtpClose();
    }

    /**
     * Call mail() in a safe_mode-aware fashion.
     * Also, unless sendmail_path points to sendmail (or something that
     * claims to be sendmail), don't pass params (not a perfect fix,
     * but it will do).
     *
     * @param string      $to      To
     * @param string      $subject Subject
     * @param string      $body    Message Body
     * @param string      $header  Additional Header(s)
     * @param string|null $params  Params
     *
     * @return bool
     */
    private function mailPassthru($to, $subject, $body, $header, $params)
    {
        //Check overloading of mail function to avoid double-encoding
        // phpcs:ignore PHPCompatibility.IniDirectives.RemovedIniDirectives.mbstring_func_overloadDeprecatedRemoved
        if ((int)ini_get('mbstring.func_overload') & 1) {
            $subject = $this->secureHeader($subject);
        } else {
            $subject = $this->encodeHeader($this->secureHeader($subject));
        }
        //Calling mail() with null params breaks
        $this->edebug('Sending with mail()');
        $this->edebug('Sendmail path: ' . ini_get('sendmail_path'));
        $this->edebug("Envelope sender: {$this->Sender}");
        $this->edebug("To: {$to}");
        $this->edebug("Subject: {$subject}");
        $this->edebug("Headers: {$header}");
        if (!$this->UseSendmailOptions || null === $params) {
            $result = @mail($to, $subject, $body, $header);
        } else {
            $this->edebug("Additional params: {$params}");
            $result = @mail($to, $subject, $body, $header, $params);
        }
        $this->edebug('Result: ' . ($result ? 'true' : 'false'));
        return $result;
    }

    /**
     * Output debugging info via a user-defined method.
     * Only generates output if debug output is enabled.
     *
     * @see PHPMailer::$Debugoutput
     * @see PHPMailer::$SMTPDebug
     *
     * @param string $str
     */
    protected function edebug($str)
    {
        if ($this->SMTPDebug <= 0) {
            return;
        }
        //Is this a PSR-3 logger?
        if ($this->Debugoutput instanceof \Psr\Log\LoggerInterface) {
            $this->Debugoutput->debug(rtrim($str, "\r\n"));

            return;
        }
        //Avoid clash with built-in function names
        if (is_callable($this->Debugoutput) && !in_array($this->Debugoutput, ['error_log', 'html', 'echo'])) {
            call_user_func($this->Debugoutput, $str, $this->SMTPDebug);

            return;
        }
        switch ($this->Debugoutput) {
            case 'error_log':
                //Don't output, just log
                /** @noinspection ForgottenDebugOutputInspection */
                error_log($str);
                break;
            case 'html':
                //Cleans up output a bit for a better looking, HTML-safe output
                echo htmlentities(
                    preg_replace('/[\r\n]+/', '', $str),
                    ENT_QUOTES,
                    'UTF-8'
                ), "<br>\n";
                break;
            case 'echo':
            default:
                //Normalize line breaks
                $str = preg_replace('/\r\n|\r/m', "\n", $str);
                echo gmdate('Y-m-d H:i:s'),
                "\t",
                    //Trim trailing space
                trim(
                    //Indent for readability, except for trailing break
                    str_replace(
                        "\n",
                        "\n                   \t                  ",
                        trim($str)
                    )
                ),
                "\n";
        }
    }

    /**
     * Sets message type to HTML or plain.
     *
     * @param bool $isHtml True for HTML mode
     */
    public function isHTML($isHtml = true)
    {
        if ($isHtml) {
            $this->ContentType = static::CONTENT_TYPE_TEXT_HTML;
        } else {
            $this->ContentType = static::CONTENT_TYPE_PLAINTEXT;
        }
    }

    /**
     * Send messages using SMTP.
     */
    public function isSMTP()
    {
        $this->Mailer = 'smtp';
    }

    /**
     * Send messages using PHP's mail() function.
     */
    public function isMail()
    {
        $this->Mailer = 'mail';
    }

    /**
     * Extract sendmail path and parse to deal with known parameters.
     *
     * @param string $sendmailPath The sendmail path as set in php.ini
     *
     * @return string The sendmail path without the known parameters
     */
    private function parseSendmailPath($sendmailPath)
    {
        $sendmailPath = trim((string)$sendmailPath);
        if ($sendmailPath === '') {
            return $sendmailPath;
        }

        $parts = preg_split('/\s+/', $sendmailPath);
        if (empty($parts)) {
            return $sendmailPath;
        }

        $command = array_shift($parts);
        $remainder = [];

        // Parse only -t, -i, -oi and -f parameters.
        for ($i = 0; $i < count($parts); ++$i) {
            $part = $parts[$i];
            if (preg_match('/^-(i|oi|t)$/', $part, $matches)) {
                continue;
            }
            if (preg_match('/^-f(.*)$/', $part, $matches)) {
                $address = $matches[1];
                if ($address === '' && isset($parts[$i + 1]) && strpos($parts[$i + 1], '-') !== 0) {
                    $address = $parts[++$i];
                }
                $this->Sender = $address;
                continue;
            }

            $remainder[] = $part;
        }

        // The params that are not parsed are added back to the command.
        if (!empty($remainder)) {
            $command .= ' ' . implode(' ', $remainder);
        }

        return $command;
    }

    /**
     * Send messages using $Sendmail.
     */
    public function isSendmail()
    {
        $ini_sendmail_path = ini_get('sendmail_path');

        if (false === stripos($ini_sendmail_path, 'sendmail')) {
            $ini_sendmail_path = '/usr/sbin/sendmail';
        }
        $this->Sendmail = $this->parseSendmailPath($ini_sendmail_path);
        $this->Mailer = 'sendmail';
    }

    /**
     * Send messages using qmail.
     */
    public function isQmail()
    {
        $ini_sendmail_path = ini_get('sendmail_path');

        if (false === stripos($ini_sendmail_path, 'qmail')) {
            $ini_sendmail_path = '/var/qmail/bin/qmail-inject';
        }
        $this->Sendmail = $this->parseSendmailPath($ini_sendmail_path);
        $this->Mailer = 'qmail';
    }

    /**
     * Add a "To" address.
     *
     * @param string $address The email address to send to
     * @param string $name
     *
     * @throws Exception
     *
     * @return bool true on success, false if address already used or invalid in some way
     */
    public function addAddress($address, $name = '')
    {
        return $this->addOrEnqueueAnAddress('to', $address, $name);
    }

    /**
     * Add a "CC" address.
     *
     * @param string $address The email address to send to
     * @param string $name
     *
     * @throws Exception
     *
     * @return bool true on success, false if address already used or invalid in some way
     */
    public function addCC($address, $name = '')
    {
        return $this->addOrEnqueueAnAddress('cc', $address, $name);
    }

    /**
     * Add a "BCC" address.
     *
     * @param string $address The email address to send to
     * @param string $name
     *
     * @throws Exception
     *
     * @return bool true on success, false if address already used or invalid in some way
     */
    public function addBCC($address, $name = '')
    {
        return $this->addOrEnqueueAnAddress('bcc', $address, $name);
    }

    /**
     * Add a "Reply-To" address.
     *
     * @param string $address The email address to reply to
     * @param string $name
     *
     * @throws Exception
     *
     * @return bool true on success, false if address already used or invalid in some way
     */
    public function addReplyTo($address, $name = '')
    {
        return $this->addOrEnqueueAnAddress('Reply-To', $address, $name);
    }

    /**
     * Add an address to one of the recipient arrays or to the ReplyTo array. Because PHPMailer
     * can't validate addresses with an IDN without knowing the PHPMailer::$CharSet (that can still
     * be modified after calling this function), addition of such addresses is delayed until send().
     * Addresses that have been added already return false, but do not throw exceptions.
     *
     * @param string $kind    One of 'to', 'cc', 'bcc', or 'Reply-To'
     * @param string $address The email address
     * @param string $name    An optional username associated with the address
     *
     * @throws Exception
     *
     * @return bool true on success, false if address already used or invalid in some way
     */
    protected function addOrEnqueueAnAddress($kind, $address, $name)
    {
        $pos = false;
        if ($address !== null) {
            $address = trim($address);
            $pos = strrpos($address, '@');
        }
        if (false === $pos) {
            //At-sign is missing.
            $error_message = sprintf(
                '%s (%s): %s',
                self::lang('invalid_address'),
                $kind,
                $address
            );
            $this->setError($error_message);
            $this->edebug($error_message);
            if ($this->exceptions) {
                throw new Exception($error_message);
            }

            return false;
        }
        if ($name !== null && is_string($name)) {
            $name = trim(preg_replace('/[\r\n]+/', '', $name)); //Strip breaks and trim
        } else {
            $name = '';
        }
        $params = [$kind, $address, $name];
        //Enqueue addresses with IDN until we know the PHPMailer::$CharSet.
        //Domain is assumed to be whatever is after the last @ symbol in the address
        if ($this->has8bitChars(substr($address, ++$pos))) {
            if (static::idnSupported()) {
                if ('Reply-To' !== $kind) {
                    if (!array_key_exists($address, $this->RecipientsQueue)) {
                        $this->RecipientsQueue[$address] = $params;

                        return true;
                    }
                } elseif (!array_key_exists($address, $this->ReplyToQueue)) {
                    $this->ReplyToQueue[$address] = $params;

                    return true;
                }
            }
            //We have an 8-bit domain, but we are missing the necessary extensions to support it
            //Or we are already sending to this address
            return false;
        }

        //Immediately add standard addresses without IDN.
        return call_user_func_array([$this, 'addAnAddress'], $params);
    }

    /**
     * Set the boundaries to use for delimiting MIME parts.
     * If you override this, ensure you set all 3 boundaries to unique values.
     * The default boundaries include a "=_" sequence which cannot occur in quoted-printable bodies,
     * as suggested by https://www.rfc-editor.org/rfc/rfc2045#section-6.7
     *
     * @return void
     */
    public function setBoundaries()
    {
        $this->uniqueid = $this->generateId();
        $this->boundary[1] = 'b1=_' . $this->uniqueid;
        $this->boundary[2] = 'b2=_' . $this->uniqueid;
        $this->boundary[3] = 'b3=_' . $this->uniqueid;
    }

    /**
     * Add an address to one of the recipient arrays or to the ReplyTo array.
     * Addresses that have been added already return false, but do not throw exceptions.
     *
     * @param string $kind    One of 'to', 'cc', 'bcc', or 'ReplyTo'
     * @param string $address The email address to send, resp. to reply to
     * @param string $name
     *
     * @throws Exception
     *
     * @return bool true on success, false if address already used or invalid in some way
     */
    protected function addAnAddress($kind, $address, $name = '')
    {
        if (
            self::$validator === 'php' &&
            ((bool) preg_match('/[\x80-\xFF]/', $address))
        ) {
            //The caller has not altered the validator and is sending to an address
            //with UTF-8, so assume that they want UTF-8 support instead of failing
            $this->CharSet = self::CHARSET_UTF8;
            self::$validator = 'eai';
        }
        if (!in_array($kind, ['to', 'cc', 'bcc', 'Reply-To'])) {
            $error_message = sprintf(
                '%s: %s',
                self::lang('Invalid recipient kind'),
                $kind
            );
            $this->setError($error_message);
            $this->edebug($error_message);
            if ($this->exceptions) {
                throw new Exception($error_message);
            }

            return false;
        }
        if (!static::validateAddress($address)) {
            $error_message = sprintf(
                '%s (%s): %s',
                self::lang('invalid_address'),
                $kind,
                $address
            );
            $this->setError($error_message);
            $this->edebug($error_message);
            if ($this->exceptions) {
                throw new Exception($error_message);
            }

            return false;
        }
        if ('Reply-To' !== $kind) {
            if (!array_key_exists(strtolower($address), $this->all_recipients)) {
                $this->{$kind}[] = [$address, $name];
                $this->all_recipients[strtolower($address)] = true;

                return true;
            }
        } else {
            foreach ($this->ReplyTo as $replyTo) {
                if (0 === strcasecmp($replyTo[0], $address)) {
                    return false;
                }
            }
            $this->ReplyTo[] = [$address, $name];

            return true;
        }
        return false;
    }

    /**
     * Parse and validate a string containing one or more RFC822-style comma-separated email addresses
     * of the form "display name <address>" into an array of name/address pairs.
     * Uses the imap_rfc822_parse_adrlist function if the IMAP extension is available and
     * the deprecated $useimap argument is truthy.
     * Note that quotes in the name part are removed.
     *
     * @see https://www.andrew.cmu.edu/user/agreen1/testing/mrbs/web/Mail/RFC822.php A more careful implementation
     *
     * @param string $addrstr The address list string
     * @param bool|null $useimap Deprecated in PHPMailer 6.11.0.
     *                           Truthy values request the deprecated IMAP parser
     *                           and trigger a deprecation warning.
     * @param string $charset The charset to use when decoding the address list string.
     *
     * @return array
     */
    public static function parseAddresses($addrstr, $useimap = null, $charset = self::CHARSET_ISO88591)
    {
        if ($useimap == true) {
            trigger_error(self::lang('deprecated_argument') . '$useimap', E_USER_DEPRECATED);
        }
        $addresses = [];
        if ($useimap == true && function_exists('imap_rfc822_parse_adrlist')) {
            //Use this built-in parser if it's available
            // phpcs:ignore PHPCompatibility.FunctionUse.RemovedFunctions.imap_rfc822_parse_adrlistRemoved -- wrapped in function_exists()
            $list = imap_rfc822_parse_adrlist($addrstr, '');
            // Clear any potential IMAP errors to get rid of notices being thrown at end of script.
            // phpcs:ignore PHPCompatibility.FunctionUse.RemovedFunctions.imap_errorsRemoved -- wrapped in function_exists()
            imap_errors();
            foreach ($list as $address) {
                if (
                    '.SYNTAX-ERROR.' !== $address->host &&
                    static::validateAddress($address->mailbox . '@' . $address->host)
                ) {
                    //Decode the name part if it's present and maybe encoded
                    if (
                        property_exists($address, 'personal')
                        && is_string($address->personal)
                        && $address->personal !== ''
                    ) {
                        $address->personal = static::decodeHeader($address->personal, $charset);
                    }

                    $addresses[] = [
                        'name' => (property_exists($address, 'personal') ? $address->personal : ''),
                        'address' => $address->mailbox . '@' . $address->host,
                    ];
                }
            }
        } else {
            //Use this simpler parser
            $addresses = static::parseSimplerAddresses($addrstr, $charset);
        }

        return $addresses;
    }

    /**
     * Parse a string containing one or more RFC822-style comma-separated email addresses
     * with the form "display name <address>" into an array of name/address pairs.
     * Uses a simpler parser that does not require the IMAP extension but doesnt support
     * the full RFC822 spec. For full RFC822 support, use the PHP IMAP extension.
     *
     * @param string $addrstr The address list string
     * @param string $charset The charset to use when decoding the address list string.
     *
     * @return array
     */
    protected static function parseSimplerAddresses($addrstr, $charset)
    {
        // Emit a runtime notice to recommend using the IMAP extension for full RFC822 parsing
        trigger_error(self::lang('imap_recommended'), E_USER_NOTICE);

        $addresses = [];
        $list = explode(',', $addrstr);
        foreach ($list as $address) {
            $address = trim($address);
            //Is there a separate name part?
            if (strpos($address, '<') === false) {
                //No separate name, just use the whole thing
                if (static::validateAddress($address)) {
                    $addresses[] = [
                        'name' => '',
                        'address' => $address,
                    ];
                }
            } else {
                $parsed = static::parseEmailString($address);
                $email = $parsed['email'];
                if (static::validateAddress($email)) {
                    $name = static::decodeHeader($parsed['name'], $charset);
                    $addresses[] = [
                        //Remove any surrounding quotes and spaces from the name
                        'name' => trim($name, '\'" '),
                        'address' => $email,
                    ];
                }
            }
        }

        return $addresses;
    }

    /**
     * Parse a string containing an email address with an optional name
     * and divide it into a name and email address.
     *
     * @param string $input The email with name.
     *
     * @return array{name: string, email: string}
     */
    private static function parseEmailString($input)
    {
        $input = trim((string)$input);

        if ($input === '') {
            return ['name' => '', 'email' => ''];
        }

        $pattern = '/^\s*(?:(?:"([^"]*)"|\'([^\']*)\'|([^<]*?))\s*)?<\s*([^>]+)\s*>\s*$/';
        if (preg_match($pattern, $input, $matches)) {
            $name = '';
            // Double quotes including special scenarios.
            if (isset($matches[1]) && $matches[1] !== '') {
                $name = $matches[1];
            // Single quotes including special scenarios.
            } elseif (isset($matches[2]) && $matches[2] !== '') {
                $name = $matches[2];
            // Simplest scenario, name and email are in the format "Name <email>".
            } elseif (isset($matches[3])) {
                $name = trim($matches[3]);
            }

            return ['name' => $name, 'email' => trim($matches[4])];
        }

        return ['name' => '', 'email' => $input];
    }

    /**
     * Set the From and FromName properties.
     *
     * @param string $address
     * @param string $name
     * @param bool   $auto    Whether to also set the Sender address, defaults to true
     *
     * @throws Exception
     *
     * @return bool
     */
    public function setFrom($address, $name = '', $auto = true)
    {
        if (is_null($name)) {
            //Helps avoid a deprecation warning in the preg_replace() below
            $name = '';
        }
        $address = trim((string)$address);
        $name = trim(preg_replace('/[\r\n]+/', '', $name)); //Strip breaks and trim
        //Don't validate now addresses with IDN. Will be done in send().
        $pos = strrpos($address, '@');
        if (
            (false === $pos)
            || ((!$this->has8bitChars(substr($address, ++$pos)) || !static::idnSupported())
            && !static::validateAddress($address))
        ) {
            $error_message = sprintf(
                '%s (From): %s',
                self::lang('invalid_address'),
                $address
            );
            $this->setError($error_message);
            $this->edebug($error_message);
            if ($this->exceptions) {
                throw new Exception($error_message);
            }

            return false;
        }
        $this->From = $address;
        $this->FromName = $name;
        if ($auto && empty($this->Sender)) {
            $this->Sender = $address;
        }

        return true;
    }

    /**
     * Return the Message-ID header of the last email.
     * Technically this is the value from the last time the headers were created,
     * but it's also the message ID of the last sent message except in
     * pathological cases.
     *
     * @return string
     */
    public function getLastMessageID()
    {
        return $this->lastMessageID;
    }

    /**
     * Check that a string looks like an email address.
     * Validation patterns supported:
     * * `auto` Pick best pattern automatically;
     * * `pcre8` Use the squiloople.com pattern, requires PCRE > 8.0;
     * * `pcre` Use old PCRE implementation;
     * * `php` Use PHP built-in FILTER_VALIDATE_EMAIL;
     * * `html5` Use the pattern given by the HTML5 spec for 'email' type form input elements.
     * * `eai` Use a pattern similar to the HTML5 spec for 'email' and to firefox, extended to support EAI (RFC6530).
     * * `noregex` Don't use a regex: super fast, really dumb.
     * Alternatively you may pass in a callable to inject your own validator, for example:
     *
     * ```php
     * PHPMailer::validateAddress('user@example.com', function($address) {
     *     return (strpos($address, '@') !== false);
     * });
     * ```
     *
     * You can also set the PHPMailer::$validator static to a callable, allowing built-in methods to use your validator.
     *
     * @param string          $address       The email address to check
     * @param string|callable $patternselect Which pattern to use
     *
     * @return bool
     */
    public static function validateAddress($address, $patternselect = null)
    {
        if (null === $patternselect) {
            $patternselect = static::$validator;
        }
        //Don't allow strings as callables, see SECURITY.md and CVE-2021-3603
        if (is_callable($patternselect) && !is_string($patternselect)) {
            return call_user_func($patternselect, $address);
        }
        //Reject line breaks in addresses; it's valid RFC5322, but not RFC5321
        if (strpos($address, "\n") !== false || strpos($address, "\r") !== false) {
            return false;
        }
        switch ($patternselect) {
            case 'pcre': //Kept for BC
            case 'pcre8':
                /*
                 * A more complex and more permissive version of the RFC5322 regex on which FILTER_VALIDATE_EMAIL
                 * is based.
                 * In addition to the addresses allowed by filter_var, also permits:
                 *  * dotless domains: `a@b`
                 *  * comments: `1234 @ local(blah) .machine .example`
                 *  * quoted elements: `'"test blah"@example.org'`
                 *  * numeric TLDs: `a@b.123`
                 *  * unbracketed IPv4 literals: `a@192.168.0.1`
                 *  * IPv6 literals: 'first.last@[IPv6:a1::]'
                 * Not all of these will necessarily work for sending!
                 *
                 * @copyright 2009-2010 Michael Rushton
                 * Feel free to use and redistribute this code. But please keep this copyright notice.
                 */
                return (bool) preg_match(
                    '/^(?!(?>(?1)"?(?>\\\[ -~]|[^"])"?(?1)){255,})(?!(?>(?1)"?(?>\\\[ -~]|[^"])"?(?1)){65,}@)' .
                    '((?>(?>(?>((?>(?>(?>\x0D\x0A)?[\t ])+|(?>[\t ]*\x0D\x0A)?[\t ]+)?)(\((?>(?2)' .
                    '(?>[\x01-\x08\x0B\x0C\x0E-\'*-\[\]-\x7F]|\\\[\x00-\x7F]|(?3)))*(?2)\)))+(?2))|(?2))?)' .
                    '([!#-\'*+\/-9=?^-~-]+|"(?>(?2)(?>[\x01-\x08\x0B\x0C\x0E-!#-\[\]-\x7F]|\\\[\x00-\x7F]))*' .
                    '(?2)")(?>(?1)\.(?1)(?4))*(?1)@(?!(?1)[a-z0-9-]{64,})(?1)(?>([a-z0-9](?>[a-z0-9-]*[a-z0-9])?)' .
                    '(?>(?1)\.(?!(?1)[a-z0-9-]{64,})(?1)(?5)){0,126}|\[(?:(?>IPv6:(?>([a-f0-9]{1,4})(?>:(?6)){7}' .
                    '|(?!(?:.*[a-f0-9][:\]]){8,})((?6)(?>:(?6)){0,6})?::(?7)?))|(?>(?>IPv6:(?>(?6)(?>:(?6)){5}:' .
                    '|(?!(?:.*[a-f0-9]:){6,})(?8)?::(?>((?6)(?>:(?6)){0,4}):)?))?(25[0-5]|2[0-4][0-9]|1[0-9]{2}' .
                    '|[1-9]?[0-9])(?>\.(?9)){3}))\])(?1)$/isD',
                    $address
                );
            case 'html5':
                /*
                 * This is the pattern used in the HTML5 spec for validation of 'email' type form input elements.
                 *
                 * @see https://html.spec.whatwg.org/#e-mail-state-(type=email)
                 */
                return (bool) preg_match(
                    '/^[a-zA-Z0-9.!#$%&\'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}' .
                    '[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/sD',
                    $address
                );
            case 'eai':
                /*
                 * This is the pattern used in the HTML5 spec for validation of 'email' type
                 * form input elements (as above), modified to accept Unicode email addresses.
                 * This is also more lenient than Firefox' html5 spec, in order to make the regex faster.
                 * 'eai' is an acronym for Email Address Internationalization.
                 * This validator is selected automatically if you attempt to use recipient addresses
                 * that contain Unicode characters in the local part.
                 *
                 * @see https://html.spec.whatwg.org/#e-mail-state-(type=email)
                 * @see https://en.wikipedia.org/wiki/International_email
                 */
                return (bool) preg_match(
                    '/^[-\p{L}\p{N}\p{M}.!#$%&\'*+\/=?^_`{|}~]+@[\p{L}\p{N}\p{M}](?:[\p{L}\p{N}\p{M}-]{0,61}' .
                    '[\p{L}\p{N}\p{M}])?(?:\.[\p{L}\p{N}\p{M}]' .
                    '(?:[-\p{L}\p{N}\p{M}]{0,61}[\p{L}\p{N}\p{M}])?)*$/usD',
                    $address
                );
            case 'php':
            default:
                return filter_var($address, FILTER_VALIDATE_EMAIL) !== false;
        }
    }

    /**
     * Tells whether IDNs (Internationalized Domain Names) are supported or not. This requires the
     * `intl` and `mbstring` PHP extensions.
     *
     * @return bool `true` if required functions for IDN support are present
     */
    public static function idnSupported()
    {
        return function_exists('idn_to_ascii') && function_exists('mb_convert_encoding');
    }

    /**
     * Converts IDN in given email address to its ASCII form, also known as punycode, if possible.
     * Important: Address must be passed in same encoding as currently set in PHPMailer::$CharSet.
     * This function silently returns unmodified address if:
     * - No conversion is necessary (i.e. domain name is not an IDN, or is already in ASCII form)
     * - Conversion to punycode is impossible (e.g. required PHP functions are not available)
     *   or fails for any reason (e.g. domain contains characters not allowed in an IDN).
     *
     * @see PHPMailer::$CharSet
     *
     * @param string $address The email address to convert
     *
     * @return string The encoded address in ASCII form
     */
    public function punyencodeAddress($address)
    {
        //Verify we have required functions, CharSet, and at-sign.
        $pos = strrpos($address, '@');
        if (
            !empty($this->CharSet) &&
            false !== $pos &&
            static::idnSupported()
        ) {
            $domain = substr($address, ++$pos);
            //Verify CharSet string is a valid one, and domain properly encoded in this CharSet.
            if ($this->has8bitChars($domain) && @mb_check_encoding($domain, $this->CharSet)) {
                //Convert the domain from whatever charset it's in to UTF-8
                $domain = mb_convert_encoding($domain, self::CHARSET_UTF8, $this->CharSet);
                //Ignore IDE complaints about this line - method signature changed in PHP 5.4
                $errorcode = 0;
                if (defined('INTL_IDNA_VARIANT_UTS46')) {
                    //Use the current punycode standard (appeared in PHP 7.2)
                    $punycode = idn_to_ascii(
                        $domain,
                        \IDNA_DEFAULT | \IDNA_USE_STD3_RULES | \IDNA_CHECK_BIDI |
                            \IDNA_CHECK_CONTEXTJ | \IDNA_NONTRANSITIONAL_TO_ASCII,
                        \INTL_IDNA_VARIANT_UTS46
                    );
                } elseif (defined('INTL_IDNA_VARIANT_2003')) {
                    //Fall back to this old, deprecated/removed encoding
                    // phpcs:ignore PHPCompatibility.Constants.RemovedConstants.intl_idna_variant_2003DeprecatedRemoved
                    $punycode = idn_to_ascii($domain, $errorcode, \INTL_IDNA_VARIANT_2003);
                } else {
                    //Fall back to a default we don't know about
                    // phpcs:ignore PHPCompatibility.ParameterValues.NewIDNVariantDefault.NotSet
                    $punycode = idn_to_ascii($domain, $errorcode);
                }
                if (false !== $punycode) {
                    return substr($address, 0, $pos) . $punycode;
                }
            }
        }

        return $address;
    }

    /**
     * Create a message and send it.
     * Uses the sending method specified by $Mailer.
     *
     * @throws Exception
     *
     * @return bool false on error - See the ErrorInfo property for details of the error
     */
    public function send()
    {
        try {
            if (!$this->preSend()) {
                return false;
            }

            return $this->postSend();
        } catch (Exception $exc) {
            $this->mailHeader = '';
            $this->setError($exc->getMessage());
            if ($this->exceptions) {
                throw $exc;
            }

            return false;
        }
    }

    /**
     * Prepare a message for sending.
     *
     * @throws Exception
     *
     * @return bool
     */
    public function preSend()
    {
        if (
            'smtp' === $this->Mailer
            || ('mail' === $this->Mailer && (\PHP_VERSION_ID >= 80000 || stripos(PHP_OS, 'WIN') === 0))
        ) {
            //SMTP mandates RFC-compliant line endings
            //and it's also used with mail() on Windows
            static::setLE(self::CRLF);
        } else {
            //Maintain backward compatibility with legacy Linux command line mailers
            static::setLE(PHP_EOL);
        }
        //Check for buggy PHP versions that add a header with an incorrect line break
        if (
            'mail' === $this->Mailer
            && ((\PHP_VERSION_ID >= 70000 && \PHP_VERSION_ID < 70017)
                || (\PHP_VERSION_ID >= 70100 && \PHP_VERSION_ID < 70103))
            && ini_get('mail.add_x_header') === '1'
            && stripos(PHP_OS, 'WIN') === 0
        ) {
            trigger_error(self::lang('buggy_php'), E_USER_WARNING);
        }

        try {
            $this->error_count = 0; //Reset errors
            $this->mailHeader = '';

            //The code below tries to support full use of Unicode,
            //while remaining compatible with legacy SMTP servers to
            //the greatest degree possible: If the message uses
            //Unicode in the local parts of any addresses, it is sent
            //using SMTPUTF8. If not, it it sent using
            //punycode-encoded domains and plain SMTP.
            if (
                static::CHARSET_UTF8 === strtolower($this->CharSet) &&
                ($this->anyAddressHasUnicodeLocalPart($this->RecipientsQueue) ||
                 $this->anyAddressHasUnicodeLocalPart(array_keys($this->all_recipients)) ||
                 $this->anyAddressHasUnicodeLocalPart($this->ReplyToQueue) ||
                 $this->addressHasUnicodeLocalPart($this->From))
            ) {
                $this->UseSMTPUTF8 = true;
            }
            //Dequeue recipient and Reply-To addresses with IDN
            foreach (array_merge($this->RecipientsQueue, $this->ReplyToQueue) as $params) {
                if (!$this->UseSMTPUTF8) {
                    $params[1] = $this->punyencodeAddress($params[1]);
                }
                call_user_func_array([$this, 'addAnAddress'], $params);
            }
            if (count($this->to) + count($this->cc) + count($this->bcc) < 1) {
                throw new Exception(self::lang('provide_address'), self::STOP_CRITICAL);
            }

            //Validate From, Sender, and ConfirmReadingTo addresses
            foreach (['From', 'Sender', 'ConfirmReadingTo'] as $address_kind) {
                if ($this->{$address_kind} === null) {
                    $this->{$address_kind} = '';
                    continue;
                }
                $this->{$address_kind} = trim($this->{$address_kind});
                if (empty($this->{$address_kind})) {
                    continue;
                }
                $this->{$address_kind} = $this->punyencodeAddress($this->{$address_kind});
                if (!static::validateAddress($this->{$address_kind})) {
                    $error_message = sprintf(
                        '%s (%s): %s',
                        self::lang('invalid_address'),
                        $address_kind,
                        $this->{$address_kind}
                    );
                    $this->setError($error_message);
                    $this->edebug($error_message);
                    if ($this->exceptions) {
                        throw new Exception($error_message);
                    }

                    return false;
                }
            }

            //Set whether the message is multipart/alternative
            if ($this->alternativeExists()) {
                $this->ContentType = static::CONTENT_TYPE_MULTIPART_ALTERNATIVE;
            }

            $this->setMessageType();
            //Refuse to send an empty message unless we are specifically allowing it
            if (!$this->AllowEmpty && empty($this->Body)) {
                throw new Exception(self::lang('empty_message'), self::STOP_CRITICAL);
            }

            //Trim subject consistently
            $this->Subject = trim($this->Subject);


            //Create body before headers in case body makes changes to headers (e.g. altering transfer encoding)
            $this->MIMEHeader = '';
            $this->MIMEBody = $this->createBody();
            //createBody may have added some headers, so retain them
            $tempheaders = $this->MIMEHeader;
            $this->MIMEHeader = $this->createHeader();
            $this->MIMEHeader .= $tempheaders;

            //To capture the complete message when using mail(), create
            //an extra header list which createHeader() doesn't fold in
            if ('mail' === $this->Mailer) {
                if (count($this->to) > 0) {
                    $this->mailHeader .= $this->addrAppend('To', $this->to);
                } else {
                    $this->mailHeader .= $this->headerLine('To', 'undisclosed-recipients:;');
                }
                $this->mailHeader .= $this->headerLine(
                    'Subject',
                    $this->encodeHeader($this->secureHeader($this->Subject))
                );
            }

            //Sign with DKIM if enabled
            if (
                !empty($this->DKIM_domain)
                && !empty($this->DKIM_selector)
                && (!empty($this->DKIM_private_string)
                    || (!empty($this->DKIM_private)
                        && static::isPermittedPath($this->DKIM_private)
                        && file_exists($this->DKIM_private)
                    )
                )
            ) {
                $header_dkim = $this->DKIM_Add(
                    $this->MIMEHeader . $this->mailHeader,
                    $this->encodeHeader($this->secureHeader($this->Subject)),
                    $this->MIMEBody
                );
                $this->MIMEHeader = static::stripTrailingWSP($this->MIMEHeader) . static::$LE .
                    static::normalizeBreaks($header_dkim) . static::$LE;
            }

            return true;
        } catch (Exception $exc) {
            $this->setError($exc->getMessage());
            if ($this->exceptions) {
                throw $exc;
            }

            return false;
        }
    }

    /**
     * Actually send a message via the selected mechanism.
     *
     * @throws Exception
     *
     * @return bool
     */
    public function postSend()
    {
        try {
            //Choose the mailer and send through it
            switch ($this->Mailer) {
                case 'sendmail':
                case 'qmail':
                    return $this->sendmailSend($this->MIMEHeader, $this->MIMEBody);
                case 'smtp':
                    return $this->smtpSend($this->MIMEHeader, $this->MIMEBody);
                case 'mail':
                    return $this->mailSend($this->MIMEHeader, $this->MIMEBody);
                default:
                    $sendMethod = $this->Mailer . 'Send';
                    if (!empty($this->Mailer) && method_exists($this, $sendMethod)) {
                        return $this->{$sendMethod}($this->MIMEHeader, $this->MIMEBody);
                    }

                    return $this->mailSend($this->MIMEHeader, $this->MIMEBody);
            }
        } catch (Exception $exc) {
            $this->setError($exc->getMessage());
            $this->edebug($exc->getMessage());
            if ($this->Mailer === 'smtp' && $this->SMTPKeepAlive == true && $this->smtp->connected()) {
                $this->smtp->reset();
            }
            if ($this->exceptions) {
                throw $exc;
            }
        }

        return false;
    }

    /**
     * Send mail using the $Sendmail program.
     *
     * @see PHPMailer::$Sendmail
     *
     * @param string $header The message headers
     * @param string $body   The message body
     *
     * @throws Exception
     *
     * @return bool
     */
    protected function sendmailSend($header, $body)
    {
        if ($this->Mailer === 'qmail') {
            $this->edebug('Sending with qmail');
        } else {
            $this->edebug('Sending with sendmail');
        }
        $header = static::stripTrailingWSP($header) . static::$LE . static::$LE;
        //This sets the SMTP envelope sender which gets turned into a return-path header by the receiver
        //A space after `-f` is optional, but there is a long history of its presence
        //causing problems, so we don't use one
        //Exim docs: https://www.exim.org/exim-html-current/doc/html/spec_html/ch-the_exim_command_line.html
        //Sendmail docs: https://www.sendmail.org/~ca/email/man/sendmail.html
        //Example problem: https://www.drupal.org/node/1057954

        //PHP 5.6 workaround
        $sendmail_from_value = ini_get('sendmail_from');
        if (empty($this->Sender) && !empty($sendmail_from_value)) {
            //PHP config has a sender address we can use
            $this->Sender = ini_get('sendmail_from');
        }

        $sendmailArgs = [];

        // CVE-2016-10033, CVE-2016-10045: Don't pass -f if characters will be escaped.
        // Also don't add the -f automatically unless it has been set either via Sender
        // or sendmail_path. Otherwise, it can introduce new problems.
        // @see http://github.com/PHPMailer/PHPMailer/issues/2298
        if (!empty($this->Sender) && static::validateAddress($this->Sender) && self::isShellSafe($this->Sender)) {
            $sendmailArgs[] = '-f' . $this->Sender;
        }

        // Qmail doesn't accept all the sendmail parameters
        // @see https://github.com/PHPMailer/PHPMailer/issues/3189
        if ($this->Mailer !== 'qmail') {
            $sendmailArgs[] = '-i';
            $sendmailArgs[] = '-t';
        }

        $resultArgs = (empty($sendmailArgs) ? '' : ' ' . implode(' ', $sendmailArgs));

        $sendmail = trim(escapeshellcmd($this->Sendmail) . $resultArgs);
        $this->edebug('Sendmail path: ' . $this->Sendmail);
        $this->edebug('Sendmail command: ' . $sendmail);
        $this->edebug('Envelope sender: ' . $this->Sender);
        $this->edebug("Headers: {$header}");

        if ($this->SingleTo) {
            foreach ($this->SingleToArray as $toAddr) {
                $mail = @popen($sendmail, 'w');
                if (!$mail) {
                    throw new Exception(self::lang('execute') . $this->Sendmail, self::STOP_CRITICAL);
                }
                $this->edebug("To: {$toAddr}");
                fwrite($mail, 'To: ' . $toAddr . "\n");
                fwrite($mail, $header);
                fwrite($mail, $body);
                $result = pclose($mail);
                $addrinfo = static::parseAddresses($toAddr, null, $this->CharSet);
                foreach ($addrinfo as $addr) {
                    $this->doCallback(
                        ($result === 0),
                        [[$addr['address'], $addr['name']]],
                        $this->cc,
                        $this->bcc,
                        $this->Subject,
                        $body,
                        $this->From,
                        []
                    );
                }
                $this->edebug("Result: " . ($result === 0 ? 'true' : 'false'));
                if (0 !== $result) {
                    throw new Exception(self::lang('execute') . $this->Sendmail, self::STOP_CRITICAL);
                }
            }
        } else {
            $mail = @popen($sendmail, 'w');
            if (!$mail) {
                throw new Exception(self::lang('execute') . $this->Sendmail, self::STOP_CRITICAL);
            }
            fwrite($mail, $header);
            fwrite($mail, $body);
            $result = pclose($mail);
            $this->doCallback(
                ($result === 0),
                $this->to,
                $this->cc,
                $this->bcc,
                $this->Subject,
                $body,
                $this->From,
                []
            );
            $this->edebug("Result: " . ($result === 0 ? 'true' : 'false'));
            if (0 !== $result) {
                throw new Exception(self::lang('execute') . $this->Sendmail, self::STOP_CRITICAL);
            }
        }

        return true;
    }

    /**
     * Fix CVE-2016-10033 and CVE-2016-10045 by disallowing potentially unsafe shell characters.
     * Note that escapeshellarg and escapeshellcmd are inadequate for our purposes, especially on Windows.
     *
     * @see https://github.com/PHPMailer/PHPMailer/issues/924 CVE-2016-10045 bug report
     *
     * @param string $string The string to be validated
     *
     * @return bool
     */
    protected static function isShellSafe($string)
    {
        //It's not possible to use shell commands safely (which includes the mail() function) without escapeshellarg,
        //but some hosting providers disable it, creating a security problem that we don't want to have to deal with,
        //so we don't.
        if (!function_exists('escapeshellarg') || !function_exists('escapeshellcmd')) {
            return false;
        }

        if (
            escapeshellcmd($string) !== $string
            || !in_array(escapeshellarg($string), ["'$string'", "\"$string\""])
        ) {
            return false;
        }

        $length = strlen($string);

        for ($i = 0; $i < $length; ++$i) {
            $c = $string[$i];

            //All other characters have a special meaning in at least one common shell, including = and +.
            //Full stop (.) has a special meaning in cmd.exe, but its impact should be negligible here.
            //Note that this does permit non-Latin alphanumeric characters based on the current locale.
            if (!ctype_alnum($c) && strpos('@_-.', $c) === false) {
                return false;
            }
        }

        return true;
    }

    /**
     * Check whether a file path is of a permitted type.
     * Used to reject URLs and phar files from functions that access local file paths,
     * such as addAttachment.
     *
     * @param string $path A relative or absolute path to a file
     *
     * @return bool
     */
    protected static function isPermittedPath($path)
    {
        //Matches scheme definition from https://www.rfc-editor.org/rfc/rfc3986#section-3.1
        return !preg_match('#^[a-z][a-z\d+.-]*://#i', $path);
    }

    /**
     * Check whether a file path is safe, accessible, and readable.
     *
     * @param string $path A relative or absolute path to a file
     *
     * @return bool
     */
    protected static function fileIsAccessible($path)
    {
        if (!static::isPermittedPath($path)) {
            return false;
        }
        $readable = is_file($path);
        //If not a UNC path (expected to start with \\), check read permission, see #2069
        if (strpos($path, '\\\\') !== 0) {
            $readable = $readable && is_readable($path);
        }
        return  $readable;
    }

    /**
     * Send mail using the PHP mail() function.
     *
     * @see https://www.php.net/manual/en/book.mail.php
     *
     * @param string $header The message headers
     * @param string $body   The message body
     *
     * @throws Exception
     *
     * @return bool
     */
    protected function mailSend($header, $body)
    {
        $header = static::stripTrailingWSP($header) . static::$LE . static::$LE;

        $toArr = [];
        foreach ($this->to as $toaddr) {
            $toArr[] = $this->addrFormat($toaddr);
        }
        $to = trim(implode(', ', $toArr));

        //If there are no To-addresses (e.g. when sending only to BCC-addresses)
        //the following should be added to get a correct DKIM-signature.
        //Compare with $this->preSend()
        if ($to === '') {
            $to = 'undisclosed-recipients:;';
        }

        $params = null;
        //This sets the SMTP envelope sender which gets turned into a return-path header by the receiver
        //A space after `-f` is optional, but there is a long history of its presence
        //causing problems, so we don't use one
        //Exim docs: https://www.exim.org/exim-html-current/doc/html/spec_html/ch-the_exim_command_line.html
        //Sendmail docs: https://www.sendmail.org/~ca/email/man/sendmail.html
        //Example problem: https://www.drupal.org/node/1057954
        //CVE-2016-10033, CVE-2016-10045: Don't pass -f if characters will be escaped.

        //PHP 5.6 workaround
        $sendmail_from_value = ini_get('sendmail_from');
        if (empty($this->Sender) && !empty($sendmail_from_value)) {
            //PHP config has a sender address we can use
            $this->Sender = ini_get('sendmail_from');
        }
        if (!empty($this->Sender) && static::validateAddress($this->Sender)) {
            $phpmailer_path = ini_get('sendmail_path');
            if (self::isShellSafe($this->Sender) && strpos($phpmailer_path, ' -f') === false) {
                $params = sprintf('-f%s', $this->Sender);
            }
            $old_from = ini_get('sendmail_from');
            ini_set('sendmail_from', $this->Sender);
        }
        $result = false;
        if ($this->SingleTo && count($toArr) > 1) {
            foreach ($toArr as $toAddr) {
                $result = $this->mailPassthru($toAddr, $this->Subject, $body, $header, $params);
                $addrinfo = static::parseAddresses($toAddr, null, $this->CharSet);
                foreach ($addrinfo as $addr) {
                    $this->doCallback(
                        $result,
                        [[$addr['address'], $addr['name']]],
                        $this->cc,
                        $this->bcc,
                        $this->Subject,
                        $body,
                        $this->From,
                        []
                    );
                }
            }
        } else {
            $result = $this->mailPassthru($to, $this->Subject, $body, $header, $params);
            $this->doCallback($result, $this->to, $this->cc, $this->bcc, $this->Subject, $body, $this->From, []);
        }
        if (isset($old_from)) {
            ini_set('sendmail_from', $old_from);
        }
        if (!$result) {
            throw new Exception(self::lang('instantiate'), self::STOP_CRITICAL);
        }

        return true;
    }

    /**
     * Get an instance to use for SMTP operations.
     * Override this function to load your own SMTP implementation,
     * or set one with setSMTPInstance.
     *
     * @return SMTP
     */
    public function getSMTPInstance()
    {
        if (!is_object($this->smtp)) {
            $this->smtp = new SMTP();
        }

        return $this->smtp;
    }

    /**
     * Provide an instance to use for SMTP operations.
     *
     * @return SMTP
     */
    public function setSMTPInstance(SMTP $smtp)
    {
        $this->smtp = $smtp;

        return $this->smtp;
    }

    /**
     * Provide SMTP XCLIENT attributes
     *
     * @param string $name  Attribute name
     * @param ?string $value Attribute value
     *
     * @return bool
     */
    public function setSMTPXclientAttribute($name, $value)
    {
        if (!in_array($name, SMTP::$xclient_allowed_attributes)) {
            return false;
        }
        if (isset($this->SMTPXClient[$name]) && $value === null) {
            unset($this->SMTPXClient[$name]);
        } elseif ($value !== null) {
            $this->SMTPXClient[$name] = $value;
        }

        return true;
    }

    /**
     * Get SMTP XCLIENT attributes
     *
     * @return array
     */
    public function getSMTPXclientAttributes()
    {
        return $this->SMTPXClient;
    }

    /**
     * Send mail via SMTP.
     * Returns false if there is a bad MAIL FROM, RCPT, or DATA input.
     *
     * @see PHPMailer::setSMTPInstance() to use a different class.
     *
     * @uses \PHPMailer\PHPMailer\SMTP
     *
     * @param string $header The message headers
     * @param string $body   The message body
     *
     * @throws Exception
     *
     * @return bool
     */
    protected function smtpSend($header, $body)
    {
        $header = static::stripTrailingWSP($header) . static::$LE . static::$LE;
        $bad_rcpt = [];
        if (!$this->smtpConnect($this->SMTPOptions)) {
            throw new Exception(self::lang('smtp_connect_failed'), self::STOP_CRITICAL);
        }
        //If we have recipient addresses that need Unicode support,
        //but the server doesn't support it, stop here
        if ($this->UseSMTPUTF8 && !$this->smtp->getServerExt('SMTPUTF8')) {
            throw new Exception(self::lang('no_smtputf8'), self::STOP_CRITICAL);
        }
        //Sender already validated in preSend()
        if ('' === $this->Sender) {
            $smtp_from = $this->From;
        } else {
            $smtp_from = $this->Sender;
        }
        if (count($this->SMTPXClient)) {
            $this->smtp->xclient($this->SMTPXClient);
        }
        if (!$this->smtp->mail($smtp_from)) {
            $this->setError(self::lang('from_failed') . $smtp_from . ' : ' . implode(',', $this->smtp->getError()));
            throw new Exception($this->ErrorInfo, self::STOP_CRITICAL);
        }

        $callbacks = [];
        //Attempt to send to all recipients
        foreach ([$this->to, $this->cc, $this->bcc] as $togroup) {
            foreach ($togroup as $to) {
                if (!$this->smtp->recipient($to[0], $this->dsn)) {
                    $error = $this->smtp->getError();
                    $bad_rcpt[] = ['to' => $to[0], 'error' => $error['detail']];
                    $isSent = false;
                } else {
                    $isSent = true;
                }

                $callbacks[] = ['issent' => $isSent, 'to' => $to[0], 'name' => $to[1]];
            }
        }

        //Only send the DATA command if we have viable recipients
        if ((count($this->all_recipients) > count($bad_rcpt)) && !$this->smtp->data($header . $body)) {
            throw new Exception(self::lang('data_not_accepted'), self::STOP_CRITICAL);
        }

        $smtp_transaction_id = $this->smtp->getLastTransactionID();

        if ($this->SMTPKeepAlive) {
            $this->smtp->reset();
        } else {
            $this->smtp->quit();
            $this->smtp->close();
        }

        foreach ($callbacks as $cb) {
            $this->doCallback(
                $cb['issent'],
                [[$cb['to'], $cb['name']]],
                [],
                [],
                $this->Subject,
                $body,
                $this->From,
                ['smtp_transaction_id' => $smtp_transaction_id]
            );
        }

        //Create error message for any bad addresses
        if (count($bad_rcpt) > 0) {
            $errstr = '';
            foreach ($bad_rcpt as $bad) {
                $errstr .= $bad['to'] . ': ' . $bad['error'];
            }
            throw new Exception(self::lang('recipients_failed') . $errstr, self::STOP_CONTINUE);
        }

        return true;
    }

    /**
     * Initiate a connection to an SMTP server.
     * Returns false if the operation failed.
     *
     * @param array $options An array of options compatible with stream_context_create()
     *
     * @throws Exception
     *
     * @uses \PHPMailer\PHPMailer\SMTP
     *
     * @return bool
     */
    public function smtpConnect($options = null)
    {
        if (null === $this->smtp) {
            $this->smtp = $this->getSMTPInstance();
        }

        //If no options are provided, use whatever is set in the instance
        if (null === $options) {
            $options = $this->SMTPOptions;
        }

        //Already connected?
        if ($this->smtp->connected()) {
            return true;
        }

        $this->smtp->setTimeout($this->Timeout);
        $this->smtp->setDebugLevel($this->SMTPDebug);
        $this->smtp->setDebugOutput($this->Debugoutput);
        $this->smtp->setVerp($this->do_verp);
        $this->smtp->setSMTPUTF8($this->UseSMTPUTF8);
        if ($this->Host === null) {
            $this->Host = 'localhost';
        }
        $hosts = explode(';', $this->Host);
        $lastexception = null;

        foreach ($hosts as $hostentry) {
            $hostinfo = [];
            if (
                !preg_match(
                    '/^(?:(ssl|tls):\/\/)?(.+?)(?::(\d+))?$/',
                    trim($hostentry),
                    $hostinfo
                )
            ) {
                $this->edebug(self::lang('invalid_hostentry') . ' ' . trim($hostentry));
                //Not a valid host entry
                continue;
            }
            //$hostinfo[1]: optional ssl or tls prefix
            //$hostinfo[2]: the hostname
            //$hostinfo[3]: optional port number
            //The host string prefix can temporarily override the current setting for SMTPSecure
            //If it's not specified, the default value is used

            //Check the host name is a valid name or IP address before trying to use it
            if (!static::isValidHost($hostinfo[2])) {
                $this->edebug(self::lang('invalid_host') . ' ' . $hostinfo[2]);
                continue;
            }
            $prefix = '';
            $secure = $this->SMTPSecure;
            $tls = (static::ENCRYPTION_STARTTLS === $this->SMTPSecure);
            if ('ssl' === $hostinfo[1] || ('' === $hostinfo[1] && static::ENCRYPTION_SMTPS === $this->SMTPSecure)) {
                $prefix = 'ssl://';
                $tls = false; //Can't have SSL and TLS at the same time
                $secure = static::ENCRYPTION_SMTPS;
            } elseif ('tls' === $hostinfo[1]) {
                $tls = true;
                //TLS doesn't use a prefix
                $secure = static::ENCRYPTION_STARTTLS;
            }
            //Do we need the OpenSSL extension?
            $sslext = defined('OPENSSL_ALGO_SHA256');
            if (static::ENCRYPTION_STARTTLS === $secure || static::ENCRYPTION_SMTPS === $secure) {
                //Check for an OpenSSL constant rather than using extension_loaded, which is sometimes disabled
                if (!$sslext) {
                    throw new Exception(self::lang('extension_missing') . 'openssl', self::STOP_CRITICAL);
                }
            }
            $host = $hostinfo[2];
            $port = $this->Port;
            if (
                array_key_exists(3, $hostinfo) &&
                is_numeric($hostinfo[3]) &&
                $hostinfo[3] > 0 &&
                $hostinfo[3] < 65536
            ) {
                $port = (int) $hostinfo[3];
            }
            if ($this->smtp->connect($prefix . $host, $port, $this->Timeout, $options)) {
                try {
                    if ($this->Helo) {
                        $hello = $this->Helo;
                    } else {
                        $hello = $this->serverHostname();
                    }
                    $this->smtp->hello($hello);
                    //Automatically enable TLS encryption if:
                    //* it's not disabled
                    //* we are not connecting to localhost
                    //* we have openssl extension
                    //* we are not already using SSL
                    //* the server offers STARTTLS
                    if (
                        $this->SMTPAutoTLS &&
                        $this->Host !== 'localhost' &&
                        $sslext &&
                        $secure !== 'ssl' &&
                        $this->smtp->getServerExt('STARTTLS')
                    ) {
                        $tls = true;
                    }
                    if ($tls) {
                        if (!$this->smtp->startTLS()) {
                            $message = $this->getSmtpErrorMessage('connect_host');
                            throw new Exception($message);
                        }
                        //We must resend EHLO after TLS negotiation
                        $this->smtp->hello($hello);
                    }
                    if (
                        $this->SMTPAuth && !$this->smtp->authenticate(
                            $this->Username,
                            $this->Password,
                            $this->AuthType,
                            $this->oauth
                        )
                    ) {
                        throw new Exception(self::lang('authenticate'));
                    }

                    return true;
                } catch (Exception $exc) {
                    $lastexception = $exc;
                    $this->edebug($exc->getMessage());
                    //We must have connected, but then failed TLS or Auth, so close connection nicely
                    $this->smtp->quit();
                }
            }
        }
        //If we get here, all connection attempts have failed, so close connection hard
        $this->smtp->close();
        //As we've caught all exceptions, just report whatever the last one was
        if ($this->exceptions && null !== $lastexception) {
            throw $lastexception;
        }
        if ($this->exceptions) {
            // no exception was thrown, likely $this->smtp->connect() failed
            $message = $this->getSmtpErrorMessage('connect_host');
            throw new Exception($message);
        }

        return false;
    }

    /**
     * Close the active SMTP session if one exists.
     */
    public function smtpClose()
    {
        if ((null !== $this->smtp) && $this->smtp->connected()) {
            $this->smtp->quit();
            $this->smtp->close();
        }
    }

    /**
     * Set the language for error messages.
     * The default language is English.
     *
     * @param string $langcode  ISO 639-1 2-character language code (e.g. French is "fr")
     *                          Optionally, the language code can be enhanced with a 4-character
     *                          script annotation and/or a 2-character country annotation.
     * @param string $lang_path Path to the language file directory, with trailing separator (slash)
     *                          Do not set this from user input!
     *
     * @return bool Returns true if the requested language was loaded, false otherwise.
     */
    public static function setLanguage($langcode = 'en', $lang_path = '')
    {
        //Backwards compatibility for renamed language codes
        $renamed_langcodes = [
            'br' => 'pt_br',
            'cz' => 'cs',
            'dk' => 'da',
            'no' => 'nb',
            'se' => 'sv',
            'rs' => 'sr',
            'tg' => 'tl',
            'am' => 'hy',
        ];

        if (array_key_exists($langcode, $renamed_langcodes)) {
            $langcode = $renamed_langcodes[$langcode];
        }

        //Define full set of translatable strings in English
        $PHPMAILER_LANG = [
            'authenticate' => 'SMTP Error: Could not authenticate.',
            'buggy_php' => 'Your version of PHP is affected by a bug that may result in corrupted messages.' .
                ' To fix it, switch to sending using SMTP, disable the mail.add_x_header option in' .
                ' your php.ini, switch to macOS or Linux, or upgrade your PHP to version 7.0.17+ or 7.1.3+.',
            'connect_host' => 'SMTP Error: Could not connect to SMTP host.',
            'data_not_accepted' => 'SMTP Error: data not accepted.',
            'empty_message' => 'Message body empty',
            'encoding' => 'Unknown encoding: ',
            'execute' => 'Could not execute: ',
            'extension_missing' => 'Extension missing: ',
            'file_access' => 'Could not access file: ',
            'file_open' => 'File Error: Could not open file: ',
            'from_failed' => 'The following From address failed: ',
            'instantiate' => 'Could not instantiate mail function.',
            'invalid_address' => 'Invalid address: ',
            'invalid_header' => 'Invalid header name or value',
            'invalid_hostentry' => 'Invalid hostentry: ',
            'invalid_host' => 'Invalid host: ',
            'mailer_not_supported' => ' mailer is not supported.',
            'provide_address' => 'You must provide at least one recipient email address.',
            'recipients_failed' => 'SMTP Error: The following recipients failed: ',
            'signing' => 'Signing Error: ',
            'smtp_code' => 'SMTP code: ',
            'smtp_code_ex' => 'Additional SMTP info: ',
            'smtp_connect_failed' => 'SMTP connect() failed.',
            'smtp_detail' => 'Detail: ',
            'smtp_error' => 'SMTP server error: ',
            'variable_set' => 'Cannot set or reset variable: ',
            'no_smtputf8' => 'Server does not support SMTPUTF8 needed to send to Unicode addresses',
            'imap_recommended' => 'Using simplified address parser is not recommended. ' .
                'Install the PHP IMAP extension for full RFC822 parsing.',
            'deprecated_argument' => 'Deprecated Argument: ',
        ];
        if (empty($lang_path)) {
            //Calculate an absolute path so it can work if CWD is not here
            $lang_path = dirname(__DIR__) . DIRECTORY_SEPARATOR . 'language' . DIRECTORY_SEPARATOR;
        }

        //Validate $langcode
        $foundlang = true;
        $langcode  = strtolower($langcode);
        if (
            !preg_match('/^(?P<lang>[a-z]{2})(?P<script>_[a-z]{4})?(?P<country>_[a-z]{2})?$/', $langcode, $matches)
            && $langcode !== 'en'
        ) {
            $foundlang = false;
            $langcode = 'en';
        }

        //There is no English translation file
        if ('en' !== $langcode) {
            $langcodes = [];
            if (!empty($matches['script']) && !empty($matches['country'])) {
                $langcodes[] = $matches['lang'] . $matches['script'] . $matches['country'];
            }
            if (!empty($matches['country'])) {
                $langcodes[] = $matches['lang'] . $matches['country'];
            }
            if (!empty($matches['script'])) {
                $langcodes[] = $matches['lang'] . $matches['script'];
            }
            $langcodes[] = $matches['lang'];

            //Try and find a readable language file for the requested language.
            $foundFile = false;
            foreach ($langcodes as $code) {
                $lang_file = $lang_path . 'phpmailer.lang-' . $code . '.php';
                if (static::fileIsAccessible($lang_file)) {
                    $foundFile = true;
                    break;
                }
            }

            if ($foundFile === false) {
                $foundlang = false;
            } else {
                $lines = file($lang_file);
                foreach ($lines as $line) {
                    //Translation file lines look like this:
                    //$PHPMAILER_LANG['authenticate'] = 'SMTP-Fehler: Authentifizierung fehlgeschlagen.';
                    //These files are parsed as text and not PHP so as to avoid the possibility of code injection
                    //See https://blog.stevenlevithan.com/archives/match-quoted-string
                    $matches = [];
                    if (
                        preg_match(
                            '/^\$PHPMAILER_LANG\[\'([a-z\d_]+)\'\]\s*=\s*(["\'])(.+)*?\2;/',
                            $line,
                            $matches
                        ) &&
                        //Ignore unknown translation keys
                        array_key_exists($matches[1], $PHPMAILER_LANG)
                    ) {
                        //Overwrite language-specific strings so we'll never have missing translation keys.
                        $PHPMAILER_LANG[$matches[1]] = (string)$matches[3];
                    }
                }
            }
        }
        self::$language = $PHPMAILER_LANG;

        return $foundlang; //Returns false if language not found
    }

    /**
     * Get the array of strings for the current language.
     *
     * @return array
     */
    public function getTranslations()
    {
        if (empty(self::$language)) {
            self::setLanguage(); // Set the default language.
        }

        return self::$language;
    }

    /**
     * Create recipient headers.
     *
     * @param string $type
     * @param array  $addr An array of recipients,
     *                     where each recipient is a 2-element indexed array with element 0 containing an address
     *                     and element 1 containing a name, like:
     *                     [['joe@example.com', 'Joe User'], ['zoe@example.com', 'Zoe User']]
     *
     * @return string
     */
    public function addrAppend($type, $addr)
    {
        $addresses = [];
        foreach ($addr as $address) {
            $addresses[] = $this->addrFormat($address);
        }

        return $type . ': ' . implode(', ', $addresses) . static::$LE;
    }

    /**
     * Format an address for use in a message header.
     *
     * @param array $addr A 2-element indexed array, element 0 containing an address, element 1 containing a name like
     *                    ['joe@example.com', 'Joe User']
     *
     * @return string
     */
    public function addrFormat($addr)
    {
        if (!isset($addr[1]) || ($addr[1] === '')) { //No name provided
            return $this->secureHeader($addr[0]);
        }

        return $this->encodeHeader($this->secureHeader($addr[1]), 'phrase') .
            ' <' . $this->secureHeader($addr[0]) . '>';
    }

    /**
     * Word-wrap message.
     * For use with mailers that do not automatically perform wrapping
     * and for quoted-printable encoded messages.
     * Original written by philippe.
     *
     * @param string $message The message to wrap
     * @param int    $length  The line length to wrap to
     * @param bool   $qp_mode Whether to run in Quoted-Printable mode
     *
     * @return string
     */
    public function wrapText($message, $length, $qp_mode = false)
    {
        if ($qp_mode) {
            $soft_break = sprintf(' =%s', static::$LE);
        } else {
            $soft_break = static::$LE;
        }
        //If utf-8 encoding is used, we will need to make sure we don't
        //split multibyte characters when we wrap
        $is_utf8 = static::CHARSET_UTF8 === strtolower($this->CharSet);
        $lelen = strlen(static::$LE);
        $crlflen = strlen(static::$LE);

        $message = static::normalizeBreaks($message);
        //Remove a trailing line break
        if (substr($message, -$lelen) === static::$LE) {
            $message = substr($message, 0, -$lelen);
        }

        //Split message into lines
        $lines = explode(static::$LE, $message);
        //Message will be rebuilt in here
        $message = '';
        foreach ($lines as $line) {
            $words = explode(' ', $line);
            $buf = '';
            $firstword = true;
            foreach ($words as $word) {
                if ($qp_mode && (strlen($word) > $length)) {
                    $space_left = $length - strlen($buf) - $crlflen;
                    if (!$firstword) {
                        if ($space_left > 20) {
                            $len = $space_left;
                            if ($is_utf8) {
                                $len = $this->utf8CharBoundary($word, $len);
                            } elseif ('=' === substr($word, $len - 1, 1)) {
                                --$len;
                            } elseif ('=' === substr($word, $len - 2, 1)) {
                                $len -= 2;
                            }
                            $part = substr($word, 0, $len);
                            $word = substr($word, $len);
                            $buf .= ' ' . $part;
                            $message .= $buf . sprintf('=%s', static::$LE);
                        } else {
                            $message .= $buf . $soft_break;
                        }
                        $buf = '';
                    }
                    while ($word !== '') {
                        if ($length <= 0) {
                            break;
                        }
                        $len = $length;
                        if ($is_utf8) {
                            $len = $this->utf8CharBoundary($word, $len);
                        } elseif ('=' === substr($word, $len - 1, 1)) {
                            --$len;
                        } elseif ('=' === substr($word, $len - 2, 1)) {
                            $len -= 2;
                        }
                        $part = substr($word, 0, $len);
                        $word = (string) substr($word, $len);

                        if ($word !== '') {
                            $message .= $part . sprintf('=%s', static::$LE);
                        } else {
                            $buf = $part;
                        }
                    }
                } else {
                    $buf_o = $buf;
                    if (!$firstword) {
                        $buf .= ' ';
                    }
                    $buf .= $word;

                    if ('' !== $buf_o && strlen($buf) > $length) {
                        $message .= $buf_o . $soft_break;
                        $buf = $word;
                    }
                }
                $firstword = false;
            }
            $message .= $buf . static::$LE;
        }

        return $message;
    }

    /**
     * Find the last character boundary prior to $maxLength in a utf-8
     * quoted-printable encoded string.
     * Original written by Colin Brown.
     *
     * @param string $encodedText utf-8 QP text
     * @param int    $maxLength   Find the last character boundary prior to this length
     *
     * @return int
     */
    public function utf8CharBoundary($encodedText, $maxLength)
    {
        $foundSplitPos = false;
        $lookBack = 3;
        while (!$foundSplitPos) {
            $lastChunk = substr($encodedText, $maxLength - $lookBack, $lookBack);
            $encodedCharPos = strpos($lastChunk, '=');
            if (false !== $encodedCharPos) {
                //Found start of encoded character byte within $lookBack block.
                //Check the encoded byte value (the 2 chars after the '=')
                $hex = substr($encodedText, $maxLength - $lookBack + $encodedCharPos + 1, 2);
                $dec = hexdec($hex);
                if ($dec < 128) {
                    //Single byte character.
                    //If the encoded char was found at pos 0, it will fit
                    //otherwise reduce maxLength to start of the encoded char
                    if ($encodedCharPos > 0) {
                        $maxLength -= $lookBack - $encodedCharPos;
                    }
                    $foundSplitPos = true;
                } elseif ($dec >= 192) {
                    //First byte of a multi byte character
                    //Reduce maxLength to split at start of character
                    $maxLength -= $lookBack - $encodedCharPos;
                    $foundSplitPos = true;
                } elseif ($dec < 192) {
                    //Middle byte of a multi byte character, look further back
                    $lookBack += 3;
                }
            } else {
                //No encoded character found
                $foundSplitPos = true;
            }
        }

        return $maxLength;
    }

    /**
     * Apply word wrapping to the message body.
     * Wraps the message body to the number of chars set in the WordWrap property.
     * You should only do this to plain-text bodies as wrapping HTML tags may break them.
     * This is called automatically by createBody(), so you don't need to call it yourself.
     */
    public function setWordWrap()
    {
        if ($this->WordWrap < 1) {
            return;
        }

        switch ($this->message_type) {
            case 'alt':
            case 'alt_inline':
            case 'alt_attach':
            case 'alt_inline_attach':
                $this->AltBody = $this->wrapText($this->AltBody, $this->WordWrap);
                break;
            default:
                $this->Body = $this->wrapText($this->Body, $this->WordWrap);
                break;
        }
    }

    /**
     * Assemble message headers.
     *
     * @return string The assembled headers
     */
    public function createHeader()
    {
        $result = '';

        $result .= $this->headerLine(
            'Date',
            self::sanitiseDate($this->MessageDate)
        );

        //The To header is created automatically by mail(), so needs to be omitted here
        if ('mail' !== $this->Mailer) {
            if ($this->SingleTo) {
                foreach ($this->to as $toaddr) {
                    $this->SingleToArray[] = $this->addrFormat($toaddr);
                }
            } elseif (count($this->to) > 0) {
                $result .= $this->addrAppend('To', $this->to);
            } elseif (count($this->cc) === 0) {
                $result .= $this->headerLine('To', 'undisclosed-recipients:;');
            }
        }
        $result .= $this->addrAppend('From', [[trim($this->From), $this->FromName]]);

        //sendmail and mail() extract Cc from the header before sending
        if (count($this->cc) > 0) {
            $result .= $this->addrAppend('Cc', $this->cc);
        }

        //sendmail and mail() extract Bcc from the header before sending
        if (
            (
                'sendmail' === $this->Mailer || 'qmail' === $this->Mailer || 'mail' === $this->Mailer
            )
            && count($this->bcc) > 0
        ) {
            $result .= $this->addrAppend('Bcc', $this->bcc);
        }

        if (count($this->ReplyTo) > 0) {
            $result .= $this->addrAppend('Reply-To', $this->ReplyTo);
        }

        //mail() sets the subject itself
        if ('mail' !== $this->Mailer) {
            $result .= $this->headerLine('Subject', $this->encodeHeader($this->secureHeader($this->Subject)));
        }

        //Only allow a custom message ID if it conforms to RFC 5322 section 3.6.4
        //https://www.rfc-editor.org/rfc/rfc5322#section-3.6.4
        if (
            '' !== $this->MessageID &&
            preg_match(
                '/^<((([a-z\d!#$%&\'*+\/=?^_`{|}~-]+(\.[a-z\d!#$%&\'*+\/=?^_`{|}~-]+)*)' .
                '|("(([\x01-\x08\x0B\x0C\x0E-\x1F\x7F]|[\x21\x23-\x5B\x5D-\x7E])' .
                '|(\\[\x01-\x09\x0B\x0C\x0E-\x7F]))*"))@(([a-z\d!#$%&\'*+\/=?^_`{|}~-]+' .
                '(\.[a-z\d!#$%&\'*+\/=?^_`{|}~-]+)*)|(\[(([\x01-\x08\x0B\x0C\x0E-\x1F\x7F]' .
                '|[\x21-\x5A\x5E-\x7E])|(\\[\x01-\x09\x0B\x0C\x0E-\x7F]))*\])))>$/Di',
                $this->MessageID
            )
        ) {
            $this->lastMessageID = $this->MessageID;
        } else {
            $this->lastMessageID = sprintf('<%s@%s>', $this->uniqueid, $this->serverHostname());
        }
        $result .= $this->headerLine('Message-ID', $this->lastMessageID);
        if (null !== $this->Priority) {
            $result .= $this->headerLine('X-Priority', $this->Priority);
        }
        if ('' === $this->XMailer) {
            //Empty string for default X-Mailer header
            $result .= $this->headerLine(
                'X-Mailer',
                'PHPMailer ' . self::VERSION . ' (https://github.com/PHPMailer/PHPMailer)'
            );
        } elseif (is_string($this->XMailer) && trim($this->XMailer) !== '') {
            //Some string
            $result .= $this->headerLine('X-Mailer', $this->secureHeader(trim($this->XMailer)));
        } //Other values result in no X-Mailer header

        if ('' !== $this->ConfirmReadingTo) {
            $result .= $this->headerLine('Disposition-Notification-To', '<' . $this->ConfirmReadingTo . '>');
        }

        //Add custom headers
        foreach ($this->CustomHeader as $header) {
            $result .= $this->headerLine(
                trim($header[0]),
                $this->encodeHeader(trim($header[1]))
            );
        }
        if (!$this->sign_key_file) {
            $result .= $this->headerLine('MIME-Version', '1.0');
            $result .= $this->getMailMIME();
        }

        return $result;
    }

    /**
     * Get the message MIME type headers.
     *
     * @return string
     */
    public function getMailMIME()
    {
        $result = '';
        $ismultipart = true;
        switch ($this->message_type) {
            case 'inline':
                $result .= $this->headerLine('Content-Type', static::CONTENT_TYPE_MULTIPART_RELATED . ';');
                $result .= $this->textLine(' boundary="' . $this->boundary[1] . '"');
                break;
            case 'attach':
            case 'inline_attach':
            case 'alt_attach':
            case 'alt_inline_attach':
                $result .= $this->headerLine('Content-Type', static::CONTENT_TYPE_MULTIPART_MIXED . ';');
                $result .= $this->textLine(' boundary="' . $this->boundary[1] . '"');
                break;
            case 'alt':
            case 'alt_inline':
                $result .= $this->headerLine('Content-Type', static::CONTENT_TYPE_MULTIPART_ALTERNATIVE . ';');
                $result .= $this->textLine(' boundary="' . $this->boundary[1] . '"');
                break;
            default:
                //Catches case 'plain': and case '':
                $result .= $this->textLine(
                    'Content-Type: ' .
                    $this->secureHeader($this->ContentType) .
                    '; charset=' . $this->secureHeader($this->CharSet)
                );
                $ismultipart = false;
                break;
        }
        if (!$this->validateEncoding($this->Encoding)) {
            throw new Exception(self::lang('encoding') . $this->Encoding);
        }
        //RFC1341 part 5 says 7bit is assumed if not specified
        if (static::ENCODING_7BIT !== $this->Encoding) {
            //RFC 2045 section 6.4 says multipart MIME parts may only use 7bit, 8bit, or binary CTE
            if ($ismultipart) {
                if (static::ENCODING_8BIT === $this->Encoding) {
                    $result .= $this->headerLine('Content-Transfer-Encoding', static::ENCODING_8BIT);
                }
                //The only remaining alternatives are quoted-printable and base64, which are both 7bit compatible
            } else {
                $result .= $this->headerLine('Content-Transfer-Encoding', $this->Encoding);
            }
        }

        return $result;
    }

    /**
     * Returns the whole MIME message.
     * Includes complete headers and body.
     * Only valid post preSend().
     *
     * @see PHPMailer::preSend()
     *
     * @return string
     */
    public function getSentMIMEMessage()
    {
        return static::stripTrailingWSP($this->MIMEHeader . $this->mailHeader) .
            static::$LE . static::$LE . $this->MIMEBody;
    }

    /**
     * Create a unique ID to use for boundaries.
     *
     * @return string
     */
    protected function generateId()
    {
        $len = 32; //32 bytes = 256 bits
        $bytes = '';
        if (function_exists('random_bytes')) {
            try {
                // phpcs:ignore PHPCompatibility.FunctionUse.NewFunctions.random_bytesFound -- Wrapped in function_exists.
                $bytes = random_bytes($len);
            } catch (\Exception $e) {
                //Do nothing
            }
        } elseif (function_exists('openssl_random_pseudo_bytes')) {
            /** @noinspection CryptographicallySecureRandomnessInspection */
            $bytes = openssl_random_pseudo_bytes($len);
        }
        if ($bytes === '') {
            //We failed to produce a proper random string, so make do.
            //Use a hash to force the length to the same as the other methods
            $bytes = hash('sha256', uniqid((string) mt_rand(), true), true);
        }

        //We don't care about messing up base64 format here, just want a random string
        return str_replace(['=', '+', '/'], '', base64_encode(hash('sha256', $bytes, true)));
    }

    /**
     * Assemble the message body.
     * Returns an empty string on failure.
     *
     * @throws Exception
     *
     * @return string The assembled message body
     */
    public function createBody()
    {
        $body = '';
        //Create unique IDs and preset boundaries
        $this->setBoundaries();

        $this->setWordWrap();

        if (!$this->validateEncoding($this->Encoding)) {
            throw new Exception(self::lang('encoding') . $this->Encoding);
        }
        $bodyEncoding = $this->Encoding;
        $bodyCharSet = $this->CharSet;
        //Can we do a 7-bit downgrade?
        if ($this->UseSMTPUTF8) {
            $bodyEncoding = static::ENCODING_8BIT;
        } elseif (static::ENCODING_8BIT === $bodyEncoding && !$this->has8bitChars($this->Body)) {
            $bodyEncoding = static::ENCODING_7BIT;
            //All ISO 8859, Windows codepage and UTF-8 charsets are ascii compatible up to 7-bit
            $bodyCharSet = static::CHARSET_ASCII;
        }
        //If lines are too long, and we're not already using an encoding that will shorten them,
        //change to quoted-printable transfer encoding for the body part only
        if (static::ENCODING_BASE64 !== $this->Encoding && static::hasLineLongerThanMax($this->Body)) {
            $bodyEncoding = static::ENCODING_QUOTED_PRINTABLE;
        }

        $altBodyEncoding = $this->Encoding;
        $altBodyCharSet = $this->CharSet;
        //Can we do a 7-bit downgrade?
        if (static::ENCODING_8BIT === $altBodyEncoding && !$this->has8bitChars($this->AltBody)) {
            $altBodyEncoding = static::ENCODING_7BIT;
            //All ISO 8859, Windows codepage and UTF-8 charsets are ascii compatible up to 7-bit
            $altBodyCharSet = static::CHARSET_ASCII;
        }
        //If lines are too long, and we're not already using an encoding that will shorten them,
        //change to quoted-printable transfer encoding for the alt body part only
        if (static::ENCODING_BASE64 !== $altBodyEncoding && static::hasLineLongerThanMax($this->AltBody)) {
            $altBodyEncoding = static::ENCODING_QUOTED_PRINTABLE;
        }

        if ($this->sign_key_file) {
            $this->Encoding = $bodyEncoding;
            $body .= $this->getMailMIME() . static::$LE;
        }

        //Use this as a preamble in all multipart message types
        $mimepre = '';
        switch ($this->message_type) {
            case 'inline':
                $body .= $mimepre;
                $body .= $this->getBoundary($this->boundary[1], $bodyCharSet, '', $bodyEncoding);
                $body .= $this->encodeString($this->Body, $bodyEncoding);
                $body .= static::$LE;
                $body .= $this->attachAll('inline', $this->boundary[1]);
                break;
            case 'attach':
                $body .= $mimepre;
                $body .= $this->getBoundary($this->boundary[1], $bodyCharSet, '', $bodyEncoding);
                $body .= $this->encodeString($this->Body, $bodyEncoding);
                $body .= static::$LE;
                $body .= $this->attachAll('attachment', $this->boundary[1]);
                break;
            case 'inline_attach':
                $body .= $mimepre;
                $body .= $this->textLine('--' . $this->boundary[1]);
                $body .= $this->headerLine('Content-Type', static::CONTENT_TYPE_MULTIPART_RELATED . ';');
                $body .= $this->textLine(' boundary="' . $this->boundary[2] . '";');
                $body .= $this->textLine(' type="' . static::CONTENT_TYPE_TEXT_HTML . '"');
                $body .= static::$LE;
                $body .= $this->getBoundary($this->boundary[2], $bodyCharSet, '', $bodyEncoding);
                $body .= $this->encodeString($this->Body, $bodyEncoding);
                $body .= static::$LE;
                $body .= $this->attachAll('inline', $this->boundary[2]);
                $body .= static::$LE;
                $body .= $this->attachAll('attachment', $this->boundary[1]);
                break;
            case 'alt':
                $body .= $mimepre;
                $body .= $this->getBoundary(
                    $this->boundary[1],
                    $altBodyCharSet,
                    static::CONTENT_TYPE_PLAINTEXT,
                    $altBodyEncoding
                );
                $body .= $this->encodeString($this->AltBody, $altBodyEncoding);
                $body .= static::$LE;
                $body .= $this->getBoundary(
                    $this->boundary[1],
                    $bodyCharSet,
                    static::CONTENT_TYPE_TEXT_HTML,
                    $bodyEncoding
                );
                $body .= $this->encodeString($this->Body, $bodyEncoding);
                $body .= static::$LE;
                if (!empty($this->Ical)) {
                    $method = static::ICAL_METHOD_REQUEST;
                    foreach (static::$IcalMethods as $imethod) {
                        if (stripos($this->Ical, 'METHOD:' . $imethod) !== false) {
                            $method = $imethod;
                            break;
                        }
                    }
                    $body .= $this->getBoundary(
                        $this->boundary[1],
                        '',
                        static::CONTENT_TYPE_TEXT_CALENDAR . '; method=' . $method,
                        ''
                    );
                    $body .= $this->encodeString($this->Ical, $this->Encoding);
                    $body .= static::$LE;
                }
                $body .= $this->endBoundary($this->boundary[1]);
                break;
            case 'alt_inline':
                $body .= $mimepre;
                $body .= $this->getBoundary(
                    $this->boundary[1],
                    $altBodyCharSet,
                    static::CONTENT_TYPE_PLAINTEXT,
                    $altBodyEncoding
                );
                $body .= $this->encodeString($this->AltBody, $altBodyEncoding);
                $body .= static::$LE;
                $body .= $this->textLine('--' . $this->boundary[1]);
                $body .= $this->headerLine('Content-Type', static::CONTENT_TYPE_MULTIPART_RELATED . ';');
                $body .= $this->textLine(' boundary="' . $this->boundary[2] . '";');
                $body .= $this->textLine(' type="' . static::CONTENT_TYPE_TEXT_HTML . '"');
                $body .= static::$LE;
                $body .= $this->getBoundary(
                    $this->boundary[2],
                    $bodyCharSet,
                    static::CONTENT_TYPE_TEXT_HTML,
                    $bodyEncoding
                );
                $body .= $this->encodeString($this->Body, $bodyEncoding);
                $body .= static::$LE;
                $body .= $this->attachAll('inline', $this->boundary[2]);
                $body .= static::$LE;
                $body .= $this->endBoundary($this->boundary[1]);
                break;
            case 'alt_attach':
                $body .= $mimepre;
                $body .= $this->textLine('--' . $this->boundary[1]);
                $body .= $this->headerLine('Content-Type', static::CONTENT_TYPE_MULTIPART_ALTERNATIVE . ';');
                $body .= $this->textLine(' boundary="' . $this->boundary[2] . '"');
                $body .= static::$LE;
                $body .= $this->getBoundary(
                    $this->boundary[2],
                    $altBodyCharSet,
                    static::CONTENT_TYPE_PLAINTEXT,
                    $altBodyEncoding
                );
                $body .= $this->encodeString($this->AltBody, $altBodyEncoding);
                $body .= static::$LE;
                $body .= $this->getBoundary(
                    $this->boundary[2],
                    $bodyCharSet,
                    static::CONTENT_TYPE_TEXT_HTML,
                    $bodyEncoding
                );
                $body .= $this->encodeString($this->Body, $bodyEncoding);
                $body .= static::$LE;
                if (!empty($this->Ical)) {
                    $method = static::ICAL_METHOD_REQUEST;
                    foreach (static::$IcalMethods as $imethod) {
                        if (stripos($this->Ical, 'METHOD:' . $imethod) !== false) {
                            $method = $imethod;
                            break;
                        }
                    }
                    $body .= $this->getBoundary(
                        $this->boundary[2],
                        '',
                        static::CONTENT_TYPE_TEXT_CALENDAR . '; method=' . $method,
                        ''
                    );
                    $body .= $this->encodeString($this->Ical, $this->Encoding);
                }
                $body .= $this->endBoundary($this->boundary[2]);
                $body .= static::$LE;
                $body .= $this->attachAll('attachment', $this->boundary[1]);
                break;
            case 'alt_inline_attach':
                $body .= $mimepre;
                $body .= $this->textLine('--' . $this->boundary[1]);
                $body .= $this->headerLine('Content-Type', static::CONTENT_TYPE_MULTIPART_ALTERNATIVE . ';');
                $body .= $this->textLine(' boundary="' . $this->boundary[2] . '"');
                $body .= static::$LE;
                $body .= $this->getBoundary(
                    $this->boundary[2],
                    $altBodyCharSet,
                    static::CONTENT_TYPE_PLAINTEXT,
                    $altBodyEncoding
                );
                $body .= $this->encodeString($this->AltBody, $altBodyEncoding);
                $body .= static::$LE;
                $body .= $this->textLine('--' . $this->boundary[2]);
                $body .= $this->headerLine('Content-Type', static::CONTENT_TYPE_MULTIPART_RELATED . ';');
                $body .= $this->textLine(' boundary="' . $this->boundary[3] . '";');
                $body .= $this->textLine(' type="' . static::CONTENT_TYPE_TEXT_HTML . '"');
                $body .= static::$LE;
                $body .= $this->getBoundary(
                    $this->boundary[3],
                    $bodyCharSet,
                    static::CONTENT_TYPE_TEXT_HTML,
                    $bodyEncoding
                );
                $body .= $this->encodeString($this->Body, $bodyEncoding);
                $body .= static::$LE;
                $body .= $this->attachAll('inline', $this->boundary[3]);
                $body .= static::$LE;
                $body .= $this->endBoundary($this->boundary[2]);
                $body .= static::$LE;
                $body .= $this->attachAll('attachment', $this->boundary[1]);
                break;
            default:
                //Catch case 'plain' and case '', applies to simple `text/plain` and `text/html` body content types
                //Reset the `Encoding` property in case we changed it for line length reasons
                $this->Encoding = $bodyEncoding;
                $body .= $this->encodeString($this->Body, $this->Encoding);
                break;
        }

        if ($this->isError()) {
            $body = '';
            if ($this->exceptions) {
                throw new Exception(self::lang('empty_message'), self::STOP_CRITICAL);
            }
        } elseif ($this->sign_key_file) {
            try {
                if (!defined('PKCS7_TEXT')) {
                    throw new Exception(self::lang('extension_missing') . 'openssl');
                }

                $file = tempnam(sys_get_temp_dir(), 'srcsign');
                $signed = tempnam(sys_get_temp_dir(), 'mailsign');
                file_put_contents($file, $body);

                //Workaround for PHP bug https://bugs.php.net/bug.php?id=69197
                if (empty($this->sign_extracerts_file)) {
                    $sign = @openssl_pkcs7_sign(
                        $file,
                        $signed,
                        'file://' . realpath($this->sign_cert_file),
                        ['file://' . realpath($this->sign_key_file), $this->sign_key_pass],
                        []
                    );
                } else {
                    $sign = @openssl_pkcs7_sign(
                        $file,
                        $signed,
                        'file://' . realpath($this->sign_cert_file),
                        ['file://' . realpath($this->sign_key_file), $this->sign_key_pass],
                        [],
                        PKCS7_DETACHED,
                        $this->sign_extracerts_file
                    );
                }

                @unlink($file);
                if ($sign) {
                    $body = file_get_contents($signed);
                    @unlink($signed);
                    //The message returned by openssl contains both headers and body, so need to split them up
                    $parts = explode("\n\n", $body, 2);
                    $this->MIMEHeader .= $parts[0] . static::$LE . static::$LE;
                    $body = $parts[1];
                } else {
                    @unlink($signed);
                    throw new Exception(self::lang('signing') . openssl_error_string());
                }
            } catch (Exception $exc) {
                $body = '';
                if ($this->exceptions) {
                    throw $exc;
                }
            }
        }

        return $body;
    }

    /**
     * Get the boundaries that this message will use
     * @return array
     */
    public function getBoundaries()
    {
        if (empty($this->boundary)) {
            $this->setBoundaries();
        }
        return $this->boundary;
    }

    /**
     * Return the start of a message boundary.
     *
     * @param string $boundary
     * @param string $charSet
     * @param string $contentType
     * @param string $encoding
     *
     * @return string
     */
    protected function getBoundary($boundary, $charSet, $contentType, $encoding)
    {
        $result = '';
        if ('' === $charSet) {
            $charSet = $this->CharSet;
        }
        if ('' === $contentType) {
            $contentType = $this->ContentType;
        }
        if ('' === $encoding) {
            $encoding = $this->Encoding;
        }
        $result .= $this->textLine('--' . $boundary);
        $result .= sprintf('Content-Type: %s; charset=%s', $contentType, $charSet);
        $result .= static::$LE;
        //RFC1341 part 5 says 7bit is assumed if not specified
        if (static::ENCODING_7BIT !== $encoding) {
            $result .= $this->headerLine('Content-Transfer-Encoding', $encoding);
        }
        $result .= static::$LE;

        return $result;
    }

    /**
     * Return the end of a message boundary.
     *
     * @param string $boundary
     *
     * @return string
     */
    protected function endBoundary($boundary)
    {
        return static::$LE . '--' . $boundary . '--' . static::$LE;
    }

    /**
     * Set the message type.
     * PHPMailer only supports some preset message types, not arbitrary MIME structures.
     */
    protected function setMessageType()
    {
        $type = [];
        if ($this->alternativeExists()) {
            $type[] = 'alt';
        }
        if ($this->inlineImageExists()) {
            $type[] = 'inline';
        }
        if ($this->attachmentExists()) {
            $type[] = 'attach';
        }
        $this->message_type = implode('_', $type);
        if ('' === $this->message_type) {
            //The 'plain' message_type refers to the message having a single body element, not that it is plain-text
            $this->message_type = 'plain';
        }
    }

    /**
     * Format a header line.
     *
     * @param string     $name
     * @param string|int $value
     *
     * @return string
     */
    public function headerLine($name, $value)
    {
        return $name . ': ' . $value . static::$LE;
    }

    /**
     * Return a formatted mail line.
     *
     * @param string $value
     *
     * @return string
     */
    public function textLine($value)
    {
        return $value . static::$LE;
    }

    /**
     * Add an attachment from a path on the filesystem.
     * Never use a user-supplied path to a file!
     * Returns false if the file could not be found or read.
     * Explicitly *does not* support passing URLs; PHPMailer is not an HTTP client.
     * If you need to do that, fetch the resource yourself and pass it in via a local file or string.
     *
     * @param string $path        Path to the attachment
     * @param string $name        Overrides the attachment name
     * @param string $encoding    File encoding (see $Encoding)
     * @param string $type        MIME type, e.g. `image/jpeg`; determined automatically from $path if not specified
     * @param string $disposition Disposition to use
     *
     * @throws Exception
     *
     * @return bool
     */
    public function addAttachment(
        $path,
        $name = '',
        $encoding = self::ENCODING_BASE64,
        $type = '',
        $disposition = 'attachment'
    ) {
        try {
            if (!static::fileIsAccessible($path)) {
                throw new Exception(self::lang('file_access') . $path, self::STOP_CONTINUE);
            }

            //If a MIME type is not specified, try to work it out from the file name
            if ('' === $type) {
                $type = static::filenameToType($path);
            }

            $filename = (string) static::mb_pathinfo($path, PATHINFO_BASENAME);
            if ('' === $name) {
                $name = $filename;
            }
            if (!$this->validateEncoding($encoding)) {
                throw new Exception(self::lang('encoding') . $encoding);
            }

            $this->attachment[] = [
                0 => $path,
                1 => $filename,
                2 => $name,
                3 => $encoding,
                4 => $type,
                5 => false, //isStringAttachment
                6 => $disposition,
                7 => $name,
            ];
        } catch (Exception $exc) {
            $this->setError($exc->getMessage());
            $this->edebug($exc->getMessage());
            if ($this->exceptions) {
                throw $exc;
            }

            return false;
        }

        return true;
    }

    /**
     * Return the array of attachments.
     *
     * @return array
     */
    public function getAttachments()
    {
        return $this->attachment;
    }

    /**
     * Attach all file, string, and binary attachments to the message.
     * Returns an empty string on failure.
     *
     * @param string $disposition_type
     * @param string $boundary
     *
     * @throws Exception
     *
     * @return string
     */
    protected function attachAll($disposition_type, $boundary)
    {
        //Return text of body
        $mime = [];
        $cidUniq = [];
        $incl = [];

        //Add all attachments
        foreach ($this->attachment as $attachment) {
            //Check if it is a valid disposition_filter
            if ($attachment[6] === $disposition_type) {
                //Check for string attachment
                $string = '';
                $path = '';
                $bString = $attachment[5];
                if ($bString) {
                    $string = $attachment[0];
                } else {
                    $path = $attachment[0];
                }

                $inclhash = hash('sha256', serialize($attachment));
                if (in_array($inclhash, $incl, true)) {
                    continue;
                }
                $incl[] = $inclhash;
                $name = $attachment[2];
                $encoding = $attachment[3];
                $type = $attachment[4];
                $disposition = $attachment[6];
                $cid = $attachment[7];
                if ('inline' === $disposition && array_key_exists($cid, $cidUniq)) {
                    continue;
                }
                $cidUniq[$cid] = true;

                $mime[] = sprintf('--%s%s', $boundary, static::$LE);
                //Only include a filename property if we have one
                if (!empty($name)) {
                    $mime[] = sprintf(
                        'Content-Type: %s; name=%s%s',
                        $type,
                        static::quotedString($this->encodeHeader($this->secureHeader($name))),
                        static::$LE
                    );
                } else {
                    $mime[] = sprintf(
                        'Content-Type: %s%s',
                        $type,
                        static::$LE
                    );
                }
                //RFC1341 part 5 says 7bit is assumed if not specified
                if (static::ENCODING_7BIT !== $encoding) {
                    $mime[] = sprintf('Content-Transfer-Encoding: %s%s', $encoding, static::$LE);
                }

                //Only set Content-IDs on inline attachments
                if ((string) $cid !== '' && $disposition === 'inline') {
                    $mime[] = 'Content-ID: <' . $this->encodeHeader($this->secureHeader($cid)) . '>' . static::$LE;
                }

                //Allow for bypassing the Content-Disposition header
                if (!empty($disposition)) {
                    $encoded_name = $this->encodeHeader($this->secureHeader($name));
                    if (!empty($encoded_name)) {
                        $mime[] = sprintf(
                            'Content-Disposition: %s; filename=%s%s',
                            $disposition,
                            static::quotedString($encoded_name),
                            static::$LE . static::$LE
                        );
                    } else {
                        $mime[] = sprintf(
                            'Content-Disposition: %s%s',
                            $disposition,
                            static::$LE . static::$LE
                        );
                    }
                } else {
                    $mime[] = static::$LE;
                }

                //Encode as string attachment
                if ($bString) {
                    $mime[] = $this->encodeString($string, $encoding);
                } else {
                    $mime[] = $this->encodeFile($path, $encoding);
                }
                if ($this->isError()) {
                    return '';
                }
                $mime[] = static::$LE;
            }
        }

        $mime[] = sprintf('--%s--%s', $boundary, static::$LE);

        return implode('', $mime);
    }

    /**
     * Encode a file attachment in requested format.
     * Returns an empty string on failure.
     *
     * @param string $path     The full path to the file
     * @param string $encoding The encoding to use; one of 'base64', '7bit', '8bit', 'binary', 'quoted-printable'
     *
     * @return string
     */
    protected function encodeFile($path, $encoding = self::ENCODING_BASE64)
    {
        try {
            if (!static::fileIsAccessible($path)) {
                throw new Exception(self::lang('file_open') . $path, self::STOP_CONTINUE);
            }
            $file_buffer = file_get_contents($path);
            if (false === $file_buffer) {
                throw new Exception(self::lang('file_open') . $path, self::STOP_CONTINUE);
            }
            $file_buffer = $this->encodeString($file_buffer, $encoding);

            return $file_buffer;
        } catch (Exception $exc) {
            $this->setError($exc->getMessage());
            $this->edebug($exc->getMessage());
            if ($this->exceptions) {
                throw $exc;
            }

            return '';
        }
    }

    /**
     * Encode a string in requested format.
     * Returns an empty string on failure.
     *
     * @param string $str      The text to encode
     * @param string $encoding The encoding to use; one of 'base64', '7bit', '8bit', 'binary', 'quoted-printable'
     *
     * @throws Exception
     *
     * @return string
     */
    public function encodeString($str, $encoding = self::ENCODING_BASE64)
    {
        $encoded = '';
        switch (strtolower($encoding)) {
            case static::ENCODING_BASE64:
                $encoded = chunk_split(
                    base64_encode($str),
                    static::STD_LINE_LENGTH,
                    static::$LE
                );
                break;
            case static::ENCODING_7BIT:
            case static::ENCODING_8BIT:
                $encoded = static::normalizeBreaks($str);
                //Make sure it ends with a line break
                if (substr($encoded, -(strlen(static::$LE))) !== static::$LE) {
                    $encoded .= static::$LE;
                }
                break;
            case static::ENCODING_BINARY:
                $encoded = $str;
                break;
            case static::ENCODING_QUOTED_PRINTABLE:
                $encoded = $this->encodeQP($str);
                break;
            default:
                $this->setError(self::lang('encoding') . $encoding);
                if ($this->exceptions) {
                    throw new Exception(self::lang('encoding') . $encoding);
                }
                break;
        }

        return $encoded;
    }

    /**
     * Encode a header value (not including its label) optimally.
     * Picks shortest of Q, B, or none. Result includes folding if needed.
     * See RFC822 definitions for phrase, comment and text positions,
     * and RFC2047 for inline encodings.
     *
     * @param string $str      The header value to encode
     * @param string $position What context the string will be used in
     *
     * @return string
     */
    public function encodeHeader($str, $position = 'text')
    {
        $position = strtolower($position);
        if ($this->UseSMTPUTF8 && !("comment" === $position)) {
            return trim(static::normalizeBreaks($str));
        }

        $matchcount = 0;
        switch (strtolower($position)) {
            case 'phrase':
                if (!preg_match('/[\200-\377]/', $str)) {
                    //Can't use addslashes as we don't know the value of magic_quotes_sybase
                    $encoded = addcslashes($str, "\0..\37\177\\\"");
                    if (($str === $encoded) && !preg_match('/[^A-Za-z0-9!#$%&\'*+\/=?^_`{|}~ -]/', $str)) {
                        return $encoded;
                    }

                    return "\"$encoded\"";
                }
                $matchcount = preg_match_all('/[^\040\041\043-\133\135-\176]/', $str, $matches);
                break;
            /* @noinspection PhpMissingBreakStatementInspection */
            case 'comment':
                $matchcount = preg_match_all('/[()"]/', $str, $matches);
            //fallthrough
            case 'text':
            default:
                $matchcount += preg_match_all('/[\000-\010\013\014\016-\037\177-\377]/', $str, $matches);
                break;
        }

        if ($this->has8bitChars($str)) {
            $charset = $this->CharSet;
        } else {
            $charset = static::CHARSET_ASCII;
        }

        //Q/B encoding adds 8 chars and the charset ("` =?<charset>?[QB]?<content>?=`").
        $overhead = 8 + strlen($charset);

        if ('mail' === $this->Mailer) {
            $maxlen = static::MAIL_MAX_LINE_LENGTH - $overhead;
        } else {
            $maxlen = static::MAX_LINE_LENGTH - $overhead;
        }

        //Select the encoding that produces the shortest output and/or prevents corruption.
        if ($matchcount > strlen($str) / 3) {
            //More than 1/3 of the content needs encoding, use B-encode.
            $encoding = 'B';
        } elseif ($matchcount > 0) {
            //Less than 1/3 of the content needs encoding, use Q-encode.
            $encoding = 'Q';
        } elseif (strlen($str) > $maxlen) {
            //No encoding needed, but value exceeds max line length, use Q-encode to prevent corruption.
            $encoding = 'Q';
        } else {
            //No reformatting needed
            $encoding = false;
        }

        switch ($encoding) {
            case 'B':
                if ($this->hasMultiBytes($str)) {
                    //Use a custom function which correctly encodes and wraps long
                    //multibyte strings without breaking lines within a character
                    $encoded = $this->base64EncodeWrapMB($str, "\n");
                } else {
                    $encoded = base64_encode($str);
                    $maxlen -= $maxlen % 4;
                    $encoded = trim(chunk_split($encoded, $maxlen, "\n"));
                }
                $encoded = preg_replace('/^(.*)$/m', ' =?' . $charset . "?$encoding?\\1?=", $encoded);
                break;
            case 'Q':
                $encoded = $this->encodeQ($str, $position);
                $encoded = $this->wrapText($encoded, $maxlen, true);
                $encoded = str_replace('=' . static::$LE, "\n", trim($encoded));
                $encoded = preg_replace('/^(.*)$/m', ' =?' . $charset . "?$encoding?\\1?=", $encoded);
                break;
            default:
                return $str;
        }

        return trim(static::normalizeBreaks($encoded));
    }

    /**
     * Decode an RFC2047-encoded header value
     * Attempts multiple strategies so it works even when the mbstring extension is disabled.
     *
     * @param string $value   The header value to decode
     * @param string $charset The target charset to convert to, defaults to ISO-8859-1 for BC
     *
     * @return string The decoded header value
     */
    public static function decodeHeader($value, $charset = self::CHARSET_ISO88591)
    {
        if (!is_string($value) || $value === '') {
            return '';
        }
        // Detect the presence of any RFC2047 encoded-words
        $hasEncodedWord = (bool) preg_match('/=\?.*\?=/s', $value);
        if ($hasEncodedWord && defined('MB_CASE_UPPER')) {
            $origCharset = mb_internal_encoding();
            // Always decode to UTF-8 to provide a consistent, modern output encoding.
            mb_internal_encoding($charset);
            if (PHP_VERSION_ID < 80300) {
                // Undo any RFC2047-encoded spaces-as-underscores.
                $value = str_replace('_', '=20', $value);
            } else {
                // PHP 8.3+ already interprets underscores as spaces. Remove additional
                // linear whitespace between adjacent encoded words to avoid double spacing.
                $value = preg_replace('/(\?=)\s+(=\?)/', '$1$2', $value);
            }
            // Decode the header value
            $value = mb_decode_mimeheader($value);
            mb_internal_encoding($origCharset);
        }

        return $value;
    }

    /**
     * Check if a string contains multi-byte characters.
     *
     * @param string $str multi-byte text to wrap encode
     *
     * @return bool
     */
    public function hasMultiBytes($str)
    {
        if (function_exists('mb_strlen')) {
            return strlen($str) > mb_strlen($str, $this->CharSet);
        }

        //Assume no multibytes (we can't handle without mbstring functions anyway)
        return false;
    }

    /**
     * Does a string contain any 8-bit chars (in any charset)?
     *
     * @param string $text
     *
     * @return bool
     */
    public function has8bitChars($text)
    {
        return (bool) preg_match('/[\x80-\xFF]/', $text);
    }

    /**
     * Encode and wrap long multibyte strings for mail headers
     * without breaking lines within a character.
     * Adapted from a function by paravoid.
     *
     * @see https://www.php.net/manual/en/function.mb-encode-mimeheader.php#60283
     *
     * @param string $str       multi-byte text to wrap encode
     * @param string $linebreak string to use as linefeed/end-of-line
     *
     * @return string
     */
    public function base64EncodeWrapMB($str, $linebreak = null)
    {
        $start = '=?' . $this->CharSet . '?B?';
        $end = '?=';
        $encoded = '';
        if (null === $linebreak) {
            $linebreak = static::$LE;
        }

        $mb_length = mb_strlen($str, $this->CharSet);
        //Each line must have length <= 75, including $start and $end
        $length = 75 - strlen($start) - strlen($end);
        //Average multi-byte ratio
        $ratio = $mb_length / strlen($str);
        //Base64 has a 4:3 ratio
        $avgLength = floor($length * $ratio * .75);

        $offset = 0;
        for ($i = 0; $i < $mb_length; $i += $offset) {
            $lookBack = 0;
            do {
                $offset = $avgLength - $lookBack;
                $chunk = mb_substr($str, $i, $offset, $this->CharSet);
                $chunk = base64_encode($chunk);
                ++$lookBack;
            } while (strlen($chunk) > $length);
            $encoded .= $chunk . $linebreak;
        }

        //Chomp the last linefeed
        return substr($encoded, 0, -strlen($linebreak));
    }

    /**
     * Encode a string in quoted-printable format.
     * According to RFC2045 section 6.7.
     *
     * @param string $string The text to encode
     *
     * @return string
     */
    public function encodeQP($string)
    {
        return static::normalizeBreaks(quoted_printable_encode($string));
    }

    /**
     * Encode a string using Q encoding.
     *
     * @see https://www.rfc-editor.org/rfc/rfc2047#section-4.2
     *
     * @param string $str      the text to encode
     * @param string $position Where the text is going to be used, see the RFC for what that means
     *
     * @return string
     */
    public function encodeQ($str, $position = 'text')
    {
        //There should not be any EOL in the string
        $pattern = '';
        $encoded = str_replace(["\r", "\n"], '', $str);
        switch (strtolower($position)) {
            case 'phrase':
                //RFC 2047 section 5.3
                $pattern = '^A-Za-z0-9!*+\/ -';
                break;
            /*
             * RFC 2047 section 5.2.
             * Build $pattern without including delimiters and []
             */
            /* @noinspection PhpMissingBreakStatementInspection */
            case 'comment':
                $pattern = '\(\)"';
            /* Intentional fall through */
            case 'text':
            default:
                //RFC 2047 section 5.1
                //Replace every high ascii, control, =, ? and _ characters
                $pattern = '\000-\011\013\014\016-\037\075\077\137\177-\377' . $pattern;
                break;
        }
        $matches = [];
        if (preg_match_all("/[{$pattern}]/", $encoded, $matches)) {
            //If the string contains an '=', make sure it's the first thing we replace
            //so as to avoid double-encoding
            $eqkey = array_search('=', $matches[0], true);
            if (false !== $eqkey) {
                unset($matches[0][$eqkey]);
                array_unshift($matches[0], '=');
            }
            foreach (array_unique($matches[0]) as $char) {
                $encoded = str_replace($char, '=' . sprintf('%02X', ord($char)), $encoded);
            }
        }
        //Replace spaces with _ (more readable than =20)
        //RFC 2047 section 4.2(2)
        return str_replace(' ', '_', $encoded);
    }

    /**
     * Add a string or binary attachment (non-filesystem).
     * This method can be used to attach ascii or binary data,
     * such as a BLOB record from a database.
     *
     * @param string $string      String attachment data
     * @param string $filename    Name of the attachment
     * @param string $encoding    File encoding (see $Encoding)
     * @param string $type        File extension (MIME) type
     * @param string $disposition Disposition to use
     *
     * @throws Exception
     *
     * @return bool True on successfully adding an attachment
     */
    public function addStringAttachment(
        $string,
        $filename,
        $encoding = self::ENCODING_BASE64,
        $type = '',
        $disposition = 'attachment'
    ) {
        try {
            //If a MIME type is not specified, try to work it out from the file name
            if ('' === $type) {
                $type = static::filenameToType($filename);
            }

            if (!$this->validateEncoding($encoding)) {
                throw new Exception(self::lang('encoding') . $encoding);
            }

            //Append to $attachment array
            $this->attachment[] = [
                0 => $string,
                1 => $filename,
                2 => static::mb_pathinfo($filename, PATHINFO_BASENAME),
                3 => $encoding,
                4 => $type,
                5 => true, //isStringAttachment
                6 => $disposition,
                7 => 0,
            ];
        } catch (Exception $exc) {
            $this->setError($exc->getMessage());
            $this->edebug($exc->getMessage());
            if ($this->exceptions) {
                throw $exc;
            }

            return false;
        }

        return true;
    }

    /**
     * Add an embedded (inline) attachment from a file.
     * This can include images, sounds, and just about any other document type.
     * These differ from 'regular' attachments in that they are intended to be
     * displayed inline with the message, not just attached for download.
     * This is used in HTML messages that embed the images
     * the HTML refers to using the `$cid` value in `img` tags, for example `<img src="cid:mylogo">`.
     * Never use a user-supplied path to a file!
     *
     * @param string $path        Path to the attachment
     * @param string $cid         Content ID of the attachment; Use this to reference
     *                            the content when using an embedded image in HTML
     * @param string $name        Overrides the attachment filename
     * @param string $encoding    File encoding (see $Encoding) defaults to `base64`
     * @param string $type        File MIME type (by default mapped from the `$path` filename's extension)
     * @param string $disposition Disposition to use: `inline` (default) or `attachment`
     *                            (unlikely you want this â€“ {@see `addAttachment()`} instead)
     *
     * @return bool True on successfully adding an attachment
     * @throws Exception
     *
     */
    public function addEmbeddedImage(
        $path,
        $cid,
        $name = '',
        $encoding = self::ENCODING_BASE64,
        $type = '',
        $disposition = 'inline'
    ) {
        try {
            if (!static::fileIsAccessible($path)) {
                throw new Exception(self::lang('file_access') . $path, self::STOP_CONTINUE);
            }

            //If a MIME type is not specified, try to work it out from the file name
            if ('' === $type) {
                $type = static::filenameToType($path);
            }

            if (!$this->validateEncoding($encoding)) {
                throw new Exception(self::lang('encoding') . $encoding);
            }

            $filename = (string) static::mb_pathinfo($path, PATHINFO_BASENAME);
            if ('' === $name) {
                $name = $filename;
            }

            //Append to $attachment array
            $this->attachment[] = [
                0 => $path,
                1 => $filename,
                2 => $name,
                3 => $encoding,
                4 => $type,
                5 => false, //isStringAttachment
                6 => $disposition,
                7 => $cid,
            ];
        } catch (Exception $exc) {
            $this->setError($exc->getMessage());
            $this->edebug($exc->getMessage());
            if ($this->exceptions) {
                throw $exc;
            }

            return false;
        }

        return true;
    }

    /**
     * Add an embedded stringified attachment.
     * This can include images, sounds, and just about any other document type.
     * If your filename doesn't contain an extension, be sure to set the $type to an appropriate MIME type.
     *
     * @param string $string      The attachment binary data
     * @param string $cid         Content ID of the attachment; Use this to reference
     *                            the content when using an embedded image in HTML
     * @param string $name        A filename for the attachment. If this contains an extension,
     *                            PHPMailer will attempt to set a MIME type for the attachment.
     *                            For example 'file.jpg' would get an 'image/jpeg' MIME type.
     * @param string $encoding    File encoding (see $Encoding), defaults to 'base64'
     * @param string $type        MIME type - will be used in preference to any automatically derived type
     * @param string $disposition Disposition to use
     *
     * @throws Exception
     *
     * @return bool True on successfully adding an attachment
     */
    public function addStringEmbeddedImage(
        $string,
        $cid,
        $name = '',
        $encoding = self::ENCODING_BASE64,
        $type = '',
        $disposition = 'inline'
    ) {
        try {
            //If a MIME type is not specified, try to work it out from the name
            if ('' === $type && !empty($name)) {
                $type = static::filenameToType($name);
            }

            if (!$this->validateEncoding($encoding)) {
                throw new Exception(self::lang('encoding') . $encoding);
            }

            //Append to $attachment array
            $this->attachment[] = [
                0 => $string,
                1 => $name,
                2 => $name,
                3 => $encoding,
                4 => $type,
                5 => true, //isStringAttachment
                6 => $disposition,
                7 => $cid,
            ];
        } catch (Exception $exc) {
            $this->setError($exc->getMessage());
            $this->edebug($exc->getMessage());
            if ($this->exceptions) {
                throw $exc;
            }

            return false;
        }

        return true;
    }

    /**
     * Validate encodings.
     *
     * @param string $encoding
     *
     * @return bool
     */
    protected function validateEncoding($encoding)
    {
        return in_array(
            strtolower($encoding),
            [
                self::ENCODING_7BIT,
                self::ENCODING_QUOTED_PRINTABLE,
                self::ENCODING_BASE64,
                self::ENCODING_8BIT,
                self::ENCODING_BINARY,
            ],
            true
        );
    }

    /**
     * Check if an embedded attachment is present with this cid.
     *
     * @param string $cid
     *
     * @return bool
     */
    protected function cidExists($cid)
    {
        foreach ($this->attachment as $attachment) {
            if ('inline' === $attachment[6] && $cid === $attachment[7]) {
                return true;
            }
        }

        return false;
    }

    /**
     * Check if an inline attachment is present.
     *
     * @return bool
     */
    public function inlineImageExists()
    {
        foreach ($this->attachment as $attachment) {
            if ('inline' === $attachment[6]) {
                return true;
            }
        }

        return false;
    }

    /**
     * Check if an attachment (non-inline) is present.
     *
     * @return bool
     */
    public function attachmentExists()
    {
        foreach ($this->attachment as $attachment) {
            if ('attachment' === $attachment[6]) {
                return true;
            }
        }

        return false;
    }

    /**
     * Check if this message has an alternative body set.
     *
     * @return bool
     */
    public function alternativeExists()
    {
        return !empty($this->AltBody);
    }

    /**
     * Clear queued addresses of given kind.
     *
     * @param string $kind 'to', 'cc', or 'bcc'
     */
    public function clearQueuedAddresses($kind)
    {
        $this->RecipientsQueue = array_filter(
            $this->RecipientsQueue,
            static function ($params) use ($kind) {
                return $params[0] !== $kind;
            }
        );
    }

    /**
     * Clear all To recipients.
     */
    public function clearAddresses()
    {
        foreach ($this->to as $to) {
            unset($this->all_recipients[strtolower($to[0])]);
        }
        $this->to = [];
        $this->clearQueuedAddresses('to');
    }

    /**
     * Clear all CC recipients.
     */
    public function clearCCs()
    {
        foreach ($this->cc as $cc) {
            unset($this->all_recipients[strtolower($cc[0])]);
        }
        $this->cc = [];
        $this->clearQueuedAddresses('cc');
    }

    /**
     * Clear all BCC recipients.
     */
    public function clearBCCs()
    {
        foreach ($this->bcc as $bcc) {
            unset($this->all_recipients[strtolower($bcc[0])]);
        }
        $this->bcc = [];
        $this->clearQueuedAddresses('bcc');
    }

    /**
     * Clear all ReplyTo recipients.
     */
    public function clearReplyTos()
    {
        $this->ReplyTo = [];
        $this->ReplyToQueue = [];
    }

    /**
     * Clear all recipient types.
     */
    public function clearAllRecipients()
    {
        $this->to = [];
        $this->cc = [];
        $this->bcc = [];
        $this->all_recipients = [];
        $this->RecipientsQueue = [];
    }

    /**
     * Clear all filesystem, string, and binary attachments.
     */
    public function clearAttachments()
    {
        $this->attachment = [];
    }

    /**
     * Clear all custom headers.
     */
    public function clearCustomHeaders()
    {
        $this->CustomHeader = [];
    }

    /**
     * Clear a specific custom header by name or name and value.
     * $name value can be overloaded to contain
     * both header name and value (name:value).
     *
     * @param string      $name  Custom header name
     * @param string|null $value Header value
     *
     * @return bool True if a header was replaced successfully
     */
    public function clearCustomHeader($name, $value = null)
    {
        if (null === $value && strpos($name, ':') !== false) {
            //Value passed in as name:value
            list($name, $value) = explode(':', $name, 2);
        }
        $name = trim($name);
        $value = (null === $value) ? null : trim($value);

        foreach ($this->CustomHeader as $k => $pair) {
            if ($pair[0] == $name) {
                // We remove the header if the value is not provided or it matches.
                if (null === $value ||  $pair[1] == $value) {
                    unset($this->CustomHeader[$k]);
                }
            }
        }

        return true;
    }

    /**
     * Replace a custom header.
     * $name value can be overloaded to contain
     * both header name and value (name:value).
     *
     * @param string      $name  Custom header name
     * @param string|null $value Header value
     *
     * @return bool True if a header was replaced successfully
     * @throws Exception
     */
    public function replaceCustomHeader($name, $value = null)
    {
        if (null === $value && strpos($name, ':') !== false) {
            //Value passed in as name:value
            list($name, $value) = explode(':', $name, 2);
        }
        $name = trim($name);
        $value = (null === $value) ? '' : trim($value);

        $replaced = false;
        foreach ($this->CustomHeader as $k => $pair) {
            if ($pair[0] == $name) {
                if ($replaced) {
                    unset($this->CustomHeader[$k]);
                    continue;
                }
                if (strpbrk($name . $value, "\r\n") !== false) {
                    if ($this->exceptions) {
                        throw new Exception(self::lang('invalid_header'));
                    }

                    return false;
                }
                $this->CustomHeader[$k] = [$name, $value];
                $replaced = true;
            }
        }

        return true;
    }

    /**
     * Add an error message to the error container.
     *
     * @param string $msg
     */
    protected function setError($msg)
    {
        ++$this->error_count;
        if ('smtp' === $this->Mailer && null !== $this->smtp) {
            $lasterror = $this->smtp->getError();
            if (!empty($lasterror['error'])) {
                $msg .= ' ' . self::lang('smtp_error') . $lasterror['error'];
                if (!empty($lasterror['detail'])) {
                    $msg .= ' ' . self::lang('smtp_detail') . $lasterror['detail'];
                }
                if (!empty($lasterror['smtp_code'])) {
                    $msg .= ' ' . self::lang('smtp_code') . $lasterror['smtp_code'];
                }
                if (!empty($lasterror['smtp_code_ex'])) {
                    $msg .= ' ' . self::lang('smtp_code_ex') . $lasterror['smtp_code_ex'];
                }
            }
        }
        $this->ErrorInfo = $msg;
    }

    /**
     * Return the current date and time as an RFC 822 formatted date.
     *
     * @return string
     */
    public static function rfcDate()
    {
        //Set the time zone to whatever the default is to avoid 500 errors
        //Will default to UTC if it's not set properly in php.ini
        date_default_timezone_set(@date_default_timezone_get());

        return date(self::RFC822_DATE_FORMAT);
    }

    /**
     * Normalise a user-supplied date into a correctly-formatted RFC 5322 date value
     * string suitable for use in the Date header.
     *
     * Accepts:
     *  - A {@see \DateTime} (or \DateTimeImmutable) object
     *  - Any date/time string understood by PHP's DateTime constructor (RFC 5322, ISO 8601,
     *    Unix timestamp with leading "@", natural-language strings, etc.)
     *
     * Dates in the future are not permitted for email headers; if the parsed date is later
     * than "now" the method falls back to the current time via {@see self::rfcDate()}.
     * An empty value, a non-string/non-DateTime argument, or any value that cannot be
     * parsed will likewise fall back to {@see self::rfcDate()}.
     *
     * @param \DateTime|\DateTimeImmutable|string $date The date to normalise
     *
     * @return string An RFC 5322-formatted date string
     */
    private static function sanitiseDate($date)
    {
        try {
            //Ensure the default timezone is set properly
            date_default_timezone_set(@date_default_timezone_get());

            if ($date instanceof \DateTimeInterface) {
                $dt = $date;
            } elseif (is_string($date) && $date !== '') {
                $dt = new \DateTime($date);
            } else {
                //Empty string, null, or any unsupported type
                return self::rfcDate();
            }

            //Reject future dates â€” they are invalid for outgoing message headers
            if ($dt->getTimestamp() > time()) {
                return self::rfcDate();
            }

            return $dt->format(self::RFC822_DATE_FORMAT);
        } catch (\Exception $e) {
            return self::rfcDate();
        }
    }

    /**
     * Get the server hostname.
     * Returns 'localhost.localdomain' if unknown.
     *
     * @return string
     */
    protected function serverHostname()
    {
        $result = '';
        if (!empty($this->Hostname)) {
            $result = $this->Hostname;
        } elseif (isset($_SERVER) && array_key_exists('SERVER_NAME', $_SERVER)) {
            $result = $_SERVER['SERVER_NAME'];
        } elseif (function_exists('gethostname') && gethostname() !== false) {
            $result = gethostname();
        } elseif (php_uname('n') !== '') {
            $result = php_uname('n');
        }
        if (!static::isValidHost($result)) {
            return 'localhost.localdomain';
        }

        return $result;
    }

    /**
     * Validate whether a string contains a valid value to use as a hostname or IP address.
     * IPv6 addresses must include [], e.g. `[::1]`, not just `::1`.
     *
     * @param string $host The host name or IP address to check
     *
     * @return bool
     */
    public static function isValidHost($host)
    {
        //Simple syntax limits
        if (
            empty($host)
            || !is_string($host)
            || strlen($host) > 256
            || !preg_match('/^([a-z\d.-]*|\[[a-f\d:]+\])$/i', $host)
        ) {
            return false;
        }
        //Looks like a bracketed IPv6 address
        if (strlen($host) > 2 && substr($host, 0, 1) === '[' && substr($host, -1, 1) === ']') {
            return filter_var(substr($host, 1, -1), FILTER_VALIDATE_IP, FILTER_FLAG_IPV6) !== false;
        }
        //If removing all the dots results in a numeric string, it must be an IPv4 address.
        //Need to check this first because otherwise things like `999.0.0.0` are considered valid host names
        if (is_numeric(str_replace('.', '', $host))) {
            //Is it a valid IPv4 address?
            return filter_var($host, FILTER_VALIDATE_IP, FILTER_FLAG_IPV4) !== false;
        }
        //Is it a syntactically valid hostname (when embedded in a URL)?
        return filter_var('https://' . $host, FILTER_VALIDATE_URL) !== false;
    }

    /**
     * Check whether the supplied address uses Unicode in the local part.
     *
     * @return bool
     */
    protected function addressHasUnicodeLocalPart($address)
    {
        return (bool) preg_match('/[\x80-\xFF].*@/', $address);
    }

    /**
     * Check whether any of the supplied addresses use Unicode in the local part.
     *
     * @return bool
     */
    protected function anyAddressHasUnicodeLocalPart($addresses)
    {
        foreach ($addresses as $address) {
            if (is_array($address)) {
                $address = $address[0];
            }
            if ($this->addressHasUnicodeLocalPart($address)) {
                return true;
            }
        }
        return false;
    }

    /**
     * Check whether the message requires SMTPUTF8 based on what's known so far.
     *
     * @return bool
     */
    public function needsSMTPUTF8()
    {
        return $this->UseSMTPUTF8;
    }


    /**
     * Get an error message in the current language.
     *
     * @param string $key
     *
     * @return string
     */
    protected static function lang($key)
    {
        if (count(self::$language) < 1) {
            self::setLanguage(); //Set the default language
        }

        if (array_key_exists($key, self::$language)) {
            if ('smtp_connect_failed' === $key) {
                //Include a link to troubleshooting docs on SMTP connection failure.
                //This is by far the biggest cause of support questions
                //but it's usually not PHPMailer's fault.
                return self::$language[$key] . ' https://github.com/PHPMailer/PHPMailer/wiki/Troubleshooting';
            }

            return self::$language[$key];
        }

        //Return the key as a fallback
        return $key;
    }

    /**
     * Build an error message starting with a generic one and adding details if possible.
     *
     * @param string $base_key
     * @return string
     */
    private function getSmtpErrorMessage($base_key)
    {
        $message = self::lang($base_key);
        $error = $this->smtp->getError();
        if (!empty($error['error'])) {
            $message .= ' ' . $error['error'];
            if (!empty($error['detail'])) {
                $message .= ' ' . $error['detail'];
            }
        }

        return $message;
    }

    /**
     * Check if an error occurred.
     *
     * @return bool True if an error did occur
     */
    public function isError()
    {
        return $this->error_count > 0;
    }

    /**
     * Add a custom header.
     * $name value can be overloaded to contain
     * both header name and value (name:value).
     *
     * @param string      $name  Custom header name
     * @param string|null $value Header value
     *
     * @return bool True if a header was set successfully
     * @throws Exception
     */
    public function addCustomHeader($name, $value = null)
    {
        if (null === $value && strpos($name, ':') !== false) {
            //Value passed in as name:value
            list($name, $value) = explode(':', $name, 2);
        }
        $name = trim($name);
        $value = (null === $value) ? '' : trim($value);
        //Ensure name is not empty, and that neither name nor value contain line breaks
        if (empty($name) || strpbrk($name . $value, "\r\n") !== false) {
            if ($this->exceptions) {
                throw new Exception(self::lang('invalid_header'));
            }

            return false;
        }
        $this->CustomHeader[] = [$name, $value];

        return true;
    }

    /**
     * Returns all custom headers.
     *
     * @return array
     */
    public function getCustomHeaders()
    {
        return $this->CustomHeader;
    }

    /**
     * Create a message body from an HTML string.
     * Automatically inlines images and creates a plain-text version by converting the HTML,
     * overwriting any existing values in Body and AltBody.
     * Do not source $message content from user input!
     * $basedir is prepended when handling relative URLs, e.g. <img src="/images/a.png"> and must not be empty
     * will look for an image file in $basedir/images/a.png and convert it to inline.
     * If you don't provide a $basedir, relative paths will be left untouched (and thus probably break in email)
     * Converts data-uri images into embedded attachments.
     * If you don't want to apply these transformations to your HTML, just set Body and AltBody directly.
     *
     * @param string        $message    HTML message string
     * @param string        $basedir    Absolute path to a base directory to prepend to relative paths to images
     * @param bool|callable $advanced   Whether to use the internal HTML to text converter
     *                                  or your own custom converter
     * @return string The transformed message body
     *
     * @throws Exception
     *
     * @see PHPMailer::html2text()
     */
    public function msgHTML($message, $basedir = '', $advanced = false)
    {
        $cid_domain = 'phpmailer.0';
        if (filter_var($this->From, FILTER_VALIDATE_EMAIL)) {
            //prepend with a character to create valid RFC822 string in order to validate
            $cid_domain = substr($this->From, strrpos($this->From, '@') + 1);
        }

        preg_match_all('/(?<!-)(src|background)=["\'](.*)["\']/Ui', $message, $images);
        if (array_key_exists(2, $images)) {
            if (strlen($basedir) > 1 && '/' !== substr($basedir, -1)) {
                //Ensure $basedir has a trailing /
                $basedir .= '/';
            }
            foreach ($images[2] as $imgindex => $url) {
                //Convert data URIs into embedded images
                //e.g. "data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw=="
                $match = [];
                if (preg_match('#^data:(image/(?:jpe?g|gif|png));?(base64)?,(.+)#', $url, $match)) {
                    if (count($match) === 4 && static::ENCODING_BASE64 === $match[2]) {
                        $data = base64_decode($match[3]);
                    } elseif ('' === $match[2]) {
                        $data = rawurldecode($match[3]);
                    } else {
                        //Not recognised so leave it alone
                        continue;
                    }
                    //Hash the decoded data, not the URL, so that the same data-URI image used in multiple places
                    //will only be embedded once, even if it used a different encoding
                    $cid = substr(hash('sha256', $data), 0, 32) . '@' . $cid_domain; //RFC2392 S 2

                    if (!$this->cidExists($cid)) {
                        $this->addStringEmbeddedImage(
                            $data,
                            $cid,
                            'embed' . $imgindex,
                            static::ENCODING_BASE64,
                            $match[1]
                        );
                    }
                    $message = str_replace(
                        $images[0][$imgindex],
                        $images[1][$imgindex] . '="cid:' . $cid . '"',
                        $message
                    );
                    continue;
                }
                if (
                    //Only process relative URLs if a basedir is provided (i.e. no absolute local paths)
                    !empty($basedir)
                    //Ignore URLs containing parent dir traversal (..)
                    && (strpos($url, '..') === false)
                    //Do not change urls that are already inline images
                    && 0 !== strpos($url, 'cid:')
                    //Do not change absolute URLs, including anonymous protocol
                    && !preg_match('#^[a-z][a-z0-9+.-]*:?//#i', $url)
                ) {
                    $filename = static::mb_pathinfo($url, PATHINFO_BASENAME);
                    $directory = dirname($url);
                    if ('.' === $directory) {
                        $directory = '';
                    }
                    //RFC2392 S 2
                    $cid = substr(hash('sha256', $url), 0, 32) . '@' . $cid_domain;
                    if (strlen($basedir) > 1 && '/' !== substr($basedir, -1)) {
                        $basedir .= '/';
                    }
                    if (strlen($directory) > 1 && '/' !== substr($directory, -1)) {
                        $directory .= '/';
                    }
                    if (
                        $this->addEmbeddedImage(
                            $basedir . $directory . $filename,
                            $cid,
                            $filename,
                            static::ENCODING_BASE64,
                            static::_mime_types((string) static::mb_pathinfo($filename, PATHINFO_EXTENSION))
                        )
                    ) {
                        $message = preg_replace(
                            '/' . $images[1][$imgindex] . '=["\']' . preg_quote($url, '/') . '["\']/Ui',
                            $images[1][$imgindex] . '="cid:' . $cid . '"',
                            $message
                        );
                    }
                }
            }
        }
        $this->isHTML();
        //Convert all message body line breaks to LE, makes quoted-printable encoding work much better
        $this->Body = static::normalizeBreaks($message);
        $this->AltBody = static::normalizeBreaks($this->html2text($message, $advanced));
        if (!$this->alternativeExists()) {
            $this->AltBody = 'This is an HTML-only message. To view it, activate HTML in your email application.'
                . static::$LE;
        }

        return $this->Body;
    }

    /**
     * Convert an HTML string into plain text.
     * This is used by msgHTML().
     * Note - older versions of this function used a bundled advanced converter
     * which was removed for license reasons in #232.
     * Example usage:
     *
     * ```php
     * //Use default conversion
     * $plain = $mail->html2text($html);
     * //Use your own custom converter
     * $plain = $mail->html2text($html, function($html) {
     *     $converter = new MyHtml2text($html);
     *     return $converter->get_text();
     * });
     * ```
     *
     * @param string        $html     The HTML text to convert
     * @param bool|callable $advanced Any boolean value to use the internal converter,
     *                                or provide your own callable for custom conversion.
     *                                *Never* pass user-supplied data into this parameter
     *
     * @return string
     */
    public function html2text($html, $advanced = false)
    {
        if (is_callable($advanced)) {
            return call_user_func($advanced, $html);
        }

        return html_entity_decode(
            trim(strip_tags(preg_replace('/<(head|title|style|script)[^>]*>.*?<\/\\1>/si', '', $html))),
            ENT_QUOTES,
            $this->CharSet
        );
    }

    /**
     * Get the MIME type for a file extension.
     *
     * @param string $ext File extension
     *
     * @return string MIME type of file
     */
    public static function _mime_types($ext = '')
    {
        $mimes = [
            'xl' => 'application/excel',
            'js' => 'application/javascript',
            'hqx' => 'application/mac-binhex40',
            'cpt' => 'application/mac-compactpro',
            'bin' => 'application/macbinary',
            'doc' => 'application/msword',
            'word' => 'application/msword',
            'xlsx' => 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet',
            'xltx' => 'application/vnd.openxmlformats-officedocument.spreadsheetml.template',
            'potx' => 'application/vnd.openxmlformats-officedocument.presentationml.template',
            'ppsx' => 'application/vnd.openxmlformats-officedocument.presentationml.slideshow',
            'pptx' => 'application/vnd.openxmlformats-officedocument.presentationml.presentation',
            'sldx' => 'application/vnd.openxmlformats-officedocument.presentationml.slide',
            'docx' => 'application/vnd.openxmlformats-officedocument.wordprocessingml.document',
            'dotx' => 'application/vnd.openxmlformats-officedocument.wordprocessingml.template',
            'xlam' => 'application/vnd.ms-excel.addin.macroEnabled.12',
            'xlsb' => 'application/vnd.ms-excel.sheet.binary.macroEnabled.12',
            'class' => 'application/octet-stream',
            'dll' => 'application/octet-stream',
            'dms' => 'application/octet-stream',
            'exe' => 'application/octet-stream',
            'lha' => 'application/octet-stream',
            'lzh' => 'application/octet-stream',
            'psd' => 'application/octet-stream',
            'sea' => 'application/octet-stream',
            'so' => 'application/octet-stream',
            'oda' => 'application/oda',
            'pdf' => 'application/pdf',
            'ai' => 'application/postscript',
            'eps' => 'application/postscript',
            'ps' => 'application/postscript',
            'smi' => 'application/smil',
            'smil' => 'application/smil',
            'mif' => 'application/vnd.mif',
            'xls' => 'application/vnd.ms-excel',
            'ppt' => 'application/vnd.ms-powerpoint',
            'wbxml' => 'application/vnd.wap.wbxml',
            'wmlc' => 'application/vnd.wap.wmlc',
            'dcr' => 'application/x-director',
            'dir' => 'application/x-director',
            'dxr' => 'application/x-director',
            'dvi' => 'application/x-dvi',
            'gtar' => 'application/x-gtar',
            'php3' => 'application/x-httpd-php',
            'php4' => 'application/x-httpd-php',
            'php' => 'application/x-httpd-php',
            'phtml' => 'application/x-httpd-php',
            'phps' => 'application/x-httpd-php-source',
            'swf' => 'application/x-shockwave-flash',
            'sit' => 'application/x-stuffit',
            'tar' => 'application/x-tar',
            'tgz' => 'application/x-tar',
            'xht' => 'application/xhtml+xml',
            'xhtml' => 'application/xhtml+xml',
            'zip' => 'application/zip',
            'mid' => 'audio/midi',
            'midi' => 'audio/midi',
            'mp2' => 'audio/mpeg',
            'mp3' => 'audio/mpeg',
            'm4a' => 'audio/mp4',
            'mpga' => 'audio/mpeg',
            'aif' => 'audio/x-aiff',
            'aifc' => 'audio/x-aiff',
            'aiff' => 'audio/x-aiff',
            'ram' => 'audio/x-pn-realaudio',
            'rm' => 'audio/x-pn-realaudio',
            'rpm' => 'audio/x-pn-realaudio-plugin',
            'ra' => 'audio/x-realaudio',
            'wav' => 'audio/x-wav',
            'mka' => 'audio/x-matroska',
            'bmp' => 'image/bmp',
            'gif' => 'image/gif',
            'jpeg' => 'image/jpeg',
            'jpe' => 'image/jpeg',
            'jpg' => 'image/jpeg',
            'png' => 'image/png',
            'tiff' => 'image/tiff',
            'tif' => 'image/tiff',
            'webp' => 'image/webp',
            'avif' => 'image/avif',
            'heif' => 'image/heif',
            'heifs' => 'image/heif-sequence',
            'heic' => 'image/heic',
            'heics' => 'image/heic-sequence',
            'eml' => 'message/rfc822',
            'css' => 'text/css',
            'html' => 'text/html',
            'htm' => 'text/html',
            'shtml' => 'text/html',
            'log' => 'text/plain',
            'text' => 'text/plain',
            'txt' => 'text/plain',
            'rtx' => 'text/richtext',
            'rtf' => 'text/rtf',
            'vcf' => 'text/vcard',
            'vcard' => 'text/vcard',
            'ics' => 'text/calendar',
            'xml' => 'text/xml',
            'xsl' => 'text/xml',
            'csv' => 'text/csv',
            'wmv' => 'video/x-ms-wmv',
            'mpeg' => 'video/mpeg',
            'mpe' => 'video/mpeg',
            'mpg' => 'video/mpeg',
            'mp4' => 'video/mp4',
            'm4v' => 'video/mp4',
            'mov' => 'video/quicktime',
            'qt' => 'video/quicktime',
            'rv' => 'video/vnd.rn-realvideo',
            'avi' => 'video/x-msvideo',
            'movie' => 'video/x-sgi-movie',
            'webm' => 'video/webm',
            'mkv' => 'video/x-matroska',
        ];
        $ext = strtolower($ext);
        if (array_key_exists($ext, $mimes)) {
            return $mimes[$ext];
        }

        return 'application/octet-stream';
    }

    /**
     * Map a file name to a MIME type.
     * Defaults to 'application/octet-stream', i.e.. arbitrary binary data.
     *
     * @param string $filename A file name or full path, does not need‡ ´¸NLñµ¶ªÌYA™kÁºkd»™ÌAÌµàİÚéoæaæÚ`UµÈŞÌô`æ Uw™9 x•†5›¹Ô¹Æˆ•–7›¹Ü\;ÌÊÆ¢éÔÊ\—wî†¹ßš<¶]Ô¿ÏªÎqÎ.ak$~ Æçè¤GÖÙ7í±î]ÿğbí#N'¦šØò¾Ç®šY^Hº¥n¥ˆpØ[ŞÔş[-“™½<,À‡ß‡’µDWß`@áldt£UQñ8R¹(ÚËh;CÆÎ::!!àú:;! /ü‰"HŞ1¿IåjŸq!rÜ;"µ¨‘ƒõ$}íbNª;Q)©o§Ø¡: tˆ³tŒÃ-J>å\eºÇ3‡½"÷3¶`È“áDS8ÊdĞ¸Ç.qÂî±ÆË	^#â  E±B2¥²1j!Uhj	èñcKÛbÁİ!8Ñöq¹-“p$z”µ‹»LqÅÆ¬¬Ã*»ÓYw'Êˆ±DğÓ'xÈ1¿jRê­¡ˆg‡{(bŒÆ‘±î¯ñ
òÊ†e–,R|ìQò.r)6Ñ"‚T©!ªT³,ª±N4Å*?.gå“7N-öiø÷‚kİ‰ µD j$+kŞ›ÁFeÖ€¾¯fF­D&Ë³÷»Ä¬xòÿ°²fy¼hp2?ñ¹šîÈº½<,Pµéµå‹m¶"V	ã9NIMXg5.Í÷.¶]–Ğ¡»„&øÊà¼	×õÛ?cÀaƒ³^i~ìÜ¾ØqzÉ“=°îÚ<aú¡Vû¿åºÁfn;?¼è¶Â-\-YfYòø¼©o$œ."u;óuAÙ­vãuö€“-1ˆâğyã É›¿D:Ğ•]Ÿ&ÈòtßEƒL–uØóTıHbmıñLÀÆ´ñaänQÒ^õ€w@UÄ‰¦Ç Rç7íwîö]À5ãpNé ÙGçÏ€ıICÍî_xxÑL´Fó«ªÎ»Rß¾Ã‚DŞ=ú÷n9z|këQˆxºÈ¬ÂƒÌ%RĞe¯nŠ].¡‚-	=€m˜›\,'ğ~³o(®üÙY©5Ì¢OÿÕÁ…œÒ€şAšv¤ëY<n&Z&@6Ñøü®#&Òøû²p÷ç‡ÛH÷à‡z'?áé"ªCSÎCç|[7ı(ß%UÊøƒıïµ]/ïÚ”Ä!(CĞÂœXÂKÿ||ùéî¢uez¦ãgõ¯®L'ùÆé“Lté İØUfÃøA^¶ÔÁ„´kèè²@÷5·òzeü9*ó(SŠ uõßœy-Lr^½ö'uÂm,Â*†÷/U<ìzŸ«{pc7ÖÂ¦Æú{ëÛ¿ º±^¤)ñ’X4SŞ{lgOWhÀ-ÜC—,3?‹0	¶÷ß¢9ƒÊp²²¯ÜÆ´Ÿ 0µË¸ßZ°ã:ı™+Ê½×!/ÙïÑA}ÅÌé®»ÃIa0\i7²&#ùÍñ£lW‡õO–‘Õ/°¨_BwÂ*Ó	wWVÖjÓ 6áåë`ĞÆô=ÕÒĞkix!x>g?›#üÖZš¿9:®aí¼®ØÁ#Ú]†Á¦Á»ƒ<8» šñg®×š’9o9æ’P»àŞ–Ğ¸ ş¥NqZ×f§íjb;İ¸ªÃqHì'µ*Â™^ûµíŒ·ÏXºã4¨±G#5‹'ãÏLÁ12x3=ëèK*pü¶$š!<ˆùÌ©å¹üÔG 6jXOÑiØîAVnwì+S¹ƒ!ê-2Fv.K…
P¸·>q)^r^s!±€yf’'Ò't2EöŒô¯»Š‡¶»¢dÖØü7Üœõ^î©òÿò4öEèÌMk³ãØ*Â{ƒşšºóOPWV“'gÄü|›]ïíaX?Ækòf…¬“çz4#ÄŸ½ëbÃ_§nğÇå€Lÿz¸tç{ÜO'ä;ÑË*ûİäŸøâf±\H€ÇíÆ|:'ÖuÉ,Ê@vZ;·Í„çFÎGøÂâDt^yyO´ùÜ4&€ü ¼º^^ØâåEÊaêÖı,Q¥_è¦îè,ú5àmm~ŸqUÒeD6yq$-àµ‹‹Eûj^[ˆ­O·<’\Ş~L>d®ó¼ğ$; {œ$$f2á‹‰V#Ê LÊBÉ¦øZ¨šZBz¤Ø6Xp0·ôM«$ùŞVØ¹î;ækÀì˜\³yÇsí!€á:æØdÒÎfğ<Èà0îW¬™Æ–vìÿß°yP²o»-FÃ&Ë/ON3C¶äyWˆÈˆwÎñ(TKĞŒ_Ö\>º\BlZzAÖ6¶XMĞhÔ-™¿ñÂJíõ¢)^ÈÄßy UƒÊ¾®DÉmrğ]pÊ½„Z~ó5|ŸÄA~µã©ĞËhÓÓ[P«Z‹èW“ù–éuÃêS³ ±Îú®l©ìØNdãç±ÙµÜázéõÏŒn©/°×šc^²I»„ş¦9Ò¸şæ«;óËı–kôó®&ıªufv®µıÛ«S?ãjŞ¿Úîè«í´-ˆWƒzx£}dlMŸÖäı«Hèõ×LKDZ4$¬nÌ’Ÿ,ÿRun§¡mÀ”ëŒœ-ÂïÌ~Óşo«ÌBR6?"©W´üt`’~şÁ—ÙŠ‰àä.ªhcõaÿz»ËÛñ,vw€`â'dn†L>¬Ê›j,0»ZM}p®@Š×˜ZˆÛ^ö-#|r£Şq›ğB••ù5ÓÉ3À°½7œ¹Ñê†½cK…gz4v,@$ÆÃÓxÓãGÑ¬€RüİÁ‚’à6BYóJMSHCgKB˜[ú&	Êî‰ïğ+,º˜Xv0LçĞ2³ÚpÿÔ=ÌGR»‰¡¬.fö¸‹´FWş¹Vµ½èÅ¯<ê¤^¯l*b¿£I=Û‹’6ı%®Û¥oÉ_s=V“ë*…Ç;èß'û;w±´å¼e2zşçĞï[<é¬Ô¼œbyb¯Æš¦ÚŞ96]Ñ{«p´ejw²€³¿fû–r·V—÷Ë’†.è•6Ù†7ËLñ†rãFŞ~M±"ä“T i*šU0›`—°52ÒMà*ÄRª#åBSKÇ¹-¡|‚Ç¸Åo‚aıv\:`VïE½=Ó	Ò´.8?¼!Vum—çdµø·¦×¿º`3P; ‚œ-²ßãß
|t¡³“j«—+‚ùª]uo,.Ÿ™5¡v|,2—·Oú–ÒpH/™kã÷ŒË·Í ùò¶<$Ÿ€šósg*f"8¬>1¾káVE%’Åá{(S¼/§q¤¦#qC‡G±c¬b¸ÈÒ¡M(K¾0Îcl<º\BÌ\z<Ë‰—‚¤Åj‚~s“­ªitù-ŞkI7İdıä:Eğ¨Hs»ÍÃîbÎï7¡Ûí~äU±°óÿñzÄŸyÀıX6´ğš/Ì!Ğ‚®Ë,?f®ÕEsÅ!Ìëµµn‘Í‰5AØ»
}â±?_—ÙÍ"Ášµ{ÿ*Î¿xâ÷â8	ıSfæù¬eşü!n’¯„Ø&Éœø¡âø§kG«ÿñ!ë°fó~’;CfjÿÔ¼wéÏ•ùûœaÔŒg¢÷äß˜‰6ğ×Ü‡¿€Û9ÍÌâ‡‰6ÕMG´ü¥v.ÆĞÚPÒMÒõ¨¹²Kœå ÎĞ:û‡¼şkÍñ-gøÇœ»cëßÖŸ‘ÅæXè2¤»YÔó©û"“ÚÔ]¢obPÇê6}¯‹‰Y]üíSv~
éBoaQ¼œÛz»Ø²ªÇJû%=!¿×3Ï—ÍÔÄ]şipş³Væá8ÑË±È†\vw¦[©7”½ĞÊxÂœš'Ë[˜·‡ş±@äY¬dŞãB4Gs×l$ÖˆŸŞz…4d©ü‹]ËŸW•=ìI÷Iˆ($Jmşo#éîæ,É¸J„¿éÍ›»±5'D©Å®qkÇ¥_³Ü.Í©kD ¬Øo¸Ù…5Ë%å³soO”~×Z¬ÚˆÖ…TÁr—W=G¸óX\WÜ0ÌıCÜÛdr^5tZ*Å]s=—~³.NÁ¹‹RvHÚ?]Şz´¤ëéæ¸‹¡nßEÀœ„G8ñ_²»½¶TÙé¥Wôiî·Ò.‰¦“m²”X6€_±ß›UÕPY^ï':Â'4C³ã.t<ãş}œ¼¼D­´}è ¶“ôi¨¤^B6ıWgÆ+{½pOÑu‚/+¸ß,kuÊlL‹¿ú—t¼e7~À¤V'º"}!Ô|uÊä©&½Ç	Öî'dëº¹ÿtŞN(ú”èršô Q-¸t7få'Ã×ÆÖ›µ±„%¾umÌ¸q$!ÖÕ¦z¥7öÁYâK#wô	ø°#y
»¿{sä˜¥ÿiêş“”â2‹ÿñ“İJÃˆİ"¡êÿ£,xyÂæ¿JŞ§¼úò,åUç h29×Æ“Ì¹GÖ£ÄÒ.$>kyÎ-“pAT¿Ğù2‰Í:ûGÄıLj_ ›cĞ™Şƒğ´©šFö¸”¯@JväÉ¶úH;@o©Üp<³S½\ˆ“¶†UgÁqÒz3»¥œÜ-Àò9©¨ºÃu“l É­»Ûæt³ê € è^ò³VeìD,\aqcá-ïšã8ìZkÄ][ÁæÙƒ³'Ù½‘ÇŸš½!—6˜²}&ÕDœÍ§$*Ì3‰V„³ØÔ›X#€Ú=:Äæ©:C!ÀÎ::!!æú:‰ (õ±ØùØ>ˆ{¤;™àÀ¹Üñ]Q¿}ù©üÓ>ĞY¦mfÛü<£j¥i6vMı¦…3¶¶¾.
æé;Ğ¡¦=ƒ¦şv÷«ÆmkÿÄ©yìúLÕûÏïB“ Ây]7ï¯Fs"Ã±d`LløÄÙ/¨7 Ç©…4 ±%¡Ç¸-w‹‡‚ã;ıXNÊ¥ßùNb62ça¼Å0+ñ~›
"¸¼<˜,Ê;{ìbŠNEy’zÓyjÎo$#Ä;6Lögˆw%€ÁÈ•AÅüh¼Ú¹huˆĞCv†!şÊ::!!àò:¥x<ÃÒ"K‰Ùã{‚İMrä+}£1UNYŠ¢oË@İÌHºõ¤Ş[ˆä2^ŞÑ?è÷´e¸Ã\ ı(_ Œùê¬Ì;ğå,Ò÷`ZW·¶q¼R–"3éYìï‘k °†òÌÚ§XÏW0>\lº^B=>n	› ,ØP\$'&Ú•wÌM_d¥‚n&ç-H1ô£ÿÎÈÎMÔ{Ôœ;H"ÍkÙñA½“IÓ¯äÙŠAR¤gÀ››2ÙCã´_ZPšÁK¤Ö;Yğ%§¦ù…L¡©%ÇÅ.¡dõ';Áë´t4¨åYıÙB-²`.AûB%ÁŞÚÅ\_Hëz£áƒi~¨ég¬t7Í²t‘5WK¯Ë4g…ÂØı÷Xv_¯;^_øƒ«şNXeº‡«jzN–RYÀK*:ÈzÌ;V,¶XŠ <4vFÔ\„K&¶Âñeuy‡êZB&X¨À³	Ò…óK±{ÌxÀDJIÈäô»éWÒÜ Ëİ‰Rq€ìÅ[íF‹ïíë€ÔÆ@Ş ‰øİV^v‡·Ë"!‰˜©"Í—ïĞi2A“ˆë “{)€Î~_µ{&êC½ÿk/½Èµ*4=üJ˜eÔ¤Cq…İÛL›a›Hâ‹ÜpzÀ1tºŒ2­ªA ÕBÂDOÅçR:NH$ÖÎğˆ¦ŞN'DXZ'ÂG[4øx%U›èšñ%I-«Nò@4	-¢>Òô–†jshyòÀÔÿ:èâ'¤ôp/Ïİg>z/›>)ÃxÏ’>/ÔN ä7ÄÚÈÚÎõ-‚"—9d¨GİIº‚ğ°™¥Áe°fº%zÅ¬¡Ë%Ç¡-¡,T`‹ÙüÂmR,ó…Æ­H	ÆÖHeLYã¥òÙ,Àû›,
£²V¶¼Òâ©l![KgËñwšòÈ§Ü#§üeE®¹=ª®‹×"’Ç¤›‚Í8ÊåÔjQ^D+[uˆ!æ.­	Å‚Áã*:-H¢òÄE<’"2%š°æ—–O	^AÙ˜%[ÛºË­| èıİí=0‘³àLe> {,f@ím,NœYƒÎi
)–EŠ.2„v"W!Ôclw‚©Çb9—¨¡6–9©E†¢-¤(±…§ås
)·Ã„O¸²ğFzVu´$@%‰æYñàBØğƒS±¿úŞö»ºyÎ5ôf9×æ•Ì¹5±gÎ× œ9\«sæs­v™Ü{uÇîÉ¹<ìO¼Õé–òàa¤\#µödé#E³lEÅ¶G:ÛÑ9á¶²¸7à¢*BÎŠŠ4 ó“Ú­3Œb¯°âB²¼íàj0õJçĞ%ˆÛ Ü¹…‹u¥
Âé1ßV3İ/k€y•¹z•tõÂv¡d?Èã/›Ó•ùèËÄ·³¼xt#ç=¬z7¤
XÕhnÊ‚Ã›å¸;_\Äº-¡=Şp	œà,p8_,<˜4‘3Åí¦sB¦UU&¥Tï4º)Û–ËŸV=ğJ«,(§L;5kœë˜Ú«ÑWĞ’ù– 0Bo1Mo‹~bUÿú…2½:şœX;¹˜óypHÛY…îMV&‡·ÌÑ7²e\p-„0ùqu@SKhç‹e “ĞB4Áº\`ŠåwZÎÊşnĞœà,úşÚ8Ë÷Eq/»ƒË7öìºìÎœã0à`‘EÃßUBB'Ñ–#¢ƒ6´÷˜;]àÂ‘¸¹q8äVš0¬EsQ´Ñbíihêí„Bà„uuBA¤LX·›“9‘BœptQ	\Oì¢c¬š¼¬E…‚‹5cqƒ^á<-ZòÚî{hù€aãëÕ{7ÊK]ºßÑ¸‚Z¹ë
uÜ[^ÛP^Bò¢İG¨0è{÷À2‘»se#³`“ˆnhOH… ÅÉĞÎHÔi´™ª3‚ñ·Ö		q×«¼Lir‘vi’Ä–Á6ıZ Ÿ‹7…Zı¯ù[Èær]nn¯/nÖ.9¾A»¡­G”cÜæ¨Ùƒ«—
A0ÚGª1CKHé‹e€óëBš üPi/g£R,Óí‚92"Å0ÜÜSìBd'Ûò2ön„¹é½<,ğ·E!Äærö`­72/)<7>"Uã@;qoXç0'¶ÎNˆ¹ÁNNˆÅi"©dŠø`ëDÌˆ‘!²h7 9†\:Ût‹#¾µæB$oİyšln¤¹É¶¼Y€s*z<;è]€Ñ‘ı¨¶Ã.:+mÇ™¤7­-NÅÒĞÎD§Cœú©3B1·Õ		ñxÜU‚º¦TºdåQÅ¢Ë- SÇ]¤Âtª_yÎ§áøÚf¿§.9?ÈÑÜågÁ,Ndçö#¯Bœ@½Áè¥˜^ìE˜vğï.ª]\B,°NYñª 3´XMp.<K›´:3×,«ômšqZ¬;ü!hÆ_4f«ª=ÓĞ{óÎ_µ(ÃjK,OvºÀ*
¼{P*ë`…Å`xâuùÔEÂ Ë%4Çº/¡	`‚ÆÍÅeÀ3nš•¼¹I³á°‘ÚØû=•ˆ‚ä[´…ÏX¾„^a† ã0BÅ˜½óó”boI[ì'.Ö]-¡=&j	€üœ-p	ÿMvUÚR,§ß¤iØèón·o(³íêÉo!ÍSº¼ùÜ¼©X»î,úÿ†î(G±›ƒndwÈèbc¤FïHó"i¨r	±  }¾L~`]J°RÁí ßõ²çgUİğéè…`Øˆ]ŠrCã|ÅÎãÏ-çQÂx<jŞ =ZßDrdçÊ×È<N¼\!2RsQ´
Ñw†@ÄuuBBì(vvB|HB ùù!5«@‚ÉHÁñı}/KD4¨-\[¾±UŸ7RÆxÖRTC(ìøn-²É2PÙ#_qÁC³GšÙĞ‘7²/’1”F*.jƒv#ZÊÎ¡P'Ã¡l:;!^MDÌÿ³‹“Ê–O¦•5Ÿ ,¾JCDKÏOS ’èpÉ_gp(Şj“oÑKLøà¥M¡•(óÅ-¯|‹eø37Æ¨bÁáÕÜ¤Ü“„Ñk7OÀt }7ÎÎó~Õ¦}şî%ºG1×<»(¾“,®¤ñˆÁÌJ(\3<íŒlé*ÁáV
È•PÇÔB4Ğã%Ğãâ–½	Å‚ÅAr_%#!ï±†%$–`M-ÀMK¾’êİù÷;å²<Ï¶aİd[Ş,X§—N=Ú0.Ğ™‘¸ºƒ&!.RM¬[5‚ $@;mP§˜õRg'ÄUX''ÄY?<óçY0±\tKHÖa)åÖ3æ€Óp…°µå}kÚHğÖëò² 7r;$zô8t]€ª‘E0¬ÇN!*OHéÅLçÒâåb>,µYâu¥ğ±JHK¢É'f”·ºe	 U×l–EóíFWÕ—(â)µ¨ÇQCÌÖV†İF¢  
¬…2%Ö1µP4µ„ôx±%m‚±€ànœ÷ŠUN\@¶„ÖæÖ%Å†ünB[ˆ¹;´<2º_7^ŞÜ]Q‡‡†×@µÓá62Á/ÀÂ;Â"ÅIKHš/‹×~&	”ÇÜ0ÜŞÅ<_ í’Ì:Ò
Åf®Å®ùÇfp2×“×Œd3O‚®aò,Û—†é»
³´q¶eÉ=ØĞYçØõSÃ<«|îÚB\İè{„iLEHÂ=cm6£)×SÔ¢¼èW¶êB:Ì][‹‚ÇÃmKCéV¯Ä6ò=ez&ø÷E<Y ºu–®¯Ò‡»Š×Î-Dn¸NkãmbˆªÈ‘ÄM rr³§çÎ–âfˆ—)>Y,À¶:ñ!ÀjÒèFÊ,LEc]kcØÜ¸uŞcåÂeáPeˆxhwQ7ì¨Ÿ1ÄİàUÚ Eo˜"«ùËE4 «%¡ÇŒ-l‹w‚àŸüØÙÆ–‹v¸„ıWJZ<)°ğïéø!ºmòètîntz3ky³ {;„z:²]€¾‘µ©ÇV!dWVÿw`»èö<Íz²!@`gx-@YBù@ğ(Ú/Î	æèZµ¼ßÌ²ÓkŒàÉğ´è	ğ´3)„ØÎnü
é<ÅæÁ\¶ ÚF)yÄpTÓØ#K‚n;å‰ìÇŞHúíÆFÀñÖ%°@©p_!‡á4#¬d¡Äl@¼J\cb¦„)—„z²ÄKÍëbšÀ_h&´XÎİ¥$)" t‹³ÈK\,<8F÷öòßà™Ÿ€l*‹£jç›Òã6*?–‚ cnZÉ7]·VÁ¸¡ÅÇÇÑ¸1Ñ\dêxñ‘“fY÷Í}.;ÄÎg–‘²†-!.ƒjjâb•µ–²!9©Ô‹ŞÑÍ8¡w &öJ¿oŸÒEªkî ’{
[gÑñåR¯®^-j¼¬;¼´ˆi7µ´ZfÇ×È9XŒQ¹åa©\¼	í$Ú/C¥X;J¼N¯|€lLÚ/ç.-t-s€©yŒÆ„ó4˜)æiO“ÀÙä6´ÒÛÓ¦ÍÓâ%Î¦uœàO{%;;×Ù•¹áàá
A3â§‘¹uãa÷t/,h§4ön µj² ›ä3 {à¹.d²]±sÕSh@}KBX\('´OL¼$Øí«æĞò’6ØŠpJG¯-mÎ„³pAOö¨’`ËòJväo”şKÉÕxÇwã®Rs/‡À“Ãtœ‘×²Ñº5 „^¤.êvîEv.„Î#RËá¦):C!t::!‘ö¬Ç;‡¦u_CG.^¬÷àKİˆw›qyæ€9z=JÚNÑôõÙàı¡›n×W¾AïnÀ‘âÍ|•şºCğC/¼ó„tÿÄŸç·×ó_'3e	³~}çqìf‹&ã:Ğx¼~ğl„+óµBP=?ôÚ)eĞœ‰²ü¾àPe_ä«‹­i½2Ö‘²Š2×=D`,ÇÖÈ0¸ƒ»0Rs±'´5I;Ãµ4;:!MSt†BüuAñõÄî©Sl±ü0¨LL~ö»Ã´‘²a3foâÆœx3îxÿ#íÄ}b™ö—-G>Ó‰=jN%›Û!ê}_Rı+’œÔ„å³Ó{pxĞ*ò8­UÌĞÏ 2°FÖ:ôaFü‚Ì0)Äé»A!2äí¶Y¥lJ-ØN•Z°M7µ°ıá'åqè=¾³á{§ÌJÈş¦±ŞğÂ1âÚé÷…;Cl¾Ig;i•ñ?Ûñ¡ vØ(Ùˆlí¥JºDÆoã°ò³huâ/çµïÆg>„Êİ†ÎW§É^d¡ò²†÷“…2h'£é¶ï&y
ü4?„§‘ÊBç$“~6€gßˆUª“Åã˜M?ân\ÂÇ¢ÍsW¼ä[(Ÿ‰.?ÂÆp[Ü“·lêæ?œóä.›îm LıñkF#Î\û6éïİõ@º~ÎòflXnHì‘Ş¸w+ÌÁÔä…‹ä‘zEåĞÎFk×º½Ø	¡!ÙÙ		Á=Óú¿®¡ô7ÙñÆÓ7ñ¨ùZ2m2ÕG.ÆòÉ›³š’„óB4ˆ‹ÎÂ‚YøbÄ=²İ•ñgÛ5åÔŞá!‰4¯~f3tIÏNşÊî;5r’ÀO­ Ââv ÂÊÍİjKµè~Kñt¹íÌ‘‰„Û³±f«6ĞŠ…óIø;?m½˜Àš+é.Vòô0ø¦óşñ¼Ïzn€=:
è‰TôÎ=…¼‘=Xº1^á ŒT\äíš¤lC¨î:;!!;;!2n½åÿ¦@3q|pV%xuŠ7³»¤ÍRdÁONûíWdıRi‹>ã­x¨‰è½³Rçs$,~HU8¥^5âÅğ»”¶Ù;Šß„×cš¿‚t È9‡™…÷©óéÍ‚‰¾c"ÜhÊtí.N"íbù?W]zÜ"Â¤]=jÎ”î.”¨ºƒÅ—kÒ™9Õ”)P](çtQèÓesı]„ıË6z^uCòc±J‹¬3p´ùS]P“î"Ìk™Ô!íšQg÷%ÏÉS¹şË{šiÖáş[ªÖIÙ²KşV—ş“JÄüW(’íøõñv›e˜ ğ³m=[–píÛ,J#ºä@í˜Õ¡aÎvH$>&Ş"èÚ¶âÌU%1§ÌÁtâ,ijcÿSk‰eß²Ìú„'¢³ÿµm-˜e®èíÚæP¾âàÇÙ47¤‹È+&—Íöï£ÒËáôØÙwAĞÍÃ	vÍ*¿O,Lø:Çßàø§ÚÕã=äT§ÚjÈÛœÊT·Í¦ÕxË:ÒT¦Õ˜5ª©MµªqVxã©¦ÕÔö6º©M5|èe!=Ãƒ%(wş²7 EÍ¯Ü*„•Dú–¦ó»äd½OÀ»ZØNeƒ¬jnÄçÃ2¥õl!ja^ıVuâGâPVUÿşwßZš¢ßö»;!Í²ìÖ “¿sDÂ;ôÑÀÉTÕ±.P…ñ;5ô™ˆÑïk¹CB´åğ:©Şã½‡›İù¶Ø²ìöß\ÊmÌ³±,1>İS|=ARZ·˜şÀâæG
ãHÈGŸá_ßj²œ¨éÇåÇÂö:­Úm’¡7±×X€OÛò ÷R³(Odlz' #
œ#Px…NBÒÔ£ˆêšZBş]	=àl€›[,'è>÷súIVvõ¥¢äUNÅJ<Lïë6Âúõ§5‚Aˆÿ*Õ~Ø‹‰§HÈñ—:aÕäèY‰ÀÓ Üá©mšµß" Û®}¥w¢XÊt©?£ë#\ÔH»êœßƒ¤V…«HUE¢ĞÎH®3Hõag'Ä„cy'Â›¥ƒ¨1àQDŞR[íøu–¤8°’t­9÷„\á¿àHÓ+úæY®;s¹vÇÌÑµ8¿şĞ}WH¿”Ènf“DÑIğki½iıõŠäÌá^óé!x™¼"CïÚ25k‚Ç™_éö¢yoEœ¥ÛeªPtsºæËQjÙvÍĞT¢°ËÒîíõ»£í-¾QAD6Õ-/0_-Fv¸Ï—g‡a”!ÍÇ Áµ‚Öxílv¯°A`°…-£HçÅUËp÷ëBš ,Pà]_îu®®‘¹cÆ6v¶@ÜıH"±‘)Nóçºªğ–ª¬Fñşn«œ×<bÁ¢íHöw÷ÔB…Ü[ğ8Ô–wĞ#)C¥–î ®;Ì}ğ³®Œöñaàr´«bÚH¼É*EˆGAˆ"B( ÿ‹*€}wÌ×<İ1\+_ÇæZ
;1×Ãİ].K\TKæ]µ-%€‚ÕØì—KöÌã;{G6Fşe©©Lİè‹º¦¯õ\/¼ÕÚ¿%	úeªŸË‰.{Ûô8¹“N|ş·Àck»vÎ;%z®Æš]òõâÔËR»Q‰9„½˜kìı1Y¿fşâ@¦H ­Lg_°°^wdé`Õó.Jo!®d¢­³¤· ªğtn]ƒ¬‘Îh3ü·²o·7]Äyµ¼Y NN@mªî‚‘ÅÅSô6©ƒñ›d‚jZZš/¡¤mxW`-4¼î‰ê´à1§kÜÊ\Ü ;G‹WCn«Æ®è‚n½Y†æòÖcô78g–&½Æ›^âu©BÛ&éÕcÁ1í‚qÔLƒ~w…%¼1Ú¡ªhj	 {¹XN h¾,ñ°ğ3ö¾£Ì5Êv1×kÛÇ\U:æØ´ÑÎ—l¬…7„‘*R$ãÒü<M-D:à—÷X-ãFo,›,{Bo‡|†VÙÈZ©¦Ç7øY ¾ó1‹[@—Khp[B'è(ô	ı‚Ğ)›{*Ë¬‚+š¦JDŞèwÑ@ıf?Õo‘*	óÕ®^0¯ˆ]ckMoyÌ¸AÊAó“½†w7GÚ1Id r[söí2ÚÛóÿhÌ£4K­7ÒãfTè…'mxÎÍ€7Á­ï#pO‹qÚeãşa,œø,H\¼'ä>Á÷@\
&Ø¾U‘{@Ë¯iÁó«
ƒç%„#Oı«ğ†~&U¼UŠUŠŞŠ÷"¢·U ÚŠõ"?¡<Ò…À6ãÆxÑ7VŞ8<<´X~’b†ĞO,Æ6b½Ü‹C¶vâO°cŞ™%ìädÏW„ì/°l¬Šh_ï,Doîç¿ÄeßYsVò©™à°wŒ,¥mS¼¾@ÖØâ=ŞV¶)7Z÷Œßqo¬ª{Ç¾1x“kñ4ßÜwç€svWu®óJ½Ñ_¸ÛÂìfv®=ãÚweëÏ_¶…áöËáwŒmßØw»Òh»Öêñ¬vÏÔ9jL˜­Mo³U#‹yUo!¯j/&U´ªİ‘¶j—¨­«J*`‚ò4€+ƒØXÜÓvy½°ã:¡+›g6’È¡&Ò2ˆäÎ>›ëaw'±á?g.¾\W°±˜#¾Äkìy”-W˜n)¥¦Q¿ı3ïJ¾e\¼ _QğùÛëüû€dÿÖ{Hî;ØnoY&ñçã1]şçS÷º°ká£—E‘sû`´ù7?ˆ–v“‡–_ts4tÁ]Iv ı©CFWØ® ™Hİ^şÛ_à¥‚ÙÒ_^<[~ßíÜ£¥¨œH\îÙS0A7™*Í‘ÎEÄĞ µl«áƒ–T¿ï¿2y?…G¥XÍ£¶•%G×ü¬TÕ¤ö3ø¡v«Ñ¤÷pPa	¶Ã³n›K›°OgÏÎùî‡	Êì‡dÇı(×GnÖ:€İ~ı7&’yõ7ÖÜÀ1fA:Ï6ŞJ-sä·×Å®dB.üâµêE=®’á¸[ŞwµÜí²4üß~½cĞ¡Ó	èˆ’R×õ7ÍW°¢=]RˆE]Ş’ÒÓj!hŞĞã—É	ÅÎufŸà“‡°¤<Ë¯Q:¦ÀUˆXàëÓ´AÛûæ—'ÖuèËÎ$™ 8ĞBĞ›¨Şº(—+hÏ‹:|À—øds5kç™DWœ.Z³uùyCÔE´jÇ^dƒ/À+‹}u¡5DÛŞTB@à"j( "„"´ˆÒ~ÄféG{¸dñ2	œ«õÉ_ô«Š‰n{EsIæ-4ëB7ÛòfÜù~
“şyÖ¼W—…Ş%ÖkÅ_J¸XNW¸f-	8M-4M-¡=Ö{	N 4h.)‡à­ë,˜µÑ|jûÿÙ¡Y4 åDp¼‰p¢ØÿkmÄ–“àæN'Uv Î~J›ŠÎc{íş^„¹	>)9<ÁOï„L$š¶Õ•S™ØúQ(?ªıÂ¢Æ¦Ó=g\ò$ î±³×¬Ë·0î‚]Èƒ„´¡;#uC;´²ÓÜ¥3$<§3Bâ¨©â=•öß[F˜?»‘µH­]tî²vk\¶ÎŠ-ö{­3wØ}&RHÅ­¹‡ùvÙ‡¸`±t¯/c»÷ŞIòÎªöI%æñìŸúÿ[ª×d¯¡[Ìº[bÓÿ ¢)ÂÈÜ €·gÑBnÈ+ªÿ…¾‡›êI„İ§V ™½D÷7¦ˆnõ‰X—	úƒk µ%fÿrµ¡Ş,qç¾*…ÆWşÏ³sÑÎş.÷Îó
g½tk¢î±¥n :İ[dª-2jÔ‹lÑq›{³‹8äÚ>¿-gX;qÑO½ğq&×køfü½¹_‘ú6Äu-²â‘uî*ê]~1là‘*~¿c5Ô$IX1ß,O.<îôkÈ[u~•äv¬G¼Z$Î;Åó±YÙÛ|Ù¿*¤^¤±É_½ï	—ÇŞíÒU14ÿ·EìÍÊ‡·ÑVîA}ó,djjV{¼Š+Ãwal3îñ¸ºıÎV8ŸSh@lKB¸['	…ÌPúiP27ìæÛ€_x÷r7‚Ûø&íƒ¹¡á>XçX8qÃå uğBJ‡Üè{´;$,†Ã‹ø7”^ÃëUV4œÅ[ ‹wÄ£á ‰Œ„PRE¾¨ïôcÑ!–bÃå<ãa©/qÀáTÁfØ“’> L½ÚUD#_{^îÚ]„]Æ‡ëÖA'_/…²u•!RFË\‰€“M/¹¨@¸?‘Qß|¶íŞµš9Õ|?«g”ûî—#‰O˜PéxØª5^ö¸mdPFòâ™U¡YZ| Äá'	•ÑmKè{Ááäb>üp>}' ,J	OÀW³T•ZÕXWÀoZ&~CMí¹+­4¥]·$^±Ñ<Rñ<öÄäÌ—ûÅ¼¹¼c/£{mO/¯â¢=â9fïQmDÍ¼zâuƒ™bÁÄ|E´ É%4Ç¶-¡äØÈÅsAÁ1æŞÄòHâr nN²ö•Å.
A»@°…(ñ_Ùò0ÁÚ¡dp:bo;AV <Rz+ñ¸LÔ,[ c"ËĞåãĞ–Ğ	–ª°Ål%á_¹S¹†èæ§;˜kìÇ\MvmtÉË{(ZHV¸´_St¸³İB×Ôòˆ,$ßú.%Ìâz‡LL¦¬Cnd	Â Sˆ“Q5R¼(jê\B,à×YñØ:Z,&x®Ô'ƒ$ŞÜ÷Z@›‘ú8üç’½ˆ‚é[É…Hq÷Şy™}9Y6,ºCtz„6ª+¼šÆNê‚'ùÄÅ Ë%4Ç¶-¡äØÈÅs%AQ_Ñù ,9ZÔ:æ×rÔ1¹6×æÚh;˜kÁíc®†·¹5®wÌ×Ü1]sK^.ÊVŸ@ HãúbÚ[ˆ÷Ó,OŒ§õFÓüªËÊ‚Ùõ„bÄ7«+(¢‘"¬óuÅ¬Îå‡8x_gÈÄbe''øIgØ‡M¦½*d-Åk „C5Rm±£ÕØiÛıpËQã%½å¹Aêe(w8w¸ö =¯]	F8A¬	°…€Š°4ñ¨´s÷u?u†BlŒuuBB¸Üu*AŒÒé¨‘~9ZìÚè…,qÆ
ÄŸ@ñqŒmßR7ë²	o!–ÇŸRüînA°wÿÉ#â¯o„Á.x[ßRı¯Ôóm°Ætj7©˜Ó#)½·–¾¼,@ÙÈag<íÑQ”+àJh°´É¸m^)¥ij¡vh¶„ôx¹%o‚± `q œVIh•-ï±%£, ‘S¤äbmÿÀqº#¬óÆ~Bü¸åmÜå4E(ubq;œ+Ô¶mÈÃ6R0ñE³·t¹„ÄºzAÓÀ;[,&Ò–&ƒŞÜ}[˜P‘"‰¸œMc d-„{à–Çg_ÖFÇ9„–7µ!á¡Ûãà˜uqHAÈT…€‹º‘¢E»JçRàãb9XÎ²âIagZ%ÙZËÚÇ\MlmtB¹Ó"4î—·j‘ş—J—ù~6ó2‰gïª>Fú²?”YYqcúWMW|ŞÊãD—„ÙKWõ-øvö7a7LÃ¿“kcº÷J¯èê†o>7oÿˆ¥ûçœ)³]¦ßñ_‹)ß6…&¸tùzYæÚÌŸ5T»ÇÿÅ¼šš^¼¹%×Åï¡GÎ´‚^0l‘ñÂï³õÏ¾xÈ'r0scpkĞXº",ÉYë€ì6AºkÔø»&‚·6Ê»#6»–1*ÿÖÖ›¼Ñà[´i3¼ÛÙo¶y|m7šçl^Şˆ§êÈbÈÓ˜õØe.²yHÑàĞR%E€P¤6¹¨t´„ô¨Ş%5Xğ¶ÄM»/×©¹†ëæ;1×¶Ø¹¶È´3)˜‹|A”§5eElÖxÓÊ‡åíV†1q¹Üy…XÊÑ}c³–‹Ú†;ÔFï1#sh.àfn…‹6 “‰Ö¦g¨Âk©¢"«¬ß!zH9Ü	y)Q‹Ş”>ÇL8Cß‰Şcç$/\#ì·‚½ßÏî4Ç¿"* ÊÌRsû÷cŸ„|ğUZ­ÕIxÄ»è@ç™rd0P/ÿ~'Î×Xİ…\i(:RRn‡Vå" í.ÅuÀÎæåeAuÌvHõÈcĞ²ØŒ.yeìO#*U<ìP¾Ò¥	-®ÅÒ Ë%4ãÖ–Ğ	‚«±Åm‚} ÑĞ’—µã._Æx®,É¶sÏ´³R§3	¶ ¥ÇBÂ ¯Ä®ƒdOsDAèd¥^X–˜!hjåÉbWù›‰Å×Ğ4¯’szF·¹ÚŞuæ¿b3Z´ÑWrÆk±íğ‹”Ìø×¿uãA$ç)†àyĞïo÷ÒH„üË‹r±HÚìBiá6=Vu®GŞÆ]~| âÊºÇNk½¹€‘Ê˜RZ÷ì1`0W†÷–=±õJzÁÎ-^EØ¡ÉŠx$G„FŒÈ¹»/iÍ‰ñgi×†(ÜÛë³F¾zLïˆL›n€f^‰Ğ·ibşqØ[§fC²c„61Ş†lT¸ã·æ¤KÅî:ÑX)Íè¿¾¯ˆÏ¦d¾§Ëö‚º7Š7»qóğêPìñÕpƒ9ï ®ÆÔÈ2x_²t#<R¹ÚIu†˜¤uuBBÄ vvB~(Ä¸ SsHé±Â'J2¥É´=Üúõ`nåDko¼¥³ğ;íëÅò$ ó÷–Gâğ4<°Ä¼ÇšAÙG[N‰õAæ$ãš«Ë†¬&—ÓÔBjĞÒĞã®–°	Å¶cn<îoÙmA<ıßÖ…ûÁFÍ´—ïoéó­q7ó‡éTø«t¹h>˜3Gé‚Ì€|’Oò	÷falˆC6ıè<K‹7’>,oæ|Oğ	¨Î…øíI(K¢›?ë²í¶bmî%åå³ì_÷Ïòˆï~ï»ŒZØ!¿:Ğ8á¼ÑĞ¦,SË£r-mI;¼@Ô5»{ìÎ)2LCãi·P"¿•H5<’ÙÄeÚZ¨š]B=âl	› ,H¨[ 'U÷²¯ú¦ü»#ş&Ã¾t/×İŸw<€Õ&³«°³eŞŞ „¶ÍáW@Ì¾l“€¨&5²Ú³Aİöœ½{4Ñfœ¢\RHqñ¸Oå‚ï¹óEm¾à],œŞ˜ Ÿs¯PDÔ’f ¼É‘:N£¾Ë…¸àš»µU§Ï‘¢ÆòípŞZÍÅ=ÛïìÍ|sûCûEŠç•¦?ûõs=¼ƒ0Î9›#I1Áİ‹ãL×†YÜ ğRSP6Y#KİL	hø¶„ôè½%p‚±à@r8Ÿª,÷¦Ÿ•iÇèü­õcÊ¿“r66V&ğr¶-íÿ—‚Œ¢ä*…áØ7MË"oLİ@oôD7M¼jÔƒcn—{ÇD]û‹ªı áQIXåØdA:ñä†÷KûÏØæ:{ôn¼!ºµw“ãİy3gmÃ–_ò½›Òiëï—4Ş8<®KÆàyÕ&)6œ~£ı.h·º@<H‹Ÿôs÷Î†ñ[Z^Ñîòï†÷ E//iÛå"?ì÷mRG¼¸gIf?£“HÔ'>Ô²(.İÜåáAßeÀ,şêÔ+é²˜*ë¦£0®² ™ˆ6aCSKHœYBÉÕuâX°ğ´\M®,/™Ú‰fOõº‰Ô¦²h9]İ.­½qj¤¹(ó=¥­èE:´Öh¯¸Ò÷ÑÎO_´®ºü£ã1kQ¢ Ğôu4™	ì<ƒ–a6dHñ0±…<%Ÿ±ƒ»¦Ó+Æeá§x²)À®Ê& -Ñ…ËétÌx˜FJ$ÎıZ¿ÌvÚ'TƒGéç>}m~
Æ»Ïty;¶â„2 ¥í€.0­^¦˜0Ö² ˜ššör€¦—ĞÎ3‹¼¹M-,	TQ¿Ü=Aòg7œÙ?¨Që8ÑôQ¨ÃÆŞ§HÃmE¤üİôÉÕMÕ·Pào¢ì­ï¸»½ è›:·K¹™o¤[ Z	*l¤Ô]†ã;ÁDo;ñ'Ğ¶R¬]øi—˜óN½¢
“ãË'¸=Ï¦]mÌÌÀ¤RP7SYKQMSC¶%¡Çä-ØÅÈCsÒHmYÔŠº‘

»ç+w#ux/Å-îV+]i¥ı–x¨šÔä°Š¾·¡w¾ÑkùøÆŞóZçË|Êíøè;İ“Õ¢1Á7Rªá¡WC»V+}¯ÒÌÈ+˜Y½¼¡Àweõ,7~İ—=œâÛ¬‹ïE {Fÿq¼İÁo?İ¦ìïÚØºÈË&ºp¹£şgpÄÊ$¿İ­4xóË;w„í¿i H\ñ Ú-éu8öpjwôFhÏznìÿæ¢|HÀõ«²—‡#K=ääÙ˜»@Ü›æV¾œŞŒ¥]®‰­=( uÓu”mìqX·ÃàDîxy—ÛA¸.j#(]„ƒusGf³Ùï7 ´H°r™alKŞ²T÷!9±¸€½´¾éu’”C€=¶½)?v÷q9chÂr-Úíí†„îatdll[ÜT‡·ŞÜÙìàüîèÑ[V£Èˆª7`J¹Ã=ÄSô¸‡ĞõWiRÚ®‡ÂKXa	%,°„“Ÿµl{°ï¹æè´ß˜ˆ©nX’ vÃ}07J®XÂ	KÔg,œŸ%¤SzX~@«¦x¥}ÈÂNwÃï1‰©xwàázÌéòj(²3
™}2EÚ/º>dªõÄôÁµtËœ ×`W¡NúT0Ê>'B
RÉí{Ô€|qUÕQ®±<Ö¯‡­À/Uâ`°WD0xoLaÑòRÂ^vˆk	¯ˆØ°]±Ãîª¥Ñ,q¨kSş¢ØèİìvójÜ‰¬ˆÆ ª1kì÷Jo¬Eš½{T£)Š¿â†İ@¦Lşkoå³‡?UvÜic](åuQ''‹6˜±Vmà.T-º(ü¥®®ù›oßQÚWÛÅ½E¨İ>Td‡‡ôüŞ-Ç[Æöí™õ6&¿±š=67=­ó-ñ‘‚ªeğV¶2Ÿœ¼"3‡çvòšbf}ß‘¼‘,OsEÌC¼iœ'°"Ğvi¥mA}…$MŠÔ:Èš$Ì1¡$¼¿»H|OşíÊkWgÉÿ…æ¿PÒEöÅöùs¡CûÕc)¼nÕó½h	ÂŠP³çC‡²è¢ŞÆo)ât"\°"^1»c1p¦2ıÜâ¨¦ü|ÊÌĞ’k¼ÂÀ€`“we~ıö±w7üNoœ\¯mşIÍNë»M¯åDì¶H5±­¼íOß‚oÆ~÷k…ß‹ÕãhoW6¾Ö¬…¼¹Â–õFQVšÜÛnÒpoŒbÓÆwøÑ¸1®^´î1EdÜnİSŠ şèe^yŞŒû$õÑÒuÔ2ùì\ëò”^óï"~±¶X[Àá¿…4Âif)Ò+T›®ÒíÁ‰f²Q¦Í&¤ûèÆ&ÖÆR2šø° ü#ûâ¤l=™z‰S>în÷¸~;\¾l÷$õVEÈÆ¬"fƒÛo-Q W®‹3}°¯Š§ÜšK¤íF¿Ö^–¿iigZÎob_zÅĞ´Ù÷n¡Ig{YôX çÛFó²”è)˜ãŞ™ß…*ìÚø²o›0à?É1¶?»øŸ¶Ğ6Ö®_Ğş=ƒ%a/wÓWuùcO‹ Ô·4Ï…[êŠ
ÿò®ñÊõ>şò–E®Ù´w»Yly´õSüY¥lÈÖ6Ü¨ÓëñÏË6×¥Ğ­•mª¼şö¶¨7şF­ê$0ëªˆÛ$ÜµºŸEnmÒPş¿y"e:-n=?ƒ-±ö<ó;3ßÂ‰_wkÿ>`ÿäÙ*7ş¼>D‘$Oo—1ÙEöNm»oş¼Ô.™»]ÔÌÓÑ¥UwVØÅŒ¬.ú8æ¬)‰]ÙâŞ”p»07âÓ›î”xŞÅá~‹;^µ~ZŠß¼ÎÓé¤½²Ó<ùúÅ©üswº8™NµRº‹T).ŞVû³È\'E™¾Ôq:S4½ê-t°º¿…¢Lëvà¬ÛˆÔ»'Ôw1ü›®Ù’]œ”âMÛîœyİEJhyy]¬[â(µÍ»gÜvqÓ»¢Írwmğ—Rræ?Ô•@RîÈzû*LÏxb¸Õ/
L º0 ©;JFm't[‚ş6oísïhŠ O•fÂî†KíÇ®'ŸV‹Såº˜œQÅŸİ×iŞ|îjíL¯ñÛhTX_ÙNZZƒÏA7­-	$¶İB…Šnb)Ú®nNwç”‰Ë]Tu­À+Nü "Ö¢ñ'kw\ØÅ"]i¨`‰ûÇY¿‰¹ßYëÕ¥Ó0yĞşÔæFÙ“†¨ìÃé7r“áezÃòf`$İŸ@¹“Ü‚yÇ<ßéôÚâğæ ëÜ ;¨ ¦7ks·G O-r9´á¶ğùÅ/4Õh”¹b¾È\©-o€SœjT;Úâ §9Õ©fšóO¦ Ó^¦3Õ©¦µ¡¼NEßÔÚ»†TÕàÛ*¦]­7í¿Q¬nğeÉIÒ¢×÷ñ½xÇøßV;hc¶#nwoğUI3aèJz”Àáôñ·Y=oš~¢÷Æ¶ÂÀ5„|…ß)Înüù À	«ŠœÛß$ÑCÎ`;&O*
ÇÃ, ãÄµÇá0I,Ò¿ìÄ%p7&ì¿Š½òÕØé~·ïïäİ=‚ã!Î5ÆË¡Fâ"¹¬seƒmdæS,+„W*#1@SKhÇÇ-¡Ä{Š‹äé‚ĞWgË]^äHlj¯×÷r*¼ê•o!vz·øFë}ÅËÎ‚s@|èÈÅÙ
pÇ\cr¤Zóm‹i@—Khê6¯ ik±› ]a,€Ü§Ü1]³E· .j:k‘ş¤§n2À&ñD³¨ìÕ.ê¶Ÿİk³¶A÷v\ó 5mvëßïhÕ°²öDğ.ìÙåÀI{Ry+Õî0™ØPŞ›‹ûnî Çá‘J¿èğ	@ğQ0|ºL®© c7F#»
¼§ô»øx‰â+OxmõhÿPİ@©š 'Û`HÄÜ™w‡ïtÒÈÎúµµ>—ÁVj—Şò•³“îVÑ–u¨NM9Í8¡øjÍ)Yú«!Mß…T¾úî'B›>,x§¸ Sª‰:Nr`EèÈ.Iğ‚:Ä$ô´ZhÑŸ	%‘rKèê'&Şl^ÓDBÁø©ÇOÅê~Ş*øÎëÁß°ãßÛ\e?«¶ÆÑ¤F†á9J5¶×ds8kÅéíPwè:ƒŞÁ÷‰ªoÔMŒŒÕü“Št2úààøLzßj…ÄãõŒÙš\¡ñ?ØEAç~°p}%¾G3¢°ş˜û;£ü¸¸Ê^Ïö¢-ıYøÙ÷XŞ[Ùm`ôú²^mòÆµGìÈ.ŞÃdwñ.¾´ĞŸ_H»ƒ™Òlo®Æc Ò_±ú&#ªşåæiãåm[ô‘W¢v~OÓĞúA¿	Ûj„£cjØ¹ 7¢t”;j®=úÒµ»Š¿ƒ=[Ş¸ÕXEîlÆ ¸ÇÑ+ò©ùÙø[ú;´¿unÛ¼t£­ IêsßB86±v¶–ã1üo„x öŒuGdÆšH®İiO`‰Œ	â’sFâÿ¤KÆ-ˆ´AÙ3­ÈùğüÊà5ßó´à™ß_Õ1ç7øOzÃwöÇÇeşÓî1ÿ®¢¥ãKÚûñA^Ì˜8;{Hã—i‘KxollÆ¢_¾zÙwßšÌ&úòƒê›MñEK‹7Ò@ã†&ƒ‰>}[Ìˆ2Œä‘¤Œk7ã‚™h—ê‰÷×îôÙWCÍ`‘ô¸ ¨’Àùšâ vŞ´ı[Åc€ô´Ê-!µå÷‚Bdeã;/€9v†Ÿl°AàÚÜ]8½Jõ»0™¹À‘aÃË7ş­ò”“òåÇ–÷Å9Ì#ô =Gó…‚ñ|˜=òç©›±õÜl¿\$×%Ğ£ –¬	Å‚‚²¡m?~İÉ] ÿ}tL~¡ç?:¨{Çb9rv€éš4áKúqòßUâ«±Œ§úÓ5`M*®;{V 50í¨!İ$‰³°_OÓjémk#Ô"j‘L“KojÃƒ†HşŞ!˜î.%Ü0–ãŞ‚i¯E3·‘dGøÈË2ÆµôÌ´™iÕ%h¦Æ—`—ŸK#íªÚb$u´È+»~×‡øy£t½Ú4à7…[‚†‚àtuBB¼v0çÏ7UóÓœÍ;ŒJÁ)ËÙ
e&H5;ïæö,%vû»³Âµ¿3õèœè9·²BçÿÒmD¡ñ-¦Ùí¹ã§·WcTü×hßCzUı‹idíØT£lyªìôpcğ™Ÿ¹¹Ü(züÿ`Ú’ŠÄ=zïÕ|5Iôs5jdÕ@ı„v5®ï‘Ü&ˆR@6H¾h]YSêì£ğ“
º«ày"×èš#àqjõµ:Ì£\"ÂŞèÂ‚èç;[A×H|ëTZbÚn˜bl÷–TI]ø#’®Êf#Ol—é›fJfÁ’Ô¼N Iz&¢	­´…%°ım¹‰Í+µ³ Mnü	ncŠ›YèfĞ–ÁMş…“T©1Óš*ı`fU‘f>ê–ÛÚ#MfÑønĞ[•>_…+ÃmáR·S\†‚qmøĞ4WÌî‚BìBš“İÂ]7Ü„àÛ¨ÚƒHxôÃˆr“‡ÓÏçR². 0*…Ê \†¾€^ °ÿI€Î6¹u„*/8Eè/-¢æJõíD
Â¬¨÷³¦öÈÇ«D'*Îé[o¯CÛíØY‚†;´ÁO|1>PßŸ€ˆ†3K‚Â[ÒbÁÁÕ 6gºÜI\cZÇ•ÀœiÚŠZ]‰kƒ™&oÅÚÉ;ûçLßL7.ó¥Q·$åHáÑö´j1¬ğ¾¿SøYI*­äßåûxıwç;ï¸`è´:{˜à.t‡ÛÈÈ Vˆ‰†¨pv@Ò€Î@a¡GO[cX^¾ºM³hN†	h[QJ›šŞE‡¸¤1<‡ìZ<5Äò·—º®ª£SIÛ€³çÒ¶N4Â^ñ§ò€®òˆ#¤8ŒÄj²=â˜]Æ²Ho‰e"ãĞåjãĞ–Ğ	–ª°ÅltáƒÔ†¹¹è’ÙA8êÑAÌ¾
lÃPÒ¤8yT€í‚BdµÜv¿…q +¸óÁF'ãİˆÜ±ÃVd‹q¸˜œ‚Ç@Ë¾Í1mgy!nnÓÒèu¦	Å‚‚¬!l×t¹£¹åæšŸ;˜kÃëË\‹Vj¹-ÒÊC¶bÛEóõ]ä,]Ğ{âö»ô4¨‹<_Ëœ[ª•=KX^juÖè„ÑmdJbd.D2iñ¹@S–Ğ‰S,üG¹‹k‚ta©Ú+Ü;c‘Eo&†Í-å¸HÓ^ı\
[ˆËÕ_KÎğ&BíquşzV¼Fúë;üÏºC)2ñø—-/L£sC‡ˆçğ­tÄ÷€ £Å¡#ÇÎÍ].Ğ	3—„Î²âÙ`gi± ò
@lºH}Æèú	¹fD7px"Ü=˜æ1N„±ú-óZx¥ı¤ÜØ¼¼TWàÙ<ìz`+¥»²FxÁA¦vNé1µĞ4·„ôØÅ%r‚±€ıdÄ»‚ÍùDÇ GP~Ä¼uPX‹vIÜ~zµ©#”cû¾ø^0ïÖ1©óWï(·+äF'<W–Üi/ƒ«Çè‚¯£¬^AUj•Û9®ğÎ9±›&ú€¦–Ğç¸„N ,d.'Bîƒ|Ó¹öÊíqÔ™Y M€/¨@ÈÑ .iÜé0¡#:RØá)êRÇ¯¦ÓñµÚMƒáë§jsEDÿ²ÅNp£$9p‚YT=8ìEè®Ğuö 
Ã*0bGï14œº\B:_t1Ïê„Xêê„v hçzÎ-|»ÎœFş>pÄÎS¾XÈ¾ÛÇ‘t@Ö¼-v¬c‰D òÃÎÊüŸÕ$íeˆ €›>æÈ €x;b!û^ÌxÈv•Y½É¡Ûfe:]Ü‰…FMŒºW¤’…îE*Ö>?Ybw)ò]ÔééŞ2Şğ°Zî,Ç‡Æˆw¨£ldd)çö)]ü#T!i»!TT$ªä«Ğ^´hµ–İ<¯Ô5ì˜¼È¶~Bîç/Ø#ìî¾€_éĞØğ“cf^ísµTæîøè.oÂ<ƒ©GÁ!¼Å˜ìÙä‹ÄƒÀ”…äK•cÔBĞq	èQ–KİÙ	iåx×‹[=òl's¶Ì5Muc®-«s5ÁwÌ×Ö1¹†·Ì5Ñuc®†º¹šë;æ×İ1\ãxÇsmåÑ5Ÿ¤‡†ÎÙôâÂaY_DÔÀoè:$ŞÃî§“šyÄ±Ö.<Ğft³Á#idÃLòÕ\FòB[’ßH3v@Ò€ÎJ÷¡ÎĞˆ¥ªNN°³N|‡æ‘9i‰h£K±ïtˆòX”L4Àñ¦LB:Şò`±ÎŞÈ(Óëò³ Î’{DÏ.@GôÈ"ñÖ›‘ª‹é‘ÒEêLçÒâåb>,¶Yâ=€u%¿ê,`CCŒV g¤4Öi¯·Ş¯êd	¤Å´ÁåÑcN½åUÁî™dĞ<qg8é;Õ ó#»PkFJ!¾“JŒthešZBüZzAÚ7¸XN /(xÉ;1×+ŞÇ\­ysğ's 0£k¶h<Kğ‚ pZ²-2îBµÀÛw[€<ç—W§ˆšíßy¸Vˆ4`ƒìÇB&¤ZÆLù²Eš Ë%4Ç¦-¡dam‹İüBSš¯sµ×wÌ×lØ1¹æÊ?äº@“O_JÙ32Îˆlde°d˜HVQ&RÊÂ‡ıTYÚ-O&Ÿ-"¼ã—gŸq“!×#ÛÓ‚áĞéYò©¨b3ª?5-‹;²Î%¤¸£Ü…&à¶Ûü‚#®s5ÔwÌ×\Ø1º†‹6{IÏ</áS¹×ä“\Šåª…©HÜ®•¿o&b;Ok…_»ç5q™skjq±[æ¸ÚéªÑ^æãšj£äMvYvcü4WEşü«Ëš\µ=Ïô®”Ÿ¾dÅç,$LZT‹­ş–2sm8‘-¹«—gwô“Aâ#ÜÔĞê™é«¬Â/®äDcÔBĞæbòËo?J‹î~aĞôv1×ÜÇ\-qskgh£%ñ2ædx`¢IZK	£¦>[,ôğËr2ş‹¹­àÚY"¥5Õ#oUæD
Nª(Ûµ]–Xç--mÈ 3Ma´èÚ2ÃÎ4|âvÀD°cj¡Uhe	 h!š`,H Z'ö9„&Ö¹Zä;æk—ë˜\‹^Çæ¬;