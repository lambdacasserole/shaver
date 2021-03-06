# Shaver
Pretty, minimalist Shavian on-screen keyboard for Windows.

![Screenshot](screenshot.png)

## Purpose
The Shavian alphabet (or Shaw alphabet) is an alphabet designed to mirror English phonology as closely as possible. This makes it quite convenient as a way to write without any ambiguity in pronunciation, even going so far as to portray the author's accent as part of the written text. Shaver allows you to type using this alphabet.

If you're interested in learning more [you can find the Wikipedia article here](https://en.wikipedia.org/wiki/Shavian_alphabet).

## Motivation
Currently, though Shavian [is supported in Unicode](https://en.wikipedia.org/wiki/Shavian_alphabet#Unicode) as of version 4.0 (April 2003) font support has been very lacking. This keyboard uses [Adagii](http://www.i18nguy.com/unicode/unicode-font.html) as a font but [there are others available](https://en.wikipedia.org/wiki/Shavian_alphabet#Fonts).

I had a personal need to type Shavian, but rather than type it directly using a hacky keyboard add-on I chose to write Shaver so I could type in a seperate window and copy/paste across to an input field/text box. The words representing the letter sounds on each key are especially useful in helping beginners learn to read and write Shavian. It is not:

* A _true_ on-screen keyboard that will allow you to type directly into a text field.
* A Ŝava alfabeto keyboard (for typing Esperanto using Shavian).
* A word processing application. It supports Shavian letters and space characters, that's it.

## Building
You'll need Visual Studio 2015 installed to build the executable. Just build it like any other C# WinForms solution.

## Usage
Shaver doesn't support typing directly into a text field. This is a conscious decision taken due to the current dire lack of rendering support for the Shavian character set. You can type in the Shaver window using the mouse or keyboard. The shift key will work to switch over the active character set, as will clicking on the on-screen shift key.

## Contributing
If you'd like to contribute, feel free to fork and submit a PR or raise an issue. All feedback is welcome from developers, Shavian users and linguists alike.
