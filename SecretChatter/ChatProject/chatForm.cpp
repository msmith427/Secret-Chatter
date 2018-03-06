#include "chatForm.h"

using namespace System;
using namespace System::Windows::Forms;

[STAThread]
void main(array<String^>^ args) {
	Application::EnableVisualStyles();
	Application::SetCompatibleTextRenderingDefault(false);
	ChatProject::chatForm form;
	Application::Run(%form);
}

void testFunction() {
	int i = 1;
	i = i + 9;
}