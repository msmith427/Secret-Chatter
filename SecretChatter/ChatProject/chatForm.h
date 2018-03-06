#pragma once
#include <WinSock2.h>
#define PORT 8080


namespace ChatProject {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
	using namespace System::Net::Sockets;

	/// <summary>
	/// Summary for chatForm
	/// </summary>
	public ref class chatForm : public System::Windows::Forms::Form
	{
	public:
		chatForm(void)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~chatForm()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::TextBox^  messageLog;
	private: System::Windows::Forms::TextBox^  inputText;
	private: System::Windows::Forms::Button^  sendButton;
	private: System::Windows::Forms::Label^  label1;
	private: System::Windows::Forms::Label^  label2;
	private: System::Windows::Forms::TextBox^  textUsername;
	private: System::Windows::Forms::TextBox^  textPassword;
	private: System::Windows::Forms::Button^  connectButton;
	private: String^ username;

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->messageLog = (gcnew System::Windows::Forms::TextBox());
			this->inputText = (gcnew System::Windows::Forms::TextBox());
			this->sendButton = (gcnew System::Windows::Forms::Button());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->textUsername = (gcnew System::Windows::Forms::TextBox());
			this->textPassword = (gcnew System::Windows::Forms::TextBox());
			this->connectButton = (gcnew System::Windows::Forms::Button());
			this->SuspendLayout();
			// 
			// messageLog
			// 
			this->messageLog->Location = System::Drawing::Point(12, 12);
			this->messageLog->Multiline = true;
			this->messageLog->Name = L"messageLog";
			this->messageLog->Size = System::Drawing::Size(417, 381);
			this->messageLog->TabIndex = 0;
			// 
			// inputText
			// 
			this->inputText->Location = System::Drawing::Point(12, 399);
			this->inputText->Name = L"inputText";
			this->inputText->Size = System::Drawing::Size(517, 22);
			this->inputText->TabIndex = 1;
			this->inputText->KeyUp += gcnew System::Windows::Forms::KeyEventHandler(this, &chatForm::inputText_KeyUp);
			// 
			// sendButton
			// 
			this->sendButton->Location = System::Drawing::Point(535, 399);
			this->sendButton->Name = L"sendButton";
			this->sendButton->Size = System::Drawing::Size(75, 23);
			this->sendButton->TabIndex = 2;
			this->sendButton->Text = L"Send";
			this->sendButton->UseVisualStyleBackColor = true;
			this->sendButton->Click += gcnew System::EventHandler(this, &chatForm::sendButton_Click);
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Location = System::Drawing::Point(436, 12);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(71, 17);
			this->label1->TabIndex = 3;
			this->label1->Text = L"username";
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Location = System::Drawing::Point(439, 58);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(68, 17);
			this->label2->TabIndex = 4;
			this->label2->Text = L"password";
			// 
			// textUsername
			// 
			this->textUsername->Location = System::Drawing::Point(436, 33);
			this->textUsername->Name = L"textUsername";
			this->textUsername->Size = System::Drawing::Size(174, 22);
			this->textUsername->TabIndex = 5;
			// 
			// textPassword
			// 
			this->textPassword->Location = System::Drawing::Point(436, 78);
			this->textPassword->Name = L"textPassword";
			this->textPassword->Size = System::Drawing::Size(174, 22);
			this->textPassword->TabIndex = 6;
			this->textPassword->UseSystemPasswordChar = true;
			// 
			// connectButton
			// 
			this->connectButton->Location = System::Drawing::Point(535, 106);
			this->connectButton->Name = L"connectButton";
			this->connectButton->Size = System::Drawing::Size(75, 23);
			this->connectButton->TabIndex = 7;
			this->connectButton->Text = L"Connect!";
			this->connectButton->UseVisualStyleBackColor = true;
			this->connectButton->Click += gcnew System::EventHandler(this, &chatForm::Connect_click);
			// 
			// chatForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(8, 16);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(622, 433);
			this->Controls->Add(this->connectButton);
			this->Controls->Add(this->textPassword);
			this->Controls->Add(this->textUsername);
			this->Controls->Add(this->label2);
			this->Controls->Add(this->label1);
			this->Controls->Add(this->sendButton);
			this->Controls->Add(this->inputText);
			this->Controls->Add(this->messageLog);
			this->Name = L"chatForm";
			this->Text = L"chatForm";
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	private: System::Void Connect_click(System::Object^  sender, System::EventArgs^  e) {
		username = this->textUsername->Text;
	}
	private: System::Void sendButton_Click(System::Object^  sender, System::EventArgs^  e) {
		messageLog->Text += username + ": " + inputText->Text + "\r\n";
		inputText->Text = "";
	}
	private: System::Void inputText_KeyUp(System::Object^  sender, System::Windows::Forms::KeyEventArgs^  e) {
		if (e->KeyCode == Keys::Enter) {
			messageLog->Text += username + ": " + inputText->Text + "\r\n";
			inputText->Text = "";
		}
	}
};
}
