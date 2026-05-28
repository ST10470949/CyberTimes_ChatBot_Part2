using System;
using System.Collections.Generic;
using System.Text;

namespace CyberSecurity_Part2._2
{
    public static class TopicManager
    {
        // Topics maps a short key (like "phishing") to a full explanation string.
        // Keys are compared in a case-insensitive way so users can type upper or lower case.
        // Each explanation is a friendly paragraph intended to teach users about each topic.
        public static readonly Dictionary<string, string> Topics = new Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase)
        {
            // Each entry below maps a topic key to a friendly explanation paragraph.

            { "password",
              "🔐 STRONG PASSWORD SECURITY\n\n" +

              "📖 What it is:\n" +
              "A password is your first line of defence against unauthorised access to your accounts. " +
              "Strong password security means creating passwords that are extremely difficult for attackers or automated tools to guess or crack.\n\n" +

              "💡 Simple Analogy:\n" +
              "Think of your password like the key to your house. A weak password is like a key that thousands of other houses share — " +
              "anyone who finds one copy can open your door. A strong, unique password is like a custom key that only fits your specific lock.\n\n" +

              "✅ What a strong password looks like:\n" +
              "• At least 12-16 characters long\n" +
              "• Mix of uppercase, lowercase, numbers and symbols\n" +
              "• Example of a weak password: password123\n" +
              "• Example of a strong password: T!g3r#Sky92@Blue\n" +
              "• Even better — use a passphrase: 'Coffee&Rain!Makes_Me_Happy2024'\n\n" +

              "⚠ Signs your password may be compromised:\n" +
              "• You receive login alerts from locations you do not recognise\n" +
              "• Your account sends emails or messages you did not write\n" +
              "• You are suddenly logged out of your accounts unexpectedly\n" +
              "• Unfamiliar purchases appear on your bank or shopping accounts\n\n" +

              "🌍 Real World Example:\n" +
              "In 2012, LinkedIn suffered a massive data breach where over 117 million passwords were stolen. " +
              "Most of the compromised passwords were simple words or number combinations. " +
              "Users who reused those passwords on other sites — like their email or banking — had those accounts compromised too, " +
              "even though those sites were never hacked directly.\n\n" +

              "🛠 Recommended Tools:\n" +
              "• Bitwarden — free, open-source password manager\n" +
              "• LastPass — popular and easy to use\n" +
              "• 1Password — great for families and teams\n" +
              "• KeePass — offline password manager for privacy-focused users\n\n" +

              "🚨 What to do if your password is stolen:\n" +
              "1. Change the compromised password immediately on that account\n" +
              "2. Change the same password on ANY other site where you used it\n" +
              "3. Enable two-factor authentication on the affected account\n" +
              "4. Check haveibeenpwned.com to see if your email appears in known breaches\n" +
              "5. Monitor your bank statements for suspicious transactions\n" +
              "6. Notify the platform's support team if you suspect account takeover"
            },

            { "phishing",
              "🎣 PHISHING ATTACKS\n\n" +

              "📖 What it is:\n" +
              "Phishing is a cyberattack where criminals impersonate trusted organisations or people to trick you into revealing " +
              "sensitive information like passwords, banking details or personal identification data.\n\n" +

              "💡 Simple Analogy:\n" +
              "Imagine receiving a letter that looks exactly like it came from your bank — same logo, same colours, same tone. " +
              "But it was actually written by a criminal in a garage. That is phishing. The fake looks so real that many people fall for it without realising.\n\n" +

              "🎯 Types of Phishing:\n" +
              "• Email Phishing — fake emails pretending to be from banks, Netflix, PayPal or government agencies\n" +
              "• Spear Phishing — highly targeted attacks aimed at a specific person using their personal details\n" +
              "• Smishing — phishing delivered via SMS text messages (e.g. 'Your package is held, click here')\n" +
              "• Vishing — phishing done over a phone call (e.g. someone pretending to be from SARS or your bank)\n" +
              "• Clone Phishing — a legitimate email you already received is copied and resent with a malicious link replacing the real one\n\n" +

              "⚠ Warning Signs:\n" +
              "• Urgent language like 'Your account will be closed in 24 hours'\n" +
              "• Email sender address does not match the real company domain\n" +
              "• Poor grammar and spelling mistakes in the message\n" +
              "• Links that show a different URL when you hover over them\n" +
              "• Unexpected attachments you were not expecting\n" +
              "• Requests for personal information via email or SMS\n\n" +

              "🌍 Real World Example:\n" +
              "In 2016, Hillary Clinton's campaign chairman John Podesta received an email claiming to be from Google saying his password needed to be changed urgently. " +
              "He clicked the link and entered his credentials. The email was a spear phishing attack. " +
              "His entire email inbox — containing thousands of sensitive political emails — was stolen and later published publicly. " +
              "One click caused one of the most damaging political leaks in recent history.\n\n" +

              "🚨 What to do if you clicked a phishing link:\n" +
              "1. Disconnect from the internet immediately\n" +
              "2. Run a full antivirus scan on your device\n" +
              "3. Change the password of any account you may have entered details for\n" +
              "4. Enable 2FA on those accounts right away\n" +
              "5. Check your bank statements for unauthorised transactions\n" +
              "6. Report the phishing email to your email provider and to the company being impersonated\n" +
              "7. Report it to the South African Cybercrime Hub at cybercrimehub@saps.gov.za if you are in South Africa"
            },

            { "malware",
              "🛡 MALWARE — MALICIOUS SOFTWARE\n\n" +

              "📖 What it is:\n" +
              "Malware is any software deliberately designed to damage, disrupt or gain unauthorised access to a computer system. " +
              "The word comes from combining 'malicious' and 'software'. It is one of the most common tools cybercriminals use.\n\n" +

              "💡 Simple Analogy:\n" +
              "Think of malware like a biological virus for your computer. Just as a cold virus sneaks into your body, " +
              "replicates itself and makes you feel terrible, malware sneaks into your device, spreads and causes damage — often without you knowing it is there.\n\n" +

              "🎯 Types of Malware Explained:\n" +
              "• Virus — attaches itself to files and spreads when those files are shared or opened\n" +
              "• Worm — spreads automatically across networks without needing a host file\n" +
              "• Trojan — disguises itself as legitimate software to trick you into installing it\n" +
              "• Spyware — silently monitors your activity, keystrokes and personal data\n" +
              "• Adware — floods your screen with unwanted advertisements\n" +
              "• Ransomware — encrypts your files and demands payment to restore access\n" +
              "• Rootkit — hides deep in your system to give attackers long-term secret access\n" +
              "• Keylogger — records every key you press to steal passwords and messages\n\n" +

              "⚠ Signs your device is already infected:\n" +
              "• Your device is running unusually slowly for no clear reason\n" +
              "• Pop-up advertisements appear constantly even when no browser is open\n" +
              "• Programs open or close on their own without you doing anything\n" +
              "• Your browser homepage or search engine changed without your permission\n" +
              "• You notice unfamiliar programs installed that you did not download\n" +
              "• Your internet data is being used up faster than normal\n" +
              "• Your antivirus has been disabled and you cannot turn it back on\n\n" +

              "🌍 Real World Example:\n" +
              "In 2017 the WannaCry ransomware attack spread across 150 countries and infected over 200,000 computers in a single day. " +
              "It targeted hospitals, banks and government agencies. The UK's National Health Service was hit hardest — " +
              "doctors could not access patient records, surgeries were cancelled and ambulances were diverted. " +
              "The attack caused an estimated $4 billion in damages worldwide. It spread because organisations had not installed a critical Windows security update.\n\n" +

              "🛠 Free Removal Tools:\n" +
              "• Malwarebytes Free — excellent for scanning and removing existing malware\n" +
              "• Windows Defender — built into Windows 10 and 11, good baseline protection\n" +
              "• Avast Free Antivirus — well-rounded free protection\n" +
              "• Kaspersky Virus Removal Tool — powerful standalone scanner\n\n" +

              "🚨 What to do if your device is infected:\n" +
              "1. Disconnect from the internet and any networks immediately\n" +
              "2. Run a full scan using Malwarebytes or your antivirus software\n" +
              "3. Boot into Safe Mode and scan again to catch malware hiding from normal scans\n" +
              "4. Remove all detected threats and restart your device\n" +
              "5. Change all your passwords from a clean, uninfected device\n" +
              "6. If the infection persists, consider a full factory reset as a last resort\n" +
              "7. Restore your files from a clean backup taken before the infection"
            },

            { "social engineering",
              "🎭 SOCIAL ENGINEERING\n\n" +

              "📖 What it is:\n" +
              "Social engineering is a type of cyberattack that targets human psychology rather than technical systems. " +
              "Instead of hacking software, attackers hack people — manipulating them into giving away confidential information or performing actions that compromise security.\n\n" +

              "💡 Simple Analogy:\n" +
              "Imagine a stranger walks up to your workplace wearing a delivery uniform and carrying a box. " +
              "They say confidently 'I need to drop this off in the server room.' Most people would let them in without question because they look and sound legitimate. " +
              "That is social engineering — using appearance, authority and confidence to bypass security.\n\n" +

              "🎯 Types of Social Engineering Attacks:\n" +
              "• Pretexting — creating a fake scenario to extract information (e.g. pretending to be an IT technician who needs your login)\n" +
              "• Baiting — leaving infected USB drives in public places hoping someone will plug them in out of curiosity\n" +
              "• Tailgating — physically following an authorised person through a secure door without using credentials\n" +
              "• Quid Pro Quo — offering something in exchange for information (e.g. 'I will fix your computer if you give me your password')\n" +
              "• Vishing — voice phishing over a phone call pretending to be from a bank or government\n" +
              "• Impersonation — pretending to be a colleague, manager or authority figure via email or in person\n\n" +

              "⚠ Warning Signs:\n" +
              "• Someone is creating unusual urgency or panic to pressure you into acting fast\n" +
              "• A request comes from an unfamiliar person claiming high authority\n" +
              "• You are being asked to bypass normal security procedures 'just this once'\n" +
              "• Something feels off about a phone call or message even if you cannot explain why\n" +
              "• You are being asked for information that the real person or company should already have\n\n" +

              "🌍 Real World Example:\n" +
              "In 2020, Twitter suffered a massive breach not through hacking software but through social engineering. " +
              "Attackers called Twitter employees pretending to be from the internal IT department. " +
              "They convinced employees to hand over credentials to internal admin tools. " +
              "Using those tools, the attackers hijacked the accounts of Barack Obama, Elon Musk, Apple and dozens of other high-profile accounts " +
              "and posted Bitcoin scam messages. Over $100,000 was stolen in hours — all because of a phone call.\n\n" +

              "🛡 How to Verify Someone's Identity:\n" +
              "• Hang up and call the organisation back using the official number from their website\n" +
              "• Ask for an employee ID number and verify it with the company directly\n" +
              "• Never give out passwords even to someone claiming to be IT support\n" +
              "• Use a code word system with your team for sensitive requests\n\n" +

              "🚨 What to do if you were socially engineered:\n" +
              "1. Report it to your IT security team or manager immediately\n" +
              "2. Change any passwords or credentials you may have shared\n" +
              "3. Document everything you remember about the attacker — voice, number, what they said\n" +
              "4. Alert colleagues so they are aware of the same attack targeting your organisation\n" +
              "5. Review security awareness training to help your team recognise it in future"
            },

            { "2fa",
              "🔒 TWO-FACTOR AUTHENTICATION (2FA)\n\n" +

              "📖 What it is:\n" +
              "Two-Factor Authentication adds a second layer of security to your accounts beyond just a password. " +
              "Even if an attacker steals your password, they cannot access your account without also having the second factor.\n\n" +

              "💡 Simple Analogy:\n" +
              "Think of 2FA like an ATM card. To withdraw money you need two things: " +
              "the physical card (something you have) AND your PIN (something you know). " +
              "Stealing just the card or just the PIN is not enough — an attacker needs both. " +
              "2FA works exactly the same way for your online accounts.\n\n" +

              "🎯 Types of 2FA:\n" +
              "• SMS Code — a one-time code sent to your phone via text message (convenient but least secure)\n" +
              "• Authenticator App — generates a time-based code every 30 seconds (much more secure than SMS)\n" +
              "• Hardware Key — a physical USB device like a YubiKey that you plug in to verify your identity\n" +
              "• Biometric — fingerprint or facial recognition as the second factor\n" +
              "• Email Code — a one-time code sent to your email address\n\n" +

              "🛠 Recommended Authenticator Apps:\n" +
              "• Google Authenticator — simple and widely supported\n" +
              "• Microsoft Authenticator — great for Microsoft accounts and supports backup\n" +
              "• Authy — best option as it supports multi-device backup so you do not lose access if you lose your phone\n" +
              "• 1Password — combines password management and 2FA in one app\n\n" +

              "🏆 Which accounts to prioritise for 2FA first:\n" +
              "1. Your primary email account — everything else can be reset through email\n" +
              "2. Online banking and financial accounts\n" +
              "3. Social media accounts — Facebook, Instagram, Twitter\n" +
              "4. Work accounts and VPNs\n" +
              "5. Cloud storage — Google Drive, Dropbox, OneDrive\n\n" +

              "⚠ What if you lose access to your 2FA device:\n" +
              "• Most platforms give you backup codes when you set up 2FA — store these safely offline\n" +
              "• Use Authy which supports encrypted cloud backup across multiple devices\n" +
              "• Contact the platform's support team with identity verification to regain access\n" +
              "• Never store backup codes on the same device as the authenticator app\n\n" +

              "🌍 Real World Example:\n" +
              "In 2019, a major SIM-swapping attack targeted cryptocurrency investors. " +
              "Attackers called mobile phone providers, impersonated the victims and convinced staff to transfer the victim's phone number to a new SIM card they controlled. " +
              "Once they had the SMS 2FA codes, they drained millions in cryptocurrency. " +
              "Users who used authenticator apps instead of SMS codes were completely unaffected by this attack.\n\n" +

              "🚨 What to do if your 2FA is compromised:\n" +
              "1. Immediately log into the affected account and disable the compromised 2FA method\n" +
              "2. Set up a new authenticator app on a fresh device\n" +
              "3. Change your password on that account\n" +
              "4. Review recent account activity for any unauthorised access\n" +
              "5. Contact the platform's security team to report the breach"
            },

            { "safe browsing",
              "🌐 SAFE BROWSING\n\n" +

              "📖 What it is:\n" +
              "Safe browsing means taking deliberate precautions to protect yourself and your data while using the internet. " +
              "Most cyberattacks begin with a single careless click — safe browsing habits dramatically reduce your risk.\n\n" +

              "💡 Simple Analogy:\n" +
              "Browsing the internet without safety habits is like walking through an unfamiliar city at night with your wallet hanging out of your pocket. " +
              "Most streets are fine, but some are dangerous — and without awareness, you will not know the difference until it is too late.\n\n" +

              "🔍 HTTP vs HTTPS — What it means:\n" +
              "• HTTP — data sent between you and the website is unencrypted, meaning anyone on the same network can read it\n" +
              "• HTTPS — data is encrypted so it cannot be intercepted or read by outsiders\n" +
              "• Always look for the padlock icon in your browser address bar before entering any personal information\n" +
              "• Never enter passwords or payment details on a site that only shows HTTP\n\n" +

              "🔍 How to check if a link is safe before clicking:\n" +
              "• Hover over the link with your mouse — check the actual URL that appears at the bottom of your browser\n" +
              "• Use virustotal.com — paste any suspicious URL to scan it against dozens of security engines\n" +
              "• Use Google Safe Browsing: transparencyreport.google.com/safe-browsing/search\n" +
              "• Be suspicious of shortened URLs like bit.ly — use unshorten.it to reveal the full destination first\n\n" +

              "🛠 Recommended Browser Extensions:\n" +
              "• uBlock Origin — blocks ads, trackers and malicious scripts\n" +
              "• HTTPS Everywhere — forces HTTPS on websites that support it\n" +
              "• Privacy Badger — automatically blocks invisible trackers\n" +
              "• Bitwarden — autofills passwords only on the correct legitimate website\n\n" +

              "⚠ Warning Signs of a Dangerous Website:\n" +
              "• No padlock icon or HTTPS in the address bar\n" +
              "• Pop-ups saying your device is infected and urging you to download something\n" +
              "• The URL has slight misspellings like 'arnazon.com' instead of 'amazon.com'\n" +
              "• The site asks for personal information immediately without explanation\n" +
              "• Excessive redirects that take you to unexpected pages\n\n" +

              "🌍 Real World Example:\n" +
              "In 2021 a campaign called CryptoRom targeted smartphone users through dating apps. " +
              "Victims were directed to fake cryptocurrency investment websites that looked completely professional with real-looking charts and balances. " +
              "Users deposited real money thinking they were investing. When they tried to withdraw, the sites disappeared. " +
              "Over $1.4 billion was stolen globally. Every victim reached these sites through unverified links shared in chat messages.\n\n" +

              "🚨 What to do if you visited a dangerous website:\n" +
              "1. Close the browser tab immediately\n" +
              "2. Clear your browser cache and cookies\n" +
              "3. Run a full antivirus scan\n" +
              "4. If you entered any personal details, change those passwords immediately\n" +
              "5. Check your bank statements if any financial information was entered"
            },

            { "ransomware",
              "💣 RANSOMWARE\n\n" +

              "📖 What it is:\n" +
              "Ransomware is a type of malware that encrypts all the files on your device, making them completely inaccessible. " +
              "The attacker then demands payment — usually in cryptocurrency — in exchange for the decryption key to restore your files.\n\n" +

              "💡 Simple Analogy:\n" +
              "Imagine coming home to find every room in your house padlocked from the outside. " +
              "Slipped under the front door is a note: 'Pay R50,000 in Bitcoin and we will give you the keys. You have 72 hours.' " +
              "Your furniture is still there, your photos are still there — but you cannot reach any of it. That is exactly what ransomware does to your files.\n\n" +

              "🎯 How Ransomware Spreads:\n" +
              "• Phishing emails with infected attachments (most common method)\n" +
              "• Clicking on malicious links in emails or on websites\n" +
              "• Downloading cracked software or pirated games\n" +
              "• Exploiting unpatched security vulnerabilities in outdated software\n" +
              "• Through Remote Desktop Protocol (RDP) with weak passwords\n\n" +

              "⚠ Signs you may have ransomware:\n" +
              "• Files suddenly have strange new extensions like .locked, .encrypted or .wcry\n" +
              "• You cannot open documents, photos or videos that were working fine before\n" +
              "• A ransom note appears on your screen with payment instructions\n" +
              "• Your desktop wallpaper changes to a ransom demand message\n" +
              "• Your device suddenly runs extremely slowly as files are being encrypted\n\n" +

              "🌍 Real World Examples:\n" +
              "• WannaCry (2017) — infected 200,000 computers across 150 countries in one day. Hit the UK's NHS, causing surgery cancellations. Damage: $4 billion.\n" +
              "• Colonial Pipeline (2021) — ransomware shut down the largest fuel pipeline in the USA for 6 days, causing fuel shortages across the East Coast. The company paid $4.4 million in ransom.\n" +
              "• Garmin (2020) — the GPS and fitness tracker company was taken offline for days. Estimated ransom paid: $10 million.\n\n" +

              "❓ Should you pay the ransom:\n" +
              "No — and here is why:\n" +
              "• Payment does not guarantee you will get your files back\n" +
              "• It funds criminal organisations and encourages further attacks\n" +
              "• Paying once marks you as a willing victim — you may be targeted again\n" +
              "• Law enforcement agencies including Interpol advise against paying\n\n" +

              "🚨 What to do the moment ransomware hits:\n" +
              "1. Disconnect your device from Wi-Fi and unplug all network cables immediately\n" +
              "2. Shut down the device to stop encryption if it is still in progress\n" +
              "3. Do NOT pay the ransom\n" +
              "4. Report to your IT team or law enforcement immediately\n" +
              "5. Check nomoreransom.org — free decryption tools exist for many ransomware strains\n" +
              "6. Restore your files from a clean offline backup\n" +
              "7. Wipe the device completely and reinstall the operating system if no decryption tool exists"
            },

            { "public wifi",
              "📶 PUBLIC WI-FI SAFETY\n\n" +

              "📖 What it is:\n" +
              "Public Wi-Fi refers to wireless networks available in places like cafes, airports, shopping malls and hotels. " +
              "While convenient, these networks are frequently unsecured and heavily targeted by cybercriminals.\n\n" +

              "💡 Simple Analogy:\n" +
              "Using public Wi-Fi without protection is like having a private conversation in a crowded restaurant. " +
              "You cannot see who is listening, but anyone nearby can potentially hear every word you say. " +
              "A VPN is like wrapping that conversation in a soundproof bubble — only you and the person you are speaking to can hear it.\n\n" +

              "🎯 How Attackers Exploit Public Wi-Fi:\n" +
              "• Man-in-the-Middle Attack — the attacker secretly positions themselves between you and the Wi-Fi router, " +
              "intercepting everything you send and receive including passwords and messages\n" +
              "• Evil Twin Attack — the attacker sets up a fake Wi-Fi hotspot with a convincing name like 'Starbucks_Free_WiFi' " +
              "right next to the real one — when you connect, all your traffic goes through them\n" +
              "• Packet Sniffing — using special software to capture and read unencrypted data packets travelling over the network\n" +
              "• Session Hijacking — stealing your session cookies to take over accounts you are already logged into\n\n" +

              "⚠ How to Spot a Fake Hotspot:\n" +
              "• Ask staff for the exact official Wi-Fi name — do not guess or connect to the strongest signal\n" +
              "• Be suspicious of networks with no password required\n" +
              "• Watch for duplicate network names with slight differences e.g. 'Airport_WiFi' vs 'AirportWiFi'\n" +
              "• If your device connects automatically to a network you do not recognise, disconnect immediately\n\n" +

              "🛠 Recommended Free VPN Options:\n" +
              "• ProtonVPN Free — no data limit, based in Switzerland, strong privacy\n" +
              "• Windscribe Free — 10GB per month free with good speeds\n" +
              "• TunnelBear Free — easy to use, 500MB per month free\n" +
              "• Note: Avoid completely unknown free VPNs — some sell your browsing data\n\n" +

              "🌍 Real World Example:\n" +
              "In 2017 security researchers at Kaspersky Lab demonstrated a live evil twin attack at a major tech conference. " +
              "They set up a fake hotspot near the venue. Within hours, dozens of conference attendees — including security professionals — " +
              "had connected to the fake network. The researchers intercepted login credentials, emails and financial data " +
              "without any of the victims realising. It took under 30 minutes to set up.\n\n" +

              "🚨 What to do if you connected to a suspicious network:\n" +
              "1. Disconnect immediately\n" +
              "2. Forget the network so your device does not auto-reconnect\n" +
              "3. Change passwords for any accounts you accessed while connected\n" +
              "4. Enable 2FA on those accounts\n" +
              "5. Run a malware scan on your device\n" +
              "6. Check your bank and email for any unauthorised activity"
            },

            { "identity theft",
              "🕵 IDENTITY THEFT\n\n" +

              "📖 What it is:\n" +
              "Identity theft occurs when someone steals your personal information and uses it to impersonate you — " +
              "opening bank accounts, applying for credit, making purchases or committing crimes in your name.\n\n" +

              "💡 Simple Analogy:\n" +
              "Imagine someone found a perfect copy of your ID, your face and your signature. " +
              "They walk into a bank, apply for a loan of R200,000 in your name, take the money and disappear. " +
              "You only find out three months later when debt collectors start calling you about a loan you never took out. " +
              "That is identity theft — and recovering from it can take years.\n\n" +

              "🎯 How Identity Theft Happens:\n" +
              "• Phishing attacks that steal your ID numbers, passwords and banking details\n" +
              "• Data breaches from companies that store your information\n" +
              "• Social media oversharing — posting your ID number, address or birthdate publicly\n" +
              "• Physical theft of your wallet, ID document or mail containing personal information\n" +
              "• Shoulder surfing — someone watching you enter a PIN or password in public\n" +
              "• Fake job applications that ask for your ID and banking details upfront\n\n" +

              "⚠ Signs your identity may already be stolen:\n" +
              "• You receive bills or statements for accounts you never opened\n" +
              "• Your credit application is rejected despite having a good credit history\n" +
              "• Unfamiliar transactions appear on your bank statements\n" +
              "• Debt collectors contact you about debts you do not recognise\n" +
              "• Your SASSA, SARS or government account shows activity you did not do\n" +
              "• You stop receiving expected mail — a thief may have redirected it\n\n" +

              "🔍 How to check if your identity has been stolen:\n" +
              "• Check your credit report at TransUnion, Experian or Compuscan (free annually in South Africa)\n" +
              "• Visit haveibeenpwned.com to check if your email is in any known data breaches\n" +
              "• Check your SARS eFiling account for returns you did not submit\n" +
              "• Contact the South African Fraud Prevention Service (SAFPS) to check for impersonation flags\n\n" +

              "🛡 Credit Freeze — Your Most Powerful Protection Tool:\n" +
              "A credit freeze prevents any new credit from being opened in your name, even by you, until you lift it. " +
              "It is free, does not affect your existing accounts and is one of the strongest protections against identity theft. " +
              "Contact TransUnion or Experian in South Africa to request one.\n\n" +

              "🌍 Real World Example:\n" +
              "In 2017, the Equifax data breach exposed the personal information of 147 million people including names, " +
              "ID numbers, birthdates, addresses and credit card numbers. " +
              "Years later, victims continued reporting fraudulent credit applications and tax returns filed in their names. " +
              "Some victims spent over 200 hours of their own time over several years trying to clear their credit records.\n\n" +

              "🚨 Steps to recover from identity theft:\n" +
              "1. Report it to the South African Police Service and get a case number\n" +
              "2. Contact SAFPS at 0860 101 248 to place a protective registration on your identity\n" +
              "3. Notify your bank and request new account numbers and cards\n" +
              "4. Place a fraud alert or credit freeze with all three credit bureaus\n" +
              "5. Report to SARS if you suspect your tax profile has been compromised\n" +
              "6. Keep detailed records of every step — you will need them for disputes"
            },

            { "updates",
              "⬆ SOFTWARE UPDATES\n\n" +

              "📖 What it is:\n" +
              "Software updates are patches released by developers to fix bugs, improve performance and — most critically — " +
              "close security vulnerabilities that attackers can exploit. Keeping software updated is one of the simplest and most effective cybersecurity actions you can take.\n\n" +

              "💡 Simple Analogy:\n" +
              "Think of your software like a house. Over time, the locks wear out and gaps appear in the walls that burglars can exploit. " +
              "Updates are like a team of builders coming to fix every crack, reinforce the locks and patch every gap. " +
              "If you keep postponing the builders, the gaps just keep growing — and attackers know exactly where those gaps are.\n\n" +

              "🎯 What is a Zero-Day Vulnerability:\n" +
              "A zero-day is a security flaw that is known to attackers but has not yet been fixed by the software developer. " +
              "The name comes from the fact that developers have had 'zero days' to fix it. " +
              "Zero-days are extremely dangerous because no patch exists yet. " +
              "Once a patch is released, you must install it immediately — because from that moment, attackers know exactly what the vulnerability was.\n\n" +

              "⚠ Real Consequences of Ignoring Updates:\n" +
              "• The WannaCry ransomware attacked only computers that had not installed a Windows update released two months earlier\n" +
              "• The Equifax breach in 2017 occurred because they failed to patch a known Apache vulnerability for two months after the fix was available\n" +
              "• Outdated browsers are the most common entry point for drive-by download attacks\n\n" +

              "🛠 How to Check for and Enable Updates:\n" +
              "On Windows:\n" +
              "• Go to Settings → Windows Update → Check for Updates\n" +
              "• Enable 'Receive updates for other Microsoft products' to update Office too\n\n" +
              "On Android:\n" +
              "• Go to Settings → Software Update → Download and Install\n\n" +
              "On iPhone:\n" +
              "• Go to Settings → General → Software Update\n\n" +
              "On Mac:\n" +
              "• Go to Apple Menu → System Preferences → Software Update\n\n" +

              "🌍 Real World Example:\n" +
              "In 2017 the Equifax credit bureau ignored a critical security patch for their web application software for 78 days. " +
              "Attackers exploited that known vulnerability during those 78 days. " +
              "The result was the largest financial data breach in history — 147 million people's sensitive financial records stolen. " +
              "The CEO resigned. The company paid $700 million in settlements. " +
              "All of it could have been prevented by installing one update.\n\n" +

              "🚨 Best Practices for Updates:\n" +
              "1. Enable automatic updates on your operating system, browser and antivirus\n" +
              "2. Update apps on your phone weekly\n" +
              "3. Replace software that is no longer supported — like Windows 7 or Internet Explorer\n" +
              "4. Update your router firmware regularly — most people never do this\n" +
              "5. Subscribe to security news sites like Krebs on Security to hear about critical patches quickly"
            },

            { "encryption",
              "🔑 ENCRYPTION\n\n" +

              "📖 What it is:\n" +
              "Encryption converts readable data into an unreadable scrambled format using a mathematical algorithm. " +
              "Only someone with the correct decryption key can convert it back to readable form. " +
              "It protects your data whether it is stored on a device or travelling across the internet.\n\n" +

              "💡 Simple Analogy:\n" +
              "Imagine writing a letter and locking it inside a box with a unique key before posting it. " +
              "Even if someone intercepts the box, they cannot read the letter without the key. " +
              "Encryption does exactly this to your data — it turns your readable message into a locked box that only the intended recipient can open.\n\n" +

              "🎯 Types of Encryption:\n" +
              "• Symmetric Encryption — uses one key for both encrypting and decrypting. Fast but the key must be shared securely. Example: AES.\n" +
              "• Asymmetric Encryption — uses a public key to encrypt and a private key to decrypt. More secure for communication. Example: RSA.\n" +
              "• End-to-End Encryption (E2EE) — data is encrypted on your device and only decrypted on the recipient's device. " +
              "Not even the service provider can read it. Used by WhatsApp, Signal and iMessage.\n" +
              "• TLS (Transport Layer Security) — encrypts data travelling between your browser and websites. This is what HTTPS uses.\n\n" +

              "🌐 End-to-End Encryption in Messaging:\n" +
              "• Signal — considered the gold standard for private messaging. Fully open source.\n" +
              "• WhatsApp — uses Signal's E2EE protocol for messages (though metadata is still collected)\n" +
              "• iMessage — encrypted between Apple devices\n" +
              "• Telegram — only encrypts in 'Secret Chat' mode. Regular chats are NOT end-to-end encrypted.\n\n" +

              "⚠ When Encryption is NOT Enough:\n" +
              "• If an attacker already has access to your unlocked device, encryption does not help\n" +
              "• If you use a weak password to protect an encrypted file, it can still be brute-forced\n" +
              "• If malware is installed before encryption happens, it can steal data before it is encrypted\n" +
              "• Encryption protects data in transit and at rest — but not when it is being actively used\n\n" +

              "🌍 Real World Example:\n" +
              "In 2016 the FBI demanded Apple create a backdoor to decrypt an encrypted iPhone belonging to a terrorist. " +
              "Apple refused, arguing that creating any backdoor would weaken encryption for all users worldwide. " +
              "The FBI eventually paid a third party over $1 million to crack the phone. " +
              "The case highlighted how strong encryption — when implemented properly — can resist even government-level attempts to break it.\n\n" +

              "🚨 Encryption Best Practices:\n" +
              "1. Enable full-disk encryption on your device — BitLocker on Windows, FileVault on Mac\n" +
              "2. Use Signal or WhatsApp for sensitive conversations\n" +
              "3. Use HTTPS websites — check for the padlock in your browser\n" +
              "4. Encrypt sensitive files before storing them in the cloud using tools like Veracrypt\n" +
              "5. Use a strong password to protect any encrypted files or drives"
            },

            { "firewalls",
              "🧱 FIREWALLS\n\n" +

              "📖 What it is:\n" +
              "A firewall is a security system that monitors and filters all incoming and outgoing network traffic based on predefined rules. " +
              "It acts as a gatekeeper between your trusted network and untrusted external networks like the internet.\n\n" +

              "💡 Simple Analogy:\n" +
              "A firewall is like a security guard at the entrance of a building. " +
              "Every person trying to enter or leave is checked against a list. " +
              "Approved visitors are let through. Unauthorised ones are turned away. " +
              "The guard also keeps a log of everyone who entered and left and when.\n\n" +

              "🎯 Types of Firewalls:\n" +
              "• Windows Built-in Firewall — basic protection included free with Windows 10 and 11, adequate for home users\n" +
              "• Third-Party Software Firewalls — ZoneAlarm, Comodo — offer more control and detailed logging\n" +
              "• Hardware Firewalls — physical devices like a router with firewall capabilities, protects all devices on the network\n" +
              "• Next-Generation Firewalls (NGFW) — enterprise-grade, includes deep packet inspection, intrusion prevention and application awareness\n" +
              "• Cloud Firewalls — protect cloud infrastructure and remote workers\n\n" +

              "🔍 How to Check if Your Windows Firewall is On:\n" +
              "1. Open the Start Menu and search for 'Windows Security'\n" +
              "2. Click on 'Firewall and Network Protection'\n" +
              "3. Ensure the firewall shows 'On' for Domain, Private and Public networks\n" +
              "4. If it shows 'Off' — click it and turn it on immediately\n\n" +

              "⚠ What a Firewall Cannot Protect You From:\n" +
              "• Malware that arrives through allowed traffic like email attachments or web downloads\n" +
              "• Insider threats — someone already inside the network with authorised access\n" +
              "• Sophisticated attackers who use allowed ports and protocols to disguise malicious traffic\n" +
              "• Social engineering attacks — firewalls cannot stop humans from being manipulated\n" +
              "• Encrypted malware traffic that bypasses inspection if not properly configured\n\n" +

              "🌍 Real World Example:\n" +
              "In 2003 the SQL Slammer worm spread across the entire internet in just 10 minutes — " +
              "infecting 75,000 computers and causing internet slowdowns worldwide. " +
              "It exploited a Microsoft SQL Server vulnerability and spread through UDP port 1434. " +
              "Organisations that had firewalls blocking that specific port were completely unaffected. " +
              "Those without firewalls or with misconfigured ones were infected within seconds.\n\n" +

              "🚨 Firewall Best Practices:\n" +
              "1. Always keep your Windows Firewall turned on — never disable it\n" +
              "2. Review firewall rules regularly and remove any that are no longer needed\n" +
              "3. Enable logging so you can see what traffic is being blocked\n" +
              "4. Use a hardware firewall on your home router as a first line of defence\n" +
              "5. Never create exceptions for applications you do not recognise\n" +
              "6. Use a firewall alongside antivirus — they protect against different threats"
            },

            { "backup & recovery",
              "💾 BACKUP AND RECOVERY\n\n" +

              "📖 What it is:\n" +
              "Backup and recovery means creating secure copies of your important data so that if the original is lost, corrupted or stolen, " +
              "you can restore it. It is your ultimate safety net against ransomware, hardware failure and human error.\n\n" +

              "💡 Simple Analogy:\n" +
              "Think of backups like insurance for your house. " +
              "You hope you never need it, but if disaster strikes — a fire, a flood, a break-in — " +
              "you are incredibly relieved it exists. Without it, everything you worked for is simply gone.\n\n" +

              "🎯 The 3-2-1 Backup Rule:\n" +
              "This is the gold standard recommended by cybersecurity professionals worldwide:\n" +
              "• 3 — Keep three copies of your data (original + two backups)\n" +
              "• 2 — Store them on two different types of media (e.g. external hard drive + cloud)\n" +
              "• 1 — Keep one copy completely offsite or offline (protects against fire, flood and ransomware)\n\n" +

              "🛠 Recommended Backup Tools and Services:\n" +
              "Cloud Backup:\n" +
              "• Google Drive — 15GB free, automatic photo backup on Android\n" +
              "• OneDrive — 5GB free, deeply integrated with Windows\n" +
              "• iCloud — 5GB free, automatic for iPhone users\n" +
              "• Backblaze — unlimited computer backup for $9/month, excellent for full system backup\n\n" +
              "Local Backup:\n" +
              "• External Hard Drive — plug in and use Windows Backup or Time Machine on Mac\n" +
              "• USB Drive — for small critical files\n" +
              "• NAS (Network Attached Storage) — for home or small business multi-device backup\n\n" +

              "⏰ How Often Should You Back Up:\n" +
              "• Daily — for work files, documents you edit regularly\n" +
              "• Weekly — for photos, videos and personal projects\n" +
              "• Monthly — for full system images\n" +
              "• The rule: how much data are you willing to lose? Back up as often as that.\n\n" +

              "🔍 How to Test That Your Backup Actually Works:\n" +
              "• Restore a random file from your backup every month to verify it is readable\n" +
              "• Perform a full test restore on a spare device or virtual machine every quarter\n" +
              "• A backup that has never been tested is not a backup — it is hope\n\n" +

              "🌍 Real World Example:\n" +
              "In 2021 the ransomware attack on the Irish Health Service Executive (HSE) shut down their entire healthcare IT system for weeks. " +
              "Patient records, appointment systems and hospital operations were completely offline. " +
              "Recovery took months and cost over €100 million. " +
              "Critically, their backup systems were also connected to the same network and were encrypted by the ransomware too, " +
              "leaving them with almost nothing to restore from. Offline backups would have changed everything.\n\n" +

              "🚨 What to do immediately if you lose your data:\n" +
              "1. Do not panic and do not overwrite the drive — deleted files can sometimes be recovered\n" +
              "2. Stop using the affected device to prevent data from being overwritten\n" +
              "3. Try recovery tools like Recuva (free) for accidentally deleted files\n" +
              "4. Restore from your most recent clean backup\n" +
              "5. If ransomware is involved, check nomoreransom.org for a free decryption tool first\n" +
              "6. Contact a professional data recovery service if the drive has physical damage"
            },

            { "incident response",
              "🚨 INCIDENT RESPONSE\n\n" +

              "📖 What it is:\n" +
              "Incident response is the structured process of detecting, containing, eliminating and recovering from a cybersecurity incident — " +
              "such as a hack, data breach, malware infection or ransomware attack. " +
              "Having a plan before an incident happens is what separates a minor setback from a catastrophic loss.\n\n" +

              "💡 Simple Analogy:\n" +
              "Think of incident response like a fire drill. " +
              "No one expects a fire, but every building has an evacuation plan, fire extinguishers and emergency exits. " +
              "When the alarm goes off, everyone knows exactly what to do and where to go — without panicking. " +
              "A cybersecurity incident plan works exactly the same way.\n\n" +

              "🎯 The 6 Phases of Incident Response:\n" +
              "1. Preparation — having a plan, training your team, having tools ready before anything happens\n" +
              "2. Identification — detecting that an incident is occurring and understanding its scope\n" +
              "3. Containment — isolating affected systems to stop the attack from spreading\n" +
              "4. Eradication — removing the threat completely from your environment\n" +
              "5. Recovery — restoring systems and data to normal operation safely\n" +
              "6. Lessons Learned — reviewing what happened, why it happened and how to prevent it next time\n\n" +

              "👤 Simplified Response for Individual Users — What to Do if You Get Hacked:\n" +
              "1. Disconnect the affected device from the internet and all networks immediately\n" +
              "2. Change passwords for all important accounts from a different, clean device\n" +
              "3. Enable 2FA on all accounts if not already done\n" +
              "4. Run a full antivirus and malware scan\n" +
              "5. Notify your bank if any financial accounts may be affected\n" +
              "6. Check email for any forwarding rules set up by the attacker\n\n" +

              "📞 Who to Contact:\n" +
              "• Your bank — call the number on the back of your card immediately if finances are at risk\n" +
              "• South African Police Service — open a case for cybercrime at your nearest station\n" +
              "• SAPS Cybercrime Hub — cybercrimehub@saps.gov.za\n" +
              "• Your employer's IT security team — if work systems or data are involved\n" +
              "• CERT-SA — South Africa's Computer Emergency Response Team\n\n" +

              "🔍 How to Preserve Evidence Without Making Things Worse:\n" +
              "• Take screenshots of everything suspicious before making any changes\n" +
              "• Do not delete suspicious emails or files — they are evidence\n" +
              "• Write down exactly what you noticed, when, and what you did in response\n" +
              "• Do not try to hack back — this is illegal and can destroy evidence\n\n" +

              "🌍 Real World Example:\n" +
              "In 2013 Target Corporation detected suspicious activity in their network on 12 December. " +
              "However due to poor incident response procedures, the security team did not act on the alerts for several days. " +
              "By the time they responded, 40 million credit and debit card numbers and 70 million personal records had already been stolen. " +
              "The breach cost Target over $300 million. Had they responded to the initial alerts immediately, " +
              "the breach could have been contained within hours.\n\n" +

              "🚨 Incident Response Checklist:\n" +
              "1. Disconnect affected devices immediately\n" +
              "2. Document everything — time, symptoms, actions taken\n" +
              "3. Change all compromised credentials\n" +
              "4. Notify relevant parties — bank, employer, police if needed\n" +
              "5. Scan and clean all affected devices\n" +
              "6. Restore from clean backups\n" +
              "7. Conduct a review and update your security practices"
            },

            { "privacy settings",
              "🔐 PRIVACY SETTINGS\n\n" +

              "📖 What it is:\n" +
              "Privacy settings are controls built into apps, devices and websites that let you decide how your personal data is collected, " +
              "stored, shared and used. Most default settings are configured to share as much data as possible — " +
              "changing them is one of the most impactful things you can do for your privacy.\n\n" +

              "💡 Simple Analogy:\n" +
              "Imagine moving into a new house where all the windows and curtains are permanently open by default. " +
              "Anyone walking by can see everything inside. Privacy settings are like being able to choose which curtains to close, " +
              "which windows to lock and who gets a key. The house is yours — you should decide who sees inside.\n\n" +

              "🎯 Platform-Specific Privacy Settings to Change Right Now:\n\n" +
              "Facebook:\n" +
              "• Settings → Privacy → Who can see your future posts → set to 'Friends' not 'Public'\n" +
              "• Settings → Privacy → Do you want search engines to link to your profile → turn OFF\n" +
              "• Settings → Ad Preferences → turn off all personalised advertising\n\n" +

              "Instagram:\n" +
              "• Settings → Privacy → Account Privacy → switch to Private Account\n" +
              "• Settings → Privacy → Activity Status → turn OFF\n\n" +

              "Google Account:\n" +
              "• myaccount.google.com → Data and Privacy → turn off Web and App Activity\n" +
              "• Turn off Location History\n" +
              "• Turn off YouTube Watch History if desired\n\n" +

              "iPhone:\n" +
              "• Settings → Privacy → Location Services → set each app to 'While Using' or 'Never'\n" +
              "• Settings → Privacy → Tracking → turn OFF 'Allow Apps to Request to Track'\n\n" +

              "Android:\n" +
              "• Settings → Privacy → Permission Manager → review each permission category\n" +
              "• Settings → Google → Manage Your Google Account → Data and Privacy\n\n" +

              "Browser Privacy:\n" +
              "• Use Firefox or Brave browser — both have strong privacy protection by default\n" +
              "• Enable 'Do Not Track' in your browser settings\n" +
              "• Clear cookies and browsing data regularly\n" +
              "• Use a private/incognito window for sensitive searches\n\n" +

              "⚠ What Data Companies Collect and Why It Matters:\n" +
              "Companies collect your location, search history, purchase behaviour, contacts, call logs and app usage. " +
              "This data is used to build a detailed profile of you for targeted advertising. " +
              "When a company is breached, all that collected data can end up in criminal hands. " +
              "The less data collected about you, the less there is to steal.\n\n" +

              "🌍 Real World Example:\n" +
              "In 2018 it was revealed that Cambridge Analytica harvested the personal data of 87 million Facebook users " +
              "without their explicit consent through a seemingly harmless personality quiz app. " +
              "That data was used to build psychological profiles and target political advertising. " +
              "None of the affected users had changed their privacy settings — they were all using Facebook's permissive defaults.\n\n" +

              "🚨 Privacy Settings Checklist:\n" +
              "1. Review app permissions on your phone monthly — revoke what is unnecessary\n" +
              "2. Set all social media profiles to private\n" +
              "3. Disable location tracking for apps that do not need it\n" +
              "4. Opt out of personalised advertising on all platforms\n" +
              "5. Use a privacy-focused browser and search engine like DuckDuckGo\n" +
              "6. Read privacy policies before installing new apps — especially free ones"
            },

            { "iot security",
              "📡 IOT SECURITY — INTERNET OF THINGS\n\n" +

              "📖 What it is:\n" +
              "IoT security covers protecting internet-connected devices beyond computers and phones — " +
              "including smart TVs, security cameras, smart speakers, baby monitors, thermostats, smart locks and even appliances like fridges. " +
              "These devices often have very weak built-in security, making them easy targets.\n\n" +

              "💡 Simple Analogy:\n" +
              "Every IoT device you add to your home network is like adding another door to your house. " +
              "A smart TV with default credentials is like a door with no lock at all. " +
              "An attacker only needs to find one unlocked door to get inside your entire network.\n\n" +

              "🎯 Real IoT Devices That Have Been Hacked:\n" +
              "• Baby Monitors — security researchers demonstrated live video feeds from thousands of baby monitors worldwide being accessible to anyone online due to default passwords never being changed\n" +
              "• Smart TVs — Samsung smart TVs were found to have a backdoor that allowed microphone access without the owner's knowledge\n" +
              "• Security Cameras — in 2021, hackers breached Verkada and gained live access to 150,000 cameras inside hospitals, prisons, schools and Tesla factories\n" +
              "• Smart Fridges — demonstrated to leak Gmail credentials in early IoT research\n" +
              "• Home Routers — the Mirai botnet infected 600,000 routers with default passwords and used them to launch the largest DDoS attack in history\n\n" +

              "⚠ How to Check if Your Smart Device Has Been Compromised:\n" +
              "• Check your router admin panel for unknown connected devices\n" +
              "• Use the Fing app on your phone to scan all devices on your network\n" +
              "• Watch for unusual behaviour — camera lights turning on unexpectedly, devices restarting, unusual data usage\n" +
              "• Check the manufacturer's website for known security incidents involving your device model\n\n" +

              "🛡 Specific Router Security Settings to Change:\n" +
              "1. Change the default admin username and password on your router immediately\n" +
              "2. Update your router firmware — log into your router admin panel and check for updates\n" +
              "3. Disable Remote Management unless you specifically need it\n" +
              "4. Enable WPA3 encryption on your Wi-Fi if your router supports it\n" +
              "5. Create a separate Guest Wi-Fi network specifically for all IoT devices\n" +
              "6. Disable UPnP (Universal Plug and Play) — it allows devices to open ports automatically, which attackers exploit\n\n" +

              "🌍 Real World Example:\n" +
              "In 2016 the Mirai botnet malware scanned the entire internet for IoT devices using default factory passwords. " +
              "It found and infected over 600,000 devices — cameras, routers, DVRs — all with default credentials that were never changed. " +
              "These devices were then used together to launch a DDoS attack against Dyn, a major DNS provider. " +
              "The attack took down Twitter, Netflix, Reddit, Spotify and dozens of major websites across the USA and Europe for a full day. " +
              "The weapon: IoT devices with passwords that were never changed from the factory default.\n\n" +

              "🚨 IoT Security Checklist:\n" +
              "1. Change default username and password on every IoT device immediately after setup\n" +
              "2. Put all IoT devices on a separate guest Wi-Fi network\n" +
              "3. Update the firmware of every device regularly\n" +
              "4. Disable features you do not use — remote access, voice control, UPnP\n" +
              "5. Replace devices that no longer receive security updates from the manufacturer\n" +
              "6. Scan your network regularly using the Fing app to spot unknown devices"
            },

            { "mobile security",
              "📱 MOBILE SECURITY\n\n" +

              "📖 What it is:\n" +
              "Mobile security involves protecting your smartphone or tablet from threats including malware, data theft, unauthorised access, " +
              "and physical theft. Since your phone contains your emails, banking apps, photos, contacts and messages, " +
              "it is one of the most valuable targets for cybercriminals.\n\n" +

              "💡 Simple Analogy:\n" +
              "Your smartphone is essentially a powerful computer that also happens to know where you are at all times, " +
              "has access to your bank account and contains years of personal conversations. " +
              "Leaving it unprotected is like carrying your entire life in an unlocked bag in a crowded shopping centre.\n\n" +

              "🎯 Android vs iPhone Security Differences:\n" +
              "Android:\n" +
              "• More open ecosystem — more flexibility but higher risk from third-party apps\n" +
              "• More targeted by malware due to larger market share\n" +
              "• Security updates vary widely between manufacturers — Samsung, Huawei and others update at different rates\n" +
              "• Install apps only from the Google Play Store\n\n" +
              "iPhone (iOS):\n" +
              "• More locked-down ecosystem — fewer customisation options but stronger default security\n" +
              "• All apps reviewed by Apple before appearing in the App Store\n" +
              "• Consistent security updates directly from Apple for all supported devices\n" +
              "• iMessage and FaceTime are end-to-end encrypted by default\n\n" +

              "⚠ Signs your phone may be compromised:\n" +
              "• Battery draining much faster than usual without explanation\n" +
              "• Phone heating up even when not in use\n" +
              "• Unexplained data usage spikes\n" +
              "• Apps crashing more frequently than normal\n" +
              "• Strange text messages being sent from your number that you did not send\n" +
              "• New apps appearing that you did not install\n\n" +

              "🔍 What to do if your phone is lost or stolen:\n" +
              "Android:\n" +
              "• Go to android.com/find on any browser while signed into your Google account\n" +
              "• You can locate, lock or remotely erase your device\n\n" +
              "iPhone:\n" +
              "• Go to icloud.com/find or use the Find My app\n" +
              "• You can locate, play a sound, lock or remotely erase your device\n" +
              "• Enable Lost Mode which locks the device and displays a custom message\n\n" +

              "🌍 Real World Example:\n" +
              "In 2021 the NSO Group's Pegasus spyware was found to have infected the phones of journalists, activists and world leaders globally. " +
              "The spyware could activate the camera and microphone, read encrypted messages and track location — all without the owner's knowledge. " +
              "It exploited zero-day vulnerabilities in both Android and iOS. " +
              "Even heads of state including French President Emmanuel Macron had their phones compromised. " +
              "The attack demonstrated that no phone is completely immune — but most users face far less sophisticated threats that good habits prevent.\n\n" +

              "🚨 Mobile Security Checklist:\n" +
              "1. Set a strong PIN, password or biometric lock — never use a simple pattern\n" +
              "2. Enable full device encryption — on by default on modern iPhones and many Android devices\n" +
              "3. Only install apps from official app stores\n" +
              "4. Review app permissions immediately after installing any new app\n" +
              "5. Enable Find My Device and remote wipe capability\n" +
              "6. Keep your operating system and apps updated\n" +
              "7. Back up your phone weekly to cloud or computer"
            },

            { "secure coding",
              "💻 SECURE CODING\n\n" +

              "📖 What it is:\n" +
              "Secure coding is the practice of writing software with security built in from the start — not added as an afterthought. " +
              "It means anticipating how an attacker might try to misuse your code and writing it in a way that prevents those attacks.\n\n" +

              "💡 Simple Analogy — For Non-Developers:\n" +
              "Think of building a house. You would not build a house with no locks on the doors, " +
              "gaps in the walls and open access to the electrical panel, then add security features only after someone breaks in. " +
              "You design security in from the beginning — locks, alarms, reinforced windows. " +
              "Secure coding does the same thing for software.\n\n" +

              "🎯 OWASP Top 10 — The Most Critical Web Security Risks:\n" +
              "The Open Web Application Security Project (OWASP) publishes the definitive list of the most dangerous coding vulnerabilities:\n" +
              "1. Broken Access Control — users accessing data or functions they should not be able to\n" +
              "2. Cryptographic Failures — storing or transmitting sensitive data without encryption\n" +
              "3. Injection — SQL injection, command injection, allowing malicious input to manipulate the system\n" +
              "4. Insecure Design — fundamental design flaws that no amount of patching can fully fix\n" +
              "5. Security Misconfiguration — default settings, open cloud storage, verbose error messages\n" +
              "6. Vulnerable Components — using libraries or frameworks with known security flaws\n" +
              "7. Authentication Failures — weak login systems, session management issues\n" +
              "8. Data Integrity Failures — trusting data without verifying it\n" +
              "9. Security Logging Failures — not detecting or recording attacks\n" +
              "10. Server-Side Request Forgery — tricking the server into making unintended requests\n\n" +

              "🛠 Security Testing Tools:\n" +
              "SAST (Static Analysis — scans code without running it):\n" +
              "• SonarQube — widely used, integrates with most CI/CD pipelines\n" +
              "• Checkmarx — enterprise-grade code scanning\n" +
              "• Semgrep — fast, lightweight, open source\n\n" +
              "DAST (Dynamic Analysis — tests running applications):\n" +
              "• OWASP ZAP — free, excellent for web application testing\n" +
              "• Burp Suite — industry standard for web security testing\n" +
              "• Nikto — open source web server scanner\n\n" +

              "🌍 Real World Example:\n" +
              "In 2017 the Equifax breach was caused by a SQL injection vulnerability in an open-source web framework called Apache Struts. " +
              "A security patch had been available for two months but was never applied. " +
              "Attackers exploited the unpatched code to query Equifax's database directly, " +
              "extracting 147 million people's names, addresses, ID numbers and financial records. " +
              "Basic input validation and timely dependency updates would have prevented it entirely.\n\n" +

              "🚨 Secure Coding Checklist:\n" +
              "1. Always validate and sanitise user input — never trust data from outside your application\n" +
              "2. Use parameterised queries to prevent SQL injection\n" +
              "3. Apply the principle of least privilege — give code only the access it needs\n" +
              "4. Keep all libraries and dependencies updated and scan them for vulnerabilities\n" +
              "5. Store passwords using strong hashing algorithms like bcrypt or Argon2 — never plain text\n" +
              "6. Implement proper error handling — never expose stack traces or system details to users\n" +
              "7. Conduct regular code reviews with security as a focus\n" +
              "8. Reference owasp.org for up-to-date guidance on secure development"
            },

            { "network segmentation",
              "🕸 NETWORK SEGMENTATION\n\n" +

              "📖 What it is:\n" +
              "Network segmentation is the practice of dividing a computer network into smaller, isolated sections called segments. " +
              "Each segment only communicates with others when absolutely necessary, " +
              "limiting how far an attacker can move through the network if they breach one segment.\n\n" +

              "💡 Simple Analogy:\n" +
              "Imagine a hospital designed as one giant open room where patients, staff, medicine storage, records and visitors all share the same space. " +
              "If one person brought in a contagious disease, it would spread to everyone instantly. " +
              "Instead, hospitals have separate wards, locked medicine rooms and restricted access areas — each zone isolated from the others. " +
              "Network segmentation does exactly this for your digital infrastructure.\n\n" +

              "🎯 Technologies Used for Segmentation:\n" +
              "• VLANs (Virtual Local Area Networks) — logical separation of network traffic even on the same physical hardware\n" +
              "• Firewalls — control traffic between segments based on rules\n" +
              "• Access Control Lists (ACLs) — define which devices or users can communicate with which others\n" +
              "• Subnets — dividing an IP network into smaller address ranges\n" +
              "• Zero Trust Architecture — verifies every user and device before granting access, regardless of network location\n\n" +

              "🏠 Home Network Segmentation — Simple and Practical:\n" +
              "Even home users can benefit from segmentation:\n" +
              "• Create a separate Guest Wi-Fi network for visitors so they cannot access your main devices\n" +
              "• Connect all IoT devices (smart TV, cameras, thermostats) to the Guest network, not your main network\n" +
              "• Keep work laptops on a separate network from personal devices where possible\n" +
              "• Most modern routers support multiple SSIDs (Wi-Fi network names) — use this feature\n\n" +

              "🏢 How Small Businesses Can Implement This Simply:\n" +
              "• Separate the customer Wi-Fi from the internal office network\n" +
              "• Put point-of-sale systems on their own isolated VLAN\n" +
              "• Keep accounting and HR systems on a more restricted segment\n" +
              "• Use a firewall to control what can talk to what between segments\n" +
              "• Most small business routers and managed switches support basic VLAN configuration\n\n" +

              "🌍 Real World Example:\n" +
              "In 2013 the Target data breach began through a compromised HVAC (heating and air conditioning) contractor that had network access. " +
              "Because Target's network was not properly segmented, attackers were able to move from the contractor's limited access " +
              "all the way to the point-of-sale systems that processed customer credit card payments. " +
              "40 million credit card numbers were stolen. Had the HVAC network been properly isolated from the payment systems, " +
              "the breach would have been contained to a single segment with no access to customer payment data.\n\n" +

              "🚨 Network Segmentation Checklist:\n" +
              "1. Set up a separate Guest Wi-Fi for visitors and IoT devices at home\n" +
              "2. Never connect unknown or untrusted devices to your main network\n" +
              "3. Use your router's built-in VLAN features if available\n" +
              "4. Regularly review which devices are on which network segment\n" +
              "5. Apply firewall rules between segments — block by default, allow only what is needed\n" +
              "6. Monitor traffic between segments for unusual communication patterns"
            },

            { "access control",
              "🔒 ACCESS CONTROL\n\n" +

              "📖 What it is:\n" +
              "Access control is the security practice of ensuring that people, systems and applications can only access " +
              "the resources they are specifically authorised to use — nothing more. " +
              "It is the digital equivalent of deciding who gets a key, who gets a visitor badge and who is not allowed in at all.\n\n" +

              "💡 Simple Analogy:\n" +
              "In a large office building, different people have different levels of access. " +
              "A cleaner has a key to every office but cannot access the server room. " +
              "A junior accountant can view financial reports but cannot approve payments. " +
              "The CEO can access everything. Each person has exactly the access they need to do their job — and nothing more. " +
              "That is access control.\n\n" +

              "🎯 Authentication vs Authorisation — The Key Difference:\n" +
              "• Authentication — proving who you are (username, password, fingerprint, 2FA)\n" +
              "• Authorisation — determining what you are allowed to do once your identity is confirmed\n" +
              "• Example: Authentication is the security guard checking your ID at the door. " +
              "Authorisation is the list of rooms you are permitted to enter once inside.\n\n" +

              "🎯 Access Control Models:\n" +
              "• Role-Based Access Control (RBAC) — permissions are assigned based on job role. A salesperson gets CRM access; an engineer gets code repository access.\n" +
              "• Attribute-Based Access Control (ABAC) — access based on attributes like department, location, time of day\n" +
              "• Mandatory Access Control (MAC) — used in high-security environments; the system itself enforces access levels\n" +
              "• Discretionary Access Control (DAC) — the resource owner decides who has access (common in file sharing)\n\n" +

              "⚠ What Happens When Access Control Fails — Real Consequences:\n" +
              "• An employee with excessive permissions accidentally deletes critical database records\n" +
              "• A contractor whose access was never revoked after leaving logs in months later and steals data\n" +
              "• A compromised account with admin privileges gives an attacker complete system control\n" +
              "• An intern accidentally sees confidential salary information because folder permissions were not configured\n\n" +

              "🔍 How to Audit Access in a Small Team:\n" +
              "1. List every user account in your systems — include service accounts\n" +
              "2. For each account, document what it has access to\n" +
              "3. Ask 'Does this person still work here? Do they still need this access?'\n" +
              "4. Remove accounts for people who have left — immediately on their last day\n" +
              "5. Reduce permissions for anyone who has more access than their job requires\n" +
              "6. Repeat this audit every three months\n\n" +

              "🌍 Real World Example:\n" +
              "In 2020 a Twitter insider threat allowed hackers to access internal admin tools. " +
              "The attackers used social engineering to convince Twitter employees with high access privileges to hand over credentials. " +
              "Because those employees had access to virtually any account on the platform — far more than their jobs required — " +
              "the attackers were able to hijack Barack Obama, Elon Musk, Apple and dozens more. " +
              "Proper least-privilege access control would have limited what those credentials could access.\n\n" +

              "🚨 Access Control Best Practices:\n" +
              "1. Apply the Principle of Least Privilege — give only the minimum access needed\n" +
              "2. Remove access immediately when an employee leaves\n" +
              "3. Use multi-factor authentication for all privileged accounts\n" +
              "4. Conduct access reviews every quarter\n" +
              "5. Log and monitor all access to sensitive systems\n" +
              "6. Use separate accounts for admin tasks — never use an admin account for daily browsing or email\n" +
              "7. Implement time-based access — some access should only be available during business hours"
            },

            { "security policies",
              "📜 SECURITY POLICIES\n\n" +

              "📖 What it is:\n" +
              "Security policies are formal documented rules that define how an organisation or individual manages cybersecurity. " +
              "They set the expectations, responsibilities and procedures that everyone must follow to keep systems and data safe.\n\n" +

              "💡 Simple Analogy:\n" +
              "Think of security policies like the rules of the road. " +
              "The rules exist not to inconvenience drivers but to keep everyone safe. " +
              "Without them, every driver would make their own decisions and chaos would follow. " +
              "Security policies do the same thing — they create consistent, predictable safe behaviour across an entire organisation or household.\n\n" +

              "🎯 What a Basic Security Policy Should Cover:\n" +
              "• Password Policy — minimum length, complexity requirements, how often to change them\n" +
              "• Acceptable Use Policy — what devices and systems may be used for, personal use rules\n" +
              "• Data Protection Policy — how sensitive data is classified, stored and shared\n" +
              "• Incident Response Policy — what to do and who to call when something goes wrong\n" +
              "• Remote Work Policy — VPN requirements, approved devices, home network security\n" +
              "• BYOD Policy (Bring Your Own Device) — rules for using personal devices for work\n" +
              "• Software Update Policy — how quickly patches must be applied after release\n\n" +

              "🏠 A Simple Personal Security Policy for Individuals:\n" +
              "You do not need to work for a company to benefit from a personal security policy. Here is a simple one:\n" +
              "• I will use a unique strong password for every account and store them in a password manager\n" +
              "• I will enable 2FA on all accounts that support it\n" +
              "• I will back up my important files every Sunday\n" +
              "• I will install updates within 48 hours of them being released\n" +
              "• I will not click links in unexpected emails without verifying the sender first\n" +
              "• I will review my privacy settings on social media every three months\n\n" +

              "🏢 How to Enforce Policies in a Small Business or Family:\n" +
              "• Make policies simple and specific — vague policies are ignored\n" +
              "• Hold a brief monthly security meeting to review what everyone is doing\n" +
              "• Use technical controls to enforce policies where possible — e.g. require strong passwords at the system level\n" +
              "• Lead by example — if the manager ignores the policy, everyone else will too\n" +
              "• Reward good security behaviour rather than only punishing violations\n" +
              "• For families: make cybersecurity a normal dinner table conversation, not a lecture\n\n" +

              "🌍 Real World Example:\n" +
              "In 2014 Sony Pictures was devastated by a cyberattack attributed to North Korea. " +
              "Investigators found that Sony had no consistent password policy, used easily guessable passwords stored in unencrypted files, " +
              "had no formal incident response policy and lacked basic network segmentation. " +
              "Entire unreleased movies, employee salary data, personal emails and confidential business plans were published online. " +
              "The attack caused hundreds of millions in damage. Post-incident analysis found that basic security policies — " +
              "consistently enforced — would have significantly limited the damage.\n\n" +

              "🚨 Security Policy Checklist:\n" +
              "1. Write down your security rules — even a one-page personal policy is better than nothing\n" +
              "2. Review and update policies every six months or after any security incident\n" +
              "3. Ensure everyone in your household or team knows and understands the policies\n" +
              "4. Use technical controls to enforce policies automatically where possible\n" +
              "5. Test your policies with simulated phishing emails or tabletop exercises\n" +
              "6. Make sure new employees or family members are briefed on policies from day one"
            }
        };
    }
}

