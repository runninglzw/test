#include<windows.h>
LRESULT CALLBACK proc(HWND hwnd,UINT32 message,WPARAM wp,LPARAM lp);
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
		case WM_DESTROY:
			{
				PostQuitMessage(0);
				return 0;
			}
		default:
			break;
		}
		return DefWindowProc(hwnd,message,wp,lp);
	}