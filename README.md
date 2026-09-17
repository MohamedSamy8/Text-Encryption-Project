# 🔐 Project — Text Encryption Form

> A Caesar Cipher desktop app in C# — encrypt and decrypt any text with a bounded security key, copy results to clipboard, and log every operation with timestamps.

---

<img width="700" height="550" alt="image" src="<img width="1040" height="788" alt="image" src="https://github.com/user-attachments/assets/5b0bf020-4190-43b4-8b00-6de11e6d0b69" />
" />

---

## 🚀 Project Overview

Same controls as Project 25.

Different application entirely.

That is the whole point.

The goal of this self-directed practice series is not to use a control once and move on.

It is to build enough experience with each control that using it becomes automatic.

This project takes the same set — Form, Label, TextBox, Button — and applies them to something completely different:

A **text encryption and decryption tool** based on the Caesar Cipher.

You enter any text.

You choose a security key between 1 and 5.

You encrypt.

If you want it back, you decrypt.

The output changes dynamically.

Every operation can be saved to a timestamped history log.

Simple idea.

Real implementation decisions behind it.

---

## 🔑 How the Encryption Works

This project uses a character-shift algorithm:

**Encrypt:**
Each character's ASCII value is shifted UP by the security key.

**Decrypt:**
Each character's ASCII value is shifted DOWN by the security key.

```csharp
// Encrypt
EncryptedText += Convert.ToChar(txtInput.Text[i] + SecurityKey);

// Decrypt
DecryptedText += Convert.ToChar(txtInput.Text[i] - SecurityKey);
```

If the key is `3`, the letter `A` (65) becomes `D` (68).

Same key. Reverse operation. Original text back.

This is the foundational concept behind modern encryption — shift ciphers.

---

## 🏗️ Architecture Design

```
btnEncrypt_Click
 └── IsInputTextboxEmpty()     ← guard: block if input is empty
      ├── Encrypt()
      │    ├── lblOutputStatus.Text = "Encrypted Output"
      │    └── txtOutput.Text = EncryptText()
      └── GetLength()          ← updates length label

btnDecrypt_Click
 └── IsInputTextboxEmpty()     ← same guard
      ├── Decrypt()
      │    ├── lblOutputStatus.Text = "Decrypted Output"
      │    └── txtOutput.Text = DecryptText()
      └── GetLength()

btnClear_Click
 └── Clear()
      ├── ResetTextboxes()     ← UI: clears input + output
      └── ResetLabels()        ← UI: resets status label + length label

btnSaveProcess_Click
 └── IsTextboxesEmpty()        ← guard: both must have content
      └── Appends timestamped row to txtHistoryLog

btnIncrementSecurityKey_Click
 └── IsMaxSecurityKey()        ← guard: block if already at 5
      └── IncrementSecurityKey()

btnDecrementSecurityKey_Click
 └── IsMinSecurityKey()        ← guard: block if already at 1
      └── DecrementSecurityKey()

btnCopyResult_Click
 └── IsOutputTextboxEmpty()    ← guard: block if nothing to copy
      ├── txtOutput.SelectAll()
      └── txtOutput.Copy()
```

---

## 🧠 Design Decisions Worth Noting

### Three-Layer Clear

Clear is split into three levels:

```csharp
private void Clear()
{
    ResetTextboxes();   // clears input + output TextBoxes
    ResetLabels();      // resets status label + length label
}
```

The button calls `Clear()`.

`Clear()` calls two separate reset functions.

Each function has one job.

This is the same Divide & Conquer principle from Stage One — just inside a WinForms event handler.

---

### Security Key Bounds

The key ranges from 1 to 5, enforced by two guard functions:

```csharp
private bool IsMaxSecurityKey() => (SecurityKey == MaxSecurityKey);
private bool IsMinSecurityKey() => (SecurityKey == MinSecurityKey);
```

The increment button only fires if NOT at max.

The decrement button only fires if NOT at min.

Changing the range later means changing two constants — nothing else.

---

### Dynamic Output Label

`lblOutputStatus` is not static.

It changes text based on the last operation performed:

- After Encrypt → `"Encrypted\nOutput"`
- After Decrypt → `"Decrypted\nOutput"`
- After Clear → `"Output"`

This tells the user what they are looking at without any extra UI elements.

---

### Timestamped History

Every saved operation includes a full timestamp:

```csharp
txtHistoryLog.Text += "[ " + DateTime.Now.ToString() + " ] - ";
```

The log entry captures:
- When the operation happened
- The input text
- The output text and its type (encrypted or decrypted)
- The length of the input text

---

## ⚙️ Core Functionalities

| Action | Description |
|---|---|
| **Encrypt** | Shifts all characters UP by the security key |
| **Decrypt** | Shifts all characters DOWN by the security key |
| **Security Key +/-** | Bounded between 1 and 5, guarded by min/max checks |
| **Copy Result** | Selects all output text and copies to clipboard |
| **Clear** | Resets all TextBoxes and dynamic labels |
| **Save Process** | Logs timestamped operation to history |
| **Delete All** | Clears the full history log |

---

## 🎯 What This Project Teaches

- Caesar Cipher logic applied in a real desktop app
- Bounded numeric control with guard functions (no spinners needed)
- Dynamic label updates based on state
- Clipboard integration (`SelectAll` + `Copy`)
- Timestamp logging with `DateTime.Now`
- Three-level function decomposition inside event handlers
- Same controls as the previous project — different scenario entirely

---

## 🛠️ Tech Stack

| | |
|---|---|
| **Language** | C# |
| **Framework** | .NET Framework |
| **UI** | Windows Forms (WinForms) |
| **IDE** | Visual Studio |
| **Type** | Desktop Application |
| **Controls Used** | Form, Label, TextBox, Button |

---

