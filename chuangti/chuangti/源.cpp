#include<windows.h>
#define IDC_MAIN_BUTTON 101
#define IDC_MAIN_EDIT 102
LRESULT CALLBACK proc(HWND hwnd,UINT32 message,WPARAM wp,LPARAM lp);
HWND hedit;
INT WINAPI wWinMain(HINSTANCE hInst,HINSTANCE hPrevInst,LPWSTR lpCmdLine,INT nshowCmd)
{
	//int result=MessageBox(NULL,"hahahahah","hello",MB_ICONINFORMATION|MB_YESNO);
	//ע�ᴰ��
	WNDCLASSEX wclass;//����������
	ZeroMemory(&wclass,sizeof(WNDCLASSEX));//Ϊ��������ڴ�
	wclass.cbClsExtra=NULL;
	wclass.cbSize=sizeof(WNDCLASSEX);//����Ĵ�С
	wclass.hbrBackground=(HBRUSH)COLOR_WINDOW;//���ô��屳��
	wclass.hCursor=LoadCursor(NULL,IDC_ARROW);//���ù����ʽ
	wclass.hIcon=NULL;
	wclass.hIconSm=NULL;
	wclass.hInstance=hInst;//��ģ���ʵ�����
	wclass.lpfnWndProc=(WNDPROC)proc;//�ص�����ָ��
	wclass.lpszClassName="Window class";//ָ��ע��������ָ��----------
	wclass.lpszMenuName=NULL;
	wclass.style=CS_HREDRAW|CS_VREDRAW;//���ó������ʽ����ˮƽ��ֱ����仯ʱ���»��ƴ���
	if(!RegisterClassEx(&wclass))//ע�ᴰ��
	{
		int res=GetLastError();//���������
		MessageBox(NULL,"����ע��ʧ��","����ע�����",MB_ICONERROR);

	}
	//��������
	HWND hwnd=CreateWindowEx(
		NULL,
		"Window class",//ָ��ע��������ָ��----------
		"�򵥴���",
		WS_OVERLAPPEDWINDOW,
		200,
		200,
		640,
		480,
		NULL,
		NULL,
		hInst,
		NULL
		);
	if(!hwnd)
	{
		int res=GetLastError();//���������
		MessageBox(NULL,"���崴��ʧ��","���崴������",MB_ICONERROR);
	}
	//��ʾ����
	ShowWindow(hwnd,nshowCmd);
	//��������ص�����
	MSG msg;
	ZeroMemory(&msg,sizeof(MSG));
	while(GetMessage(&msg,NULL,0,0))//������Ϣ
	{
		TranslateMessage(&msg);//ת����Ϣ����msg�У������û�����˴��ڵĹرյȰ�ť
		DispatchMessage(&msg);//���ûص�����������msg��Ϣ
	}

	return 0;
}
	LRESULT CALLBACK proc(HWND hwnd,UINT32 message,WPARAM wp,LPARAM lp)
	{
		switch (message)
		{
		case WM_CREATE:
			{
				hedit=CreateWindowEx(WS_EX_CLIENTEDGE,
					"EDIT",//�ؼ�����
					"",//��ʼ�ı�
					WS_CHILD|WS_VISIBLE|ES_MULTILINE|ES_AUTOHSCROLL|ES_AUTOVSCROLL,
					30,
					30,
					200,
					100,
					hwnd,
					(HMENU)IDC_MAIN_EDIT,
					GetModuleHandle(NULL),
					NULL
					);
				HGDIOBJ hf=GetStockObject(DEFAULT_GUI_FONT);//��������
				SendMessage(hedit,WM_SETFONT,(WPARAM)hf,MAKELPARAM(FALSE,0));
				SendMessage(hedit,WM_SETTEXT,NULL,(LPARAM)"�û����������롣����");//�����ı�
				//����һ����ť
				HWND hwndbutton=CreateWindowEx(NULL,
					"BUTTON",
					"ȷ��",
					WS_TABSTOP|WS_VISIBLE|WS_CHILD|BS_DEFPUSHBUTTON,
					50,
					150,
					100,
					24,
					hwnd,
					(HMENU)IDC_MAIN_BUTTON,
					GetModuleHandle(NULL),
					NULL
					);
				SendMessage(hedit,WM_SETFONT,(WPARAM)hf,MAKELPARAM(FALSE,0));//��������
			}
			break;

		case WM_COMMAND:
			switch(LOWORD(wp))
			{
			case IDC_MAIN_BUTTON:
				{
					char buffer[256];
					SendMessage(hedit,WM_GETTEXT,sizeof(buffer)/sizeof(buffer[0]),reinterpret_cast<LPARAM>(buffer));//���ı������ݸ���buffer
					MessageBox(NULL,buffer,"��Ϣ��ʾ",MB_ICONINFORMATION);//��ʾbuffer
				}
				break;
			}
			break;
		case WM_DESTROY:
			{
				PostQuitMessage(0);
				return 0;
			}
		default:
			break;
		}
		return DefWindowProc(hwnd,message,wp,lp);//������Ϣ������ϵͳ�ṩ��ȱʡ������
	}